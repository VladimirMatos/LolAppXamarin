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
    public class RankedEloViewModel : BaseViewModel,INotifyPropertyChanged
    {
        IPageDialogService dialogService;
        INavigationService navigationService;
        IApiService apiService = new ApiService();
        public DelegateCommand MatchInfCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<LeaguePointsQueue> LeaguePoints { get; set; }
        public LeaguePointsQueue LeaguePointsQueue { get; set; } = new LeaguePointsQueue();
        public RankedEloViewModel(INavigationService inavigationservice, IPageDialogService pageDialogService)
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
            var RankedInfo = await apiService.GetMatchRank(LeaguePointsQueue.Region);
            LeaguePoints = new ObservableCollection<LeaguePointsQueue>(RankedInfo);
        }
        void Messages()
        {
            dialogService.DisplayAlertAsync("Error", "Check your connection to internet", "ok");
        }
    }
}
