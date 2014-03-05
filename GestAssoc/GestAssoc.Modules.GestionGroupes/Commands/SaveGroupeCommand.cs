using GestAssoc.Common.Commands;
using GestAssoc.Modules.GestionGroupes.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionGroupes.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionGroupes.Commands
{
	public class SaveGroupeCommand : ICommand
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
				.Resolve<IGestionGroupesServices>();

			var itemToSave = parameter as Groupe;

			try {
				service.SaveGroupe(itemToSave);

				NotificationHelper.WriteNotification("Enregistrement effectué.");

				new ShowViewCommand(ViewNames.ConsultationGroupes.ToString()).Execute(null);
			}
			catch (Exception) {
				throw;
			}
		}
	}
}
