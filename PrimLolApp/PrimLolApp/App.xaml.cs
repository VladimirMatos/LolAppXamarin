using PrimLolApp.ViewModels;
using PrimLolApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;

namespace PrimLolApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri("/TabbedPageView", UriKind.Relative));
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SummonerView, SummonerViewModel>();
            containerRegistry.RegisterForNavigation<TierListPlayersView, TierListViewModel>();
            containerRegistry.RegisterForNavigation<LeagueView, RankedEloViewModel>();
            containerRegistry.RegisterForNavigation<TabbedPageView>();
            containerRegistry.RegisterForNavigation<SummonerRiftView, SummonerRiftViewModel>();



        }

    }
}
