using GestAssoc.Common.Constantes;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Windows.Input;

namespace GestAssoc.Common.Commands
{
	public class ShowViewCommandWithParameter : ICommand
	{
		public string ViewName { get; set; }

		public ShowViewCommandWithParameter(string viewName) {
			this.ViewName = viewName;
		}

		public bool CanExecute(object itemId) {
			return true;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object itemId) {
			if (this.ViewName != null && !string.IsNullOrWhiteSpace(this.ViewName)) {
				var regionManager = (RegionManager)ServiceLocator.Current.GetInstance<IRegionManager>();

				var q = new NavigationParameters();
				q.Add("ItemId", itemId.ToString());

				regionManager.RequestNavigate(
					RegionNames.ContentRegion,
					new Uri(this.ViewName + q.ToString(), UriKind.Relative)
				);
			}
		}
	}
}
