using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionInfosClub.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionInfosClub
{
	[Priority(100)]
	public class ModuleGestionInfosCLub : IModule
	{
		public void Initialize() {
			// Enregistrement du RibbonTab
			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(InfosClubRibbonTabView));

			// Enregistrement des vues
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
			container.RegisterType<object, InfosClubView>(
				ViewNames.ConsultationInfosClub);
		}
	}
}
