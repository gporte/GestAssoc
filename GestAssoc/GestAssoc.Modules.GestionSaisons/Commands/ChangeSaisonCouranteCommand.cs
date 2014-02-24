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
	public class ChangeSaisonCouranteCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			return parameter != null 
				&& !(parameter as Saison).EstSaisonCourante;
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
				service.SetSaisonCourante(itemToSave);

				NotificationHelper.WriteNotification("Nouvelle saison courante : " + itemToSave.ToString());

				new ShowViewCommand(ViewNames.ConsultationSaisons).Execute(null);
			}
			catch (Exception) {
				throw;
			}
		}
	}
}
