using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionVilles.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionVilles.Commands
{
	public class SaveVilleCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			// TODO bouchon
			return true;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			var itemToSave = parameter as Ville;

			try {
				service.SaveVille(itemToSave);

				NotificationHelper.WriteNotification("Enregistrement effectué.");

				new ShowViewCommand(ViewNames.ConsultationVilles).Execute(null);
			}
			catch (Exception) {
				throw;
			}
		}
	}
}
