using PrimLolApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Prism.Modularity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrimLolApp.ViewModels;

namespace PrimLolApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base (initializer) { }
        
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri("/TabbedPageView"));
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SummonerView, SummonerViewModel>();
            containerRegistry.RegisterForNavigation<TierListPlayersView, TierListViewModel>();
            containerRegistry.RegisterForNavigation<LeagueView, RankedEloViewModel>();
            containerRegistry.RegisterForNavigation<TabbedPageView, TabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<ServerStatusView, ServerStatusViewModel>();
        } 
 
    }
}
