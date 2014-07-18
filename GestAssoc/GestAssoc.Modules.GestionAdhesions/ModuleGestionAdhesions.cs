using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Properties;
using GestAssoc.Modules.GestionAdhesions.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionAdhesions
{
	[Priority(200)]
	public class ModuleGestionAdhesions : ModuleBase, IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteLog(Resources.Log_InitialisationModule);

			this.TabRegion = RibbonTabRegion.Inscriptions;

			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(this.GetRegionName(), typeof(GestionAdherentsMenuView));
			regionManager.RegisterViewWithRegion(this.GetRegionName(), typeof(GestionGroupesMenuView));

			// Enregistrement des vues 
			container.RegisterType<object, ConsultationAdherentsView>(
				ViewNames.ConsultationAdherents.ToString()
			);
			container.RegisterType<object, FormulaireAdherentView>(
				ViewNames.FormulaireAdherent.ToString()
			);

			container.RegisterType<object, ConsultationGroupesView>(
				ViewNames.ConsultationAdherents.ToString()
			);
			container.RegisterType<object, FormulaireGroupeView>(
				ViewNames.FormulaireAdherent.ToString()
			);
		}
	}
}
