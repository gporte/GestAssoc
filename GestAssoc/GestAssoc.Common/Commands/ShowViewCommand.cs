using GestAssoc.Common.Constantes;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Windows.Input;

namespace GestAssoc.Common.Commands
{
	public class ShowViewCommand : ICommand
	{
		public string ViewName { get; set; }
		
		public ShowViewCommand(string viewName) {
			this.ViewName = viewName;
		}

		public bool CanExecute(object cmdParameter) {
			return true;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object cmdParameter) {
			if (this.ViewName != null && !string.IsNullOrWhiteSpace(this.ViewName)) {
				var regionManager = (RegionManager)ServiceLocator.Current.GetInstance<IRegionManager>();

				regionManager.RequestNavigate(
					RegionNames.ContentRegion,
					new Uri(this.ViewName, UriKind.Relative)
				);
			}
		}
	}
}
