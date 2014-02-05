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
		private string _cmdParameter;

		public ShowViewCommandWithParameter(string cmdParameter) {
			this._cmdParameter = cmdParameter;
		}

		public bool CanExecute(object viewName) {
			return true;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object viewName) {
			if (viewName != null && !string.IsNullOrWhiteSpace(viewName.ToString())) {
				var regionManager = (RegionManager)ServiceLocator.Current.GetInstance<IRegionManager>();

				var q = new UriQuery();
				q.Add("ItemId", this._cmdParameter);

				regionManager.RequestNavigate(
					RegionNames.ContentRegion,
					new Uri(viewName.ToString() + q.ToString(), UriKind.Relative)
				);
			}
		}
	}
}
