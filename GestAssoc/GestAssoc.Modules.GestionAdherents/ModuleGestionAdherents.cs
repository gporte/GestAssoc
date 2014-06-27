using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionAdherents.Constantes;
using GestAssoc.Modules.GestionAdherents.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using GlblRes = global::GestAssoc.Modules.GestionAdherents.Properties.Resources;

namespace GestAssoc.Modules.GestionAdherents
{
	[Priority(500)]
	public class ModuleGestionAdherents : ModuleBase, IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteLog(GlblRes.Log_InitialisationModule);

			this.TabRegion = RibbonTabRegion.Inscriptions;

			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(this.GetRegionName(), typeof(GestionAdherentsMenuView));

			// Enregistrement des vues 
			container.RegisterType<object, ConsultationAdherentsView>(
				ViewNames.ConsultationAdherents.ToString()
			);
			container.RegisterType<object, FormulaireAdherentView>(
				ViewNames.FormulaireAdherent.ToString()
			);
		}
	}
}
