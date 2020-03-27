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
    public class TierListViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IPageDialogService dialogService;
        INavigationService navigationService;
        ApiService apiService = new ApiService();
        public DelegateCommand TierListInf { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Players playersInf { get; set; } = new Players();
        public ObservableCollection<Players> TierList { get; set; }
        public TierListViewModel(INavigationService inavigationservice, IPageDialogService pageDialogService)
        {
            navigationService = inavigationservice;
            dialogService = pageDialogService;
            TierListInf = new DelegateCommand(async () =>
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    try
                    {
                        await LoadTierList();
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
        async Task LoadTierList()
        {
            var list = await apiService.GetTierList(playersInf.Region);
            TierList = new ObservableCollection<Players>(list.PlayersInfo);
        }
        void Messages()
        {
            dialogService.DisplayAlertAsync("Error", "Check your connection to internet", "ok");
        }
    }
}
