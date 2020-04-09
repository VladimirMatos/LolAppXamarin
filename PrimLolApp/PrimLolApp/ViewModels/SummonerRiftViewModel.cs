using PrimLolApp.Models;
using PrimLolApp.Services;
using PrimLolApp.Utility;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PrimLolApp.ViewModels
{
    public class SummonerRiftViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public string Regiones { get; set; }
        private Regiones _selectedRegion;
        public List<Regiones> ListRegion { get; set; }
        public ObservableCollection<SummonerRift> SummonerRift { get; set; }
        public SummonerRift PlayerRift { get; set; } = new SummonerRift(); 

        IApiService apiServices = new ApiService();
        public DelegateCommand SummonerRiftCommand { get; set; }

        public SummonerRiftViewModel(PageDialogService pageDialogService, INavigationService navigationService) : base(pageDialogService, navigationService)
        {
            ListRegion = RegionsPicker.GetRegion().OrderBy(c => c.LolRegiones).ToList();
            SummonerRiftCommand = new DelegateCommand(async () =>
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

            if (await InternetConnection(true))
            {
                try
                {
                    var response = await apiServices.GetSummonerRift(Regiones, PlayerRift.SummonerId);
                    SummonerRift = new ObservableCollection<SummonerRift>(response); ;

                }
                catch (Exception e)
                {

                    await ShowMessage(NetMessages.ErrorOccured, e.Message, NetMessages.Ok);
                }
            }

        }

    }
}
