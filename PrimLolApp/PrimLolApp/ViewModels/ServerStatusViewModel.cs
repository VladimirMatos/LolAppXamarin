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
    public class ServerStatusViewModel : BaseViewModel,INotifyPropertyChanged
    {
        IPageDialogService dialogService;
        INavigationService navigationService;
        ApiService apiService = new ApiService();
        public DelegateCommand ServerStatusInf { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Servers ClientStatus { get; set; } = new Servers();
        public ObservableCollection<Servers> ServerStatuses { get; set; }
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
            ServerStatuses = new ObservableCollection<Servers>(list.Serversinfo);
        }
        void Messages()
        {
            dialogService.DisplayAlertAsync("Error", "Check your connection to internet", "ok");
        }
    }
}
