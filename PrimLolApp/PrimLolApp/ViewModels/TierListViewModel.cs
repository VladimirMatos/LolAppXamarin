using PrimLolApp.Models;
using PrimLolApp.Models.Utility;
using PrimLolApp.Models.Utilitys;
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
    public class TierListViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IPageDialogService dialogService;
        INavigationService navigationService;
        ApiService apiService = new ApiService();
        public List<Contins> ListContinent { get; set; }
        public string Continentes { get; set; }
        private Contins _selectedRegion;
        public DelegateCommand TierListInf { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Players playersInf { get; set; } = new Players();
        public ObservableCollection<Players> TierList { get; set; }
        public TierListViewModel(INavigationService inavigationservice, IPageDialogService pageDialogService)
        {
            ListContinent = ContinsPicker.GetContinents().OrderBy(c => c.LolCont).ToList();
            navigationService = inavigationservice;
            dialogService = pageDialogService;
            TierListInf = new DelegateCommand(async () =>
            {
                await LoadTierList();
            });

        }
        public Contins SelectedContins
        {
            get
            {
                return _selectedRegion;
            }
            set
            {
                SetProperty(ref _selectedRegion, value);
                Continentes = _selectedRegion.LolCont;
            }
        }
        async Task LoadTierList()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var list = await apiService.GetTierList(Continentes);
                    TierList = new ObservableCollection<Players>(list.PlayersInfo);
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
