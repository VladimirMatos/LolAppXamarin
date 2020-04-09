
using PrimLolApp.Models;
using PrimLolApp.Services;
using PrimLolApp.Utility;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PrimLolApp.ViewModels
{
    public class SummonerViewModel : BaseViewModel, INotifyPropertyChanged
    {

        public string Regiones { get; set; }
        private Regiones _selectedRegion;
        public List<Regiones> ListRegion { get; set; }
        public SummonersInf SummonersInf { get; set; } = new SummonersInf();
        IApiService apiServices = new ApiService();
        public DelegateCommand SummonerInfoCommand { get; set; }



        public SummonerViewModel(PageDialogService pageDialogService, INavigationService navigationService) : base(pageDialogService, navigationService)
        {
            ListRegion = RegionsPicker.GetRegion().OrderBy(c => c.LolRegiones).ToList();
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

            if (await InternetConnection(true))
            {
                try
                {
                    var response = await apiServices.GetSummonersInfo(Regiones, SummonersInf.Name);
                    SummonersInf = response;

                }
                catch (Exception e)
                {

                    await ShowMessage(NetMessages.ErrorOccured, e.Message, NetMessages.Ok);
                }
            }

        }

    }
}
