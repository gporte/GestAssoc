using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionSaisons.Constantes;
using GestAssoc.Modules.GestionSaisons.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionSaisons.Commands
{
	public class DeleteSaisonCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			var itemToDelete = parameter as Saison;

			return itemToDelete != null
				&& itemToDelete.Groupes.Count == 0;

		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionSaisonsServices>();

			var itemToDelete = parameter as Saison;

			try {
				service.DeleteSaison(itemToDelete);

				NotificationHelper.WriteNotification("Enregistrement supprimé.");

				new ShowViewCommand(ViewNames.ConsultationSaisons.ToString()).Execute(null);
			}
			catch (Exception) {
				throw;
			}
		}
	}
}
