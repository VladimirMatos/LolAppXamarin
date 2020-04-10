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
    public class TierListViewModel : BaseViewModel, INotifyPropertyChanged
    {

        IApiService apiService = new ApiService();
        public List<Contins> ListContinent { get; set; }
        public string Continentes { get; set; }
        private Contins _selectedRegion;
        public DelegateCommand TierListInf { get; set; }
     
        public ObservableCollection<Players> TierList { get; set; }
        public TierListViewModel(PageDialogService pageDialogService, INavigationService navigationService) : base(pageDialogService, navigationService)
        {
            ListContinent = GetContinents().OrderBy(c => c.LolCont).ToList();
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
            if (await InternetConnection(true))
            {
                try
                {
                    var list = await apiService.GetTierList(Continentes);
                    TierList = new ObservableCollection<Players>(list.PlayersInfo);

                }
                catch (Exception e)
                {

                    await ShowMessage(NetMessages.ErrorOccured, e.Message, NetMessages.Ok);
                }
            }
        }

    }
}
