using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionSaisons.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionSaisons.Commands
{
	public class SaveSaisonCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			return parameter != null;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			// TODO contrôler la validité

			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionSaisonsServices>();

			var itemToSave = parameter as Saison;

			try {
				service.SaveSaison(itemToSave);

				NotificationHelper.WriteNotification("Enregistrement effectué.");

				new ShowViewCommand(ViewNames.ConsultationSaisons).Execute(null);
			}
			catch (Exception) {
				throw;
			}
		}
	}
}
