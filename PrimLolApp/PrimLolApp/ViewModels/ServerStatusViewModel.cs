using PrimLolApp.Models;
using PrimLolApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrimLolApp.ViewModels
{
    public class ServerStatusViewModel :BaseViewModel,INotifyPropertyChanged
    {
        IPageDialogService dialogService;
        INavigationService navigationService;
        ApiService apiService = new ApiService();
        public DelegateCommand ServerStatusInf { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ServerStatus MyServer { get; set; } = new ServerStatus();
        public ObservableCollection<Servers> ServerStatuses { get; set; }
        public ObservableCollection<Service> ServiceStatuses { get; set; }
        public ObservableCollection<Incident> IncidentsStatuses { get; set; }
        public ObservableCollection<Update> UpdatesStatus { get; set; }
        
        public Servers ClientStatus { get; set; } = new Servers();
        public ServerStatusViewModel(INavigationService inavigationservice, IPageDialogService pageDialogService)
        {
            navigationService = inavigationservice;
            dialogService = pageDialogService;
            ServerStatusInf = new DelegateCommand(async () =>
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    try
                    {
                        await LoadServerStatus();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"API EXCEPTION {ex}");
                    }

                }
                else
                {
                    Messages();
                }

            });

        }
        async Task LoadServerStatus()   
        {
            var list = await apiService.GetServerStatus(ClientStatus.Region);
            ServerStatuses = new ObservableCollection<Servers>(list.Servers);
            foreach (var item in list.Servers)
            {
                ServiceStatuses = new ObservableCollection<Service>(item.Services); 
            }
            foreach (var item in ServiceStatuses)
            {
                IncidentsStatuses = new ObservableCollection<Incident>(item.Incidents);
            }
            foreach (var item in IncidentsStatuses)
            {
                UpdatesStatus = new ObservableCollection<Update>(item.Updates);
            }
        }
        void Messages()
        {
            dialogService.DisplayAlertAsync("Error", "Check your connection to internet", "ok");
        }
    }
}
