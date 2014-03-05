using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionVilles.Constantes;
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
				.Resolve<IGestionVillesServices>();

			var itemToSave = parameter as Ville;

			try {
				service.SaveVille(itemToSave);

				NotificationHelper.WriteNotification("Enregistrement effectué.");

				new ShowViewCommand(ViewNames.ConsultationVilles.ToString()).Execute(null);
			}
			catch (Exception) {
				throw;
			}
		}
	}
}
