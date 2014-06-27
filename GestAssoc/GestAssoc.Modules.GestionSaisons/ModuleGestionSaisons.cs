using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionSaisons.Constantes;
using GestAssoc.Modules.GestionSaisons.Properties;
using GestAssoc.Modules.GestionSaisons.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionSaisons
{
	[Priority(300)]
	public class ModuleGestionSaisons : ModuleBase, IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteLog(Resources.Log_InitModule);

			this.TabRegion = RibbonTabRegion.Referentiel;

			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(this.GetRegionName(), typeof(GestionSaisonsMenuView));

			// Enregistrement des vues 
			container.RegisterType<object, ConsultationSaisonsView>(
				ViewNames.ConsultationSaisons.ToString()
			);
			container.RegisterType<object, FormulaireSaisonView>(
				ViewNames.FormulaireSaison.ToString()
			);
		}
	}
}
