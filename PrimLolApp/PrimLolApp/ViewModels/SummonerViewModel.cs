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

namespace PrismLolApp.ViewModels
{
    public class SummonerViewModel : INotifyPropertyChanged
    {
        IPageDialogService dialogService;
        SummonersInf Summoners { get; set; }

        public SummonersInf summonersInf { get; set; }
        IApiService apiServices = new ApiService();

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SummonerInfo { get; set; }

        public SummonerViewModel()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    GetSummoners();
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
        }
      
        async Task GetSummoners()
        {
            var response = await apiServices.GetSummonersInfo(Summoners.Name);
            summonersInf = response;
        }
        void Messages()
        {
            dialogService.DisplayAlertAsync("Error", "Check your connection to internet", "ok");
        }
    }
}
