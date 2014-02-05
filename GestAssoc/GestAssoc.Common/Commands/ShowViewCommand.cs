﻿using GestAssoc.Common.Constantes;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Windows.Input;

namespace GestAssoc.Common.Commands
{
	public class ShowViewCommand : ICommand
	{
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

				regionManager.RequestNavigate(
					RegionNames.ContentRegion,
					new Uri(viewName.ToString(), UriKind.Relative)
				);
			}
		}
	}
}
