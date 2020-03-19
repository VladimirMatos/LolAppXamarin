using PrismLolApp.Services;
using PrismLolApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Prism.Services;
using Prism.Commands;
using Prism.Navigation;
using PrimLolApp.ViewModels;

namespace PrismLolApp.ViewModels
{
    public class SummonerViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IPageDialogService dialogService;
        INavigationService navigationService;
        

        public SummonersInf SummonersInf { get; set; } = new SummonersInf();
        IApiService apiServices = new ApiService();

        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand SummonerInfoCommand { get; set; }

        public SummonerViewModel(INavigationService inavigationservice, IPageDialogService pageDialogService)
        {
            navigationService = inavigationservice;
            dialogService = pageDialogService;
            SummonerInfoCommand = new DelegateCommand(async()=>{
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    await GetSummoners();
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
      
        async Task GetSummoners()
        {
            var response = await apiServices.GetSummonersInfo(SummonersInf.Name);
            SummonersInf = response;
        }
        void Messages()
        {
            dialogService.DisplayAlertAsync("Error", "Check your connection to internet", "ok");
        }
    }
}
