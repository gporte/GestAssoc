using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionVilles.Constantes;
using GestAssoc.Modules.GestionVilles.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionVilles.Properties.Resources;

namespace GestAssoc.Modules.GestionVilles.Commands
{
	public class DeleteVilleCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			var itemToDelete = parameter as Ville;

			return itemToDelete != null 
				&& itemToDelete.Adherents.Count == 0 
				&& itemToDelete.InfosClubs.Count == 0;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			var itemToDelete = parameter as Ville;

			try {
				UIServices.SetBusyState();
				service.DeleteVille(itemToDelete);

				NotificationHelper.WriteNotification(GlblRes.Log_EnregistrementSupprime);

				new ShowViewCommand(ViewNames.ConsultationVilles.ToString()).Execute(null);
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}
	}
}
