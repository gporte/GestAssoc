using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionAdherents.Services;
using GestAssoc.Modules.GestionAdherents.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionAdherents
{
	[Priority(500)]
	public class ModuleGestionAdherents : IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteNotification("Initialisation du Module GestionAdherents.");

			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(GestionAdherentsRibbonTabView));

			// Enregistrement des vues 
			container.RegisterType<object, ConsultationAdherentsView>(
				ViewNames.ConsultationAdherents
			);
			container.RegisterType<object, FormulaireAdherentView>(
				ViewNames.FormulaireAdherent
			);

			// enregistrement des services
			container.RegisterType<IGestionAdherentsServices, GestionAdherentsServices>();
		}
	}
}
