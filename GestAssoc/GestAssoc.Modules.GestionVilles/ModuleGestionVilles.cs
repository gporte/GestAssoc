using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionVilles.Services;
using GestAssoc.Modules.GestionVilles.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionVilles
{
	[Priority(200)]
	public class ModuleGestionVilles : ModuleBase, IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteNotification("Initialisation du Module GestionVilles.");

			this.TabRegion = RibbonTabRegion.Referentiel;
			
			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();		

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(this.GetRegionName(), typeof(GestionVillesMenuView));
			
			// Enregistrement des vues 
			container.RegisterType<object, ConsultationVillesView>(
				ViewNames.ConsultationVilles
			);
			container.RegisterType<object, FormulaireVilleView>(
				ViewNames.FormulaireVille
			);

			// enregistrement des services
			container.RegisterType<IGestionVillesServices, GestionVillesServices>();
		}
	}
}
