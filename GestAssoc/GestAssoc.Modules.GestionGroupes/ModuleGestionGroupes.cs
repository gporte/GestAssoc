using GestAssoc.Common.BaseClasses;
using GestAssoc.Modules.GestionGroupes.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionGroupes.Services;
using GestAssoc.Modules.GestionGroupes.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionGroupes
{
	[Priority(400)]
	public class ModuleGestionGroupes : ModuleBase, IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteNotification("Initialisation du Module GestionGroupes.");

			this.TabRegion = RibbonTabRegion.Inscriptions;

			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(this.GetRegionName(), typeof(GestionGroupesMenuView));

			// Enregistrement des vues 
			container.RegisterType<object, ConsultationGroupesView>(
				ViewNames.ConsultationGroupes.ToString()
			);
			container.RegisterType<object, FormulaireGroupeView>(
				ViewNames.FormulaireGroupe.ToString()
			);

			// enregistrement des services
			container.RegisterType<IGestionGroupesServices, GestionGroupesServices>();
		}
	}
}
