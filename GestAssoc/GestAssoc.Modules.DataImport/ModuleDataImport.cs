using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.Properties;
using GestAssoc.Modules.DataImport.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.DataImport
{
	[Priority(300)]
	public class ModuleDataImport : ModuleBase, IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteLog(Resources.Log_InitModule);

			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(DataImportMenuView));

			// Enregistrement des vues
			container.RegisterType<object, ExcelCsvImportConfigView>(ViewNames.ExcelCsvConfigImport.ToString());
		}
	}
}
