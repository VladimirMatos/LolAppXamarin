using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using SendGrid.Helpers.Mail.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimLolApp.ViewModels
{
    public class HomePageViewModel :BaseViewModel
    {
        private INavigationService _navigationServices;
       
        public DelegateCommand GoTabbedPage { get; set; }
        public HomePageViewModel(PageDialogService pageDialogService, INavigationService navigationService) : base(pageDialogService, navigationService)
        {
            _navigationServices = navigationService;
            GoTabbedPage = new DelegateCommand(async () =>
            {
                await NavigationService.NavigateAsync(new Uri("TabbedPageView", UriKind.Relative));
            });

        }
    }
}
