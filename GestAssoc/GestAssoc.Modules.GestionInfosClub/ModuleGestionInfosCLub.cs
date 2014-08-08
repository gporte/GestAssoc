using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionInfosClub.Constantes;
using GestAssoc.Modules.GestionInfosClub.Properties;
using GestAssoc.Modules.GestionInfosClub.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionInfosClub
{
	[Priority(100)]
	public class ModuleGestionInfosClub : ModuleBase, IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteLog(Resources.Log_InitModule);
			
			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
			
			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(InfosClubMenuView));

			// Enregistrement des vues
			container.RegisterType<object, InfosClubView>(ViewNames.ConsultationInfosClub.ToString());
			container.RegisterType<object, FormulaireInfosClubView>(ViewNames.FormulaireInfosClub.ToString());
		}
	}
}
