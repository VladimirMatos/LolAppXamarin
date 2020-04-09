
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
    public abstract class BaseViewModel: INotifyPropertyChanged
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
       
    }
}
