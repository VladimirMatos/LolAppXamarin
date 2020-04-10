
using PrimLolApp.Services;
using PrimLolApp.Utility;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrimLolApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged 
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public INavigationService NavigationService { get; set; }
        public IPageDialogService PageDialogService { get; set; }
        public DelegateCommand _navigateCommand;
        public BaseViewModel(PageDialogService pageDialogService, INavigationService navigationService)
        {
            this.PageDialogService = pageDialogService;
            this.NavigationService = navigationService;

        }
        protected bool SetProperty<T>(ref T backfield, T value,
            [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backfield, value))
            {
                return false;
            }
            backfield = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        public async Task<bool> InternetConnection(bool sendMessage = false)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                return true;
            }
            else
            {
                if (sendMessage)
                {
                    await App.Current.MainPage.DisplayAlert(NetMessages.ErrorOccured, NetMessages.NoInternet, NetMessages.Ok);

                }
                return false;
            }
        }
        public async Task ShowMessage(string title, string message, string cancel, string accept = null)
        {
            await PageDialogService.DisplayAlertAsync(title, message, accept, cancel);
        }
        public static List<Contins> GetContinents()
        {
            var Conti = new List<Contins>()
            {
                new Contins(){LolCont ="americas"},
                new Contins(){LolCont ="asia"},
                new Contins(){LolCont ="europe"},

            };
            return Conti;
        }
        public static List<Division> GetDivision()
        {
            var TypeMatchs = new List<Division>()
            {
                new Division(){MyDivision ="I"},
                new Division(){MyDivision ="II"},
                new Division(){MyDivision ="III"},
                new Division(){MyDivision ="IV"}

            };
            return TypeMatchs;
        }
        public static List<Matchs> GetMatchs()
        {
            var TypeMatchs = new List<Matchs>()
            {
                new Matchs(){TypeMatchs ="RANKED_SOLO_5x5"},
                new Matchs(){TypeMatchs ="RANKED_TFT"},
                new Matchs(){TypeMatchs ="RANKED_FLEX_SR"},
                new Matchs(){TypeMatchs ="RANKED_FLEX_TT"}

            };
            return TypeMatchs;
        }
        public static List<Regiones> GetRegion()
        {
            var Regiones = new List<Regiones>()
            {

                new Regiones(){LolRegiones="br1"},
                new Regiones(){LolRegiones="eun1"},
                new Regiones(){LolRegiones="euw1"},
                new Regiones(){LolRegiones="jp1"},
                new Regiones(){LolRegiones="kr"},
                new Regiones(){LolRegiones="la1"},
                new Regiones(){LolRegiones="la2"},
                new Regiones(){LolRegiones="na1"},
                new Regiones(){LolRegiones="oc1"},
                new Regiones(){LolRegiones="ru"},
                new Regiones(){LolRegiones="tr1"}

            };

            return Regiones;

        }
        public static List<Tiers> GetTiers()
        {
            var Tiers = new List<Tiers>()
            {
                new Tiers(){TierElo ="CHALLENGER"},
                new Tiers(){TierElo ="GRANDMASTER"},
                new Tiers(){TierElo ="MASTER"},
                new Tiers(){TierElo ="DIAMOND"},
                new Tiers(){TierElo ="PLATINUM"},
                new Tiers(){TierElo ="GOLD"},
                new Tiers(){TierElo ="SILVER"},
                new Tiers(){TierElo ="BRONZE"},
                new Tiers(){TierElo ="IRON"},

            };
            return Tiers;
        }

    }
}
