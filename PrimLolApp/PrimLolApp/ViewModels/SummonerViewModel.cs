
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
using PrimLolApp.Models;
using PrimLolApp.Services;
using PrimLolApp.Models.Utilitys;
using System.Linq;

namespace PrimLolApp.ViewModels
{
    public class SummonerViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IPageDialogService dialogService;
        INavigationService navigationService;
        public string Regiones { get; set; }
        private Regiones _selectedRegion;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Regiones> ListRegion { get; set; }
        public SummonersInf SummonersInf { get; set; } = new SummonersInf();
        IApiService apiServices = new ApiService();
        public DelegateCommand SummonerInfoCommand { get; set; }

       

        public SummonerViewModel(INavigationService inavigationservice, IPageDialogService pageDialogService)
        {
            ListRegion = RegionsPicker.GetRegion().OrderBy(c => c.LolRegiones).ToList();
            navigationService = inavigationservice;
            dialogService = pageDialogService;
            SummonerInfoCommand = new DelegateCommand(async () =>
            {
                await GetSummoners();
            });
        }

       public Regiones SelectedRegiones
        {
            get
            {
                return _selectedRegion;
            }
            set
            {
                SetProperty(ref _selectedRegion, value);
                Regiones = _selectedRegion.LolRegiones;
            }
        }
    

         async Task GetSummoners()
         {
             if (Connectivity.NetworkAccess == NetworkAccess.Internet)
             {
                try
                { 
                    var response = await apiServices.GetSummonersInfo(Regiones,SummonersInf.Name);
                    SummonersInf = response;
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
