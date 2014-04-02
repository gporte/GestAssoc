using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionInscriptions.Constantes;
using GestAssoc.Modules.GestionInscriptions.Services;
using GestAssoc.Modules.GestionInscriptions.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionInscriptions
{
	[Priority(600)]
	public class ModuleGestionInscriptions : ModuleBase, IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteNotification("Initialisation du Module GestionInscriptions.");

			this.TabRegion = RibbonTabRegion.Inscriptions;

			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(this.GetRegionName(), typeof(GestionInscriptionsMenuView));

			// Enregistrement des vues 
			container.RegisterType<object, ConsultationInscriptionsView>(
				ViewNames.ConsultationInscriptions.ToString()
			);
			container.RegisterType<object, FormulaireInscriptionView>(
				ViewNames.FormulaireInscription.ToString()
			);

			// enregistrement des services
			container.RegisterType<IGestionInscriptionsServices, GestionInscriptionServices>();
		}
	}
}
