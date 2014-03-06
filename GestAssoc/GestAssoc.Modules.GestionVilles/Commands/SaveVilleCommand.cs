using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionVilles.Constantes;
using GestAssoc.Modules.GestionVilles.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
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
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			var itemToSave = parameter as Ville;
			List<string> errorsList;

			try {
				if (this.IsValidForSaving(itemToSave, out errorsList)) {
					UIServices.SetBusyState();
					service.SaveVille(itemToSave);
					NotificationHelper.WriteNotification("Enregistrement effectué.");
					new ShowViewCommand(ViewNames.ConsultationVilles.ToString()).Execute(null);
				}
				else {
					errorsList.Insert(0,"Ville non valide. Enregistrement annulé.");					
					NotificationHelper.WriteNotificationList(errorsList);
				}				
			}
			catch (Exception) {
				// TODO gérer l'exception??
				throw;
			}
		}

		private bool IsValidForSaving(Ville itemToSave, out List<string> errorsList) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			errorsList = new List<string>();

			if (string.IsNullOrWhiteSpace(itemToSave.Libelle)) {
				errorsList.Add("Libellé obligatoire.");
			}

			if (string.IsNullOrWhiteSpace(itemToSave.CodePostal)) {
				errorsList.Add("Code postal obligatoire.");
			}

			// on vérifie qu'il n'y a pas déjà un item différent (ID différent) mais avec le même couple code postal+libellé
			UIServices.SetBusyState();
			var itemExists = service.GetAllVilles().Count(x => x.ToString() == itemToSave.ToString() && x.ID != itemToSave.ID) > 0;

			if (itemExists) {
				errorsList.Add("Cette ville existe déjà (code postal + libellé).");
			}

			return errorsList.Count == 0;
		}
	}
}
