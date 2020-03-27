using PrimLolApp.Models;
using PrimLolApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;


namespace PrimLolApp.ViewModels
{
    public class LeagueViewModel :BaseViewModel, INotifyPropertyChanged
    {
        IPageDialogService dialogService;
        INavigationService navigationService;
        IApiService apiService = new ApiService();
        public DelegateCommand MatchInfCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public LeaguePointsQueue RankINFO { get; set; } = new LeaguePointsQueue();
        public LeagueViewModel(INavigationService inavigationservice, IPageDialogService pageDialogService)
        {
            navigationService = inavigationservice;
            dialogService = pageDialogService;
            MatchInfCommand = new DelegateCommand(async () =>
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    try
                    {
                        await LoadRankedInfo();
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
        async Task LoadRankedInfo()
        {
            var response = await apiService.GetMatchRank(RankINFO.Region);
            RankINFO = response;
        }
        void Messages()
        {
            dialogService.DisplayAlertAsync("Error", "Check your connection to internet", "ok");
        }
    }
}
