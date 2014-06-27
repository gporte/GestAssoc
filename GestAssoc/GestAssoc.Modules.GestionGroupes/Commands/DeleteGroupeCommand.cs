using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionGroupes.Constantes;
using GestAssoc.Modules.GestionGroupes.Properties;
using GestAssoc.Modules.GestionGroupes.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionGroupes.Commands
{
	public class DeleteGroupeCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			var itemToDelete = parameter as Groupe;

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
				.Resolve<IGestionGroupesServices>();

			var itemToDelete = parameter as Groupe;

			try {
				UIServices.SetBusyState();
				service.DeleteGroupe(itemToDelete);

				NotificationHelper.WriteLog(Resources.Log_EnregistrementSupprime);

				new ShowViewCommand(ViewNames.ConsultationGroupes.ToString()).Execute(null);
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}
	}
}
