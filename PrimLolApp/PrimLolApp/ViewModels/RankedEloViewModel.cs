using PrimLolApp.Models;
using PrimLolApp.Models.Utility;
using PrimLolApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
        public List<Division> ListDivision { get; set; }
        public List<Matchs> ListMatchs { get; set; }
        public List<Regiones> ListRegions { get; set; }
        public List<Tiers> ListTiers { get; set; }
        public string Regions { get; set; }
        public string Tiers { get; set; }
        public string Matchs { get; set; }
        public string Divisions { get; set; }
        private Regiones _selectedRegion;
        private Tiers _selectedTiers;
        private Matchs _selectedMatchs;
        private Division _selectedDivision;

        public DelegateCommand MatchInfCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<LeaguePointsQueue> LeaguePoints { get; set; }
        public LeaguePointsQueue LeaguePointsQueue { get; set; } = new LeaguePointsQueue();
        public RankedEloViewModel(INavigationService inavigationservice, IPageDialogService pageDialogService)
        {
            ListRegions = RegionsPicker.GetRegion().OrderBy(c => c.LolRegiones).ToList();
            ListMatchs = MatchPickers.GetMatchs().OrderBy(c => c.TypeMatchs).ToList();
            ListTiers = TiersPicker.GetTiers().OrderBy(c => c.TierElo).ToList();
            ListDivision = DivisionPicker.GetDivision().OrderBy(c => c.MyDivision).ToList();
            navigationService = inavigationservice;
            dialogService = pageDialogService;
            MatchInfCommand = new DelegateCommand(async () =>
            {
                await LoadRankedInfo();

            });

        }
        public Regiones SelectedRegion
        {
            get
            {
                return _selectedRegion;
            }
            set
            {
                SetProperty(ref _selectedRegion, value);
                Regions = _selectedRegion.LolRegiones;
            }
        }
        public Matchs SelectedMatchs
        {
            get
            {
                return _selectedMatchs;
            }
            set
            {
                SetProperty(ref _selectedMatchs, value);
                Matchs = _selectedMatchs.TypeMatchs;
            }
        }
        public Tiers SelectedTiers
        {
            get
            {
                return _selectedTiers;
            }
            set
            {
                SetProperty(ref _selectedTiers, value);
                Tiers = _selectedTiers.TierElo;
            }
        }
        public Division SelectedDvision
        {
            get
            {
                return _selectedDivision;
            }
            set
            {
                SetProperty(ref _selectedDivision, value);
                Divisions = _selectedDivision.MyDivision;
            }
        }

        async Task LoadRankedInfo()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var RankedInfo = await apiService.GetMatchRank(Regions, Matchs, Tiers, Divisions);
                    LeaguePoints = new ObservableCollection<LeaguePointsQueue>(RankedInfo);
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
        void Messages()
        {
            dialogService.DisplayAlertAsync("Error", "Check your connection to internet", "ok");
        }
    }
}
