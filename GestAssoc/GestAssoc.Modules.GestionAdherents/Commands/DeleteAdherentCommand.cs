using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdherents.Constantes;
using GestAssoc.Modules.GestionAdherents.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdherents.Commands
{
	public class DeleteAdherentCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			var itemToDelete = parameter as Adherent;

			return itemToDelete != null
				&& itemToDelete.Inscriptions.Count == 0;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionAdherentsServices>();

			var itemToDelete = parameter as Adherent;

			try {
				UIServices.SetBusyState();
				service.DeleteAdherent(itemToDelete);

				NotificationHelper.WriteNotification("Enregistrement supprimé.");

				new ShowViewCommand(ViewNames.ConsultationAdherents.ToString()).Execute(null);
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}
	}
}
