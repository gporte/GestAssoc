using GestAssoc.Common.Utility;
using GestAssoc.Utility;
using GestAssoc.ViewModels;
using GestAssoc.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Windows;
using System.Windows.Controls.Ribbon;

namespace GestAssoc
{
	public class Bootstrapper : UnityBootstrapper
	{
		protected override System.Windows.DependencyObject CreateShell() {
			var vm = new ShellWindowViewModel();
			return new ShellWindow(vm);
		}

		protected override void InitializeShell() {
			base.InitializeShell();
			App.Current.MainWindow = (Window)this.Shell;
			App.Current.MainWindow.Show();

			// Enregistrement de l'event aggregator
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
			container.RegisterType<IEventAggregator, EventAggregator>();

			// trace
			NotificationHelper.WriteNotification("Initialisation du Shell.");
		}

		protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog() {
			var moduleCatalog = new PrioritizedDirectoryModuleCatalog();
			moduleCatalog.ModulePath = @".\Modules";

			return moduleCatalog;
		}

		protected override Microsoft.Practices.Prism.Regions.RegionAdapterMappings ConfigureRegionAdapterMappings() {
			var mappings = base.ConfigureRegionAdapterMappings();

			if (mappings == null)
				return null;

			mappings.RegisterMapping(typeof(Ribbon), ServiceLocator.Current.GetInstance<RibbonRegionAdapter>());

			return mappings;
		}
	}
}
