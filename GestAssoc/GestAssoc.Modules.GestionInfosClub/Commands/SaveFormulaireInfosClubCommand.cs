using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInfosClub.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionInfosClub.Commands
{
	public class SaveFormulaireInfosClubCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			return true;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionInfosClubServices>();

			service.SaveInfosClub(parameter as InfosClub);
		}
	}
}
