using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionInfosClub.Services;
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
			// trace
			NotificationHelper.WriteNotification("Initialisation du Module GestionInfosClub.");
			
			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
			
			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(InfosClubRibbonTabView));

			// Enregistrement des vues
			container.RegisterType<object, InfosClubView>(ViewNames.ConsultationInfosClub);
			container.RegisterType<object, FormulaireInfosClubView>(ViewNames.FormulaireInfosClub);

			// enregistrement des services
			container.RegisterType<IGestionInfosClubServices, GestionInfosClubServices>();
		}
	}
}
