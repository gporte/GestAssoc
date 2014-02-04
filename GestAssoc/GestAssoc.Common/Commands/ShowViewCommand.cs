using GestAssoc.Common.Constantes;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Windows.Input;

namespace GestAssoc.Common.Commands
{
	public class ShowViewCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			return true;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			if (parameter != null && !string.IsNullOrWhiteSpace(parameter.ToString())) {
				var regionManager = (RegionManager)ServiceLocator.Current.GetInstance<IRegionManager>();

				regionManager.RequestNavigate(
					RegionNames.ContentRegion,
					new Uri(parameter.ToString(), UriKind.Relative)
				);
			}
		}
	}
}
