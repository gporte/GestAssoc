using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInscriptions.Constantes;
using GestAssoc.Modules.GestionInscriptions.Properties;
using GestAssoc.Modules.GestionInscriptions.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionInscriptions.Commands
{
	public class DeleteInscriptionCommand : ICommand
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
				.Resolve<IGestionInscriptionsServices>();

			var itemToDelete = parameter as Inscription;

			try {
				UIServices.SetBusyState();
				service.DeleteInscription(itemToDelete);

				NotificationHelper.WriteLog(Resources.Log_EnregistrementSupprime);

				new ShowViewCommand(ViewNames.ConsultationInscriptions.ToString()).Execute(null);
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}
	}
}
