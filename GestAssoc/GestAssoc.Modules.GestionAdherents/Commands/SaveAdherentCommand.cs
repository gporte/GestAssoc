using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdherents.Constantes;
using GestAssoc.Modules.GestionAdherents.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdherents.Commands
{
	public class SaveAdherentCommand : ICommand
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
				.Resolve<IGestionAdherentsServices>();

			var itemToSave = parameter as Adherent;
			List<string> errorsList;

			try {
				if (this.IsValidForSaving(itemToSave, out errorsList)) {
					UIServices.SetBusyState();
					service.SaveAdherent(itemToSave);
					NotificationHelper.WriteNotification("Enregistrement effectué.");
					new ShowViewCommand(ViewNames.ConsultationAdherents.ToString()).Execute(null);
				}
				else {
					errorsList.Insert(0, "Adhérent non valide. Enregistrement annulé.");
					NotificationHelper.WriteNotificationList(errorsList);
				}
			}
			catch (Exception) {
				// TODO gérer l'exception
				throw;
			}
		}

		private bool IsValidForSaving(Adherent itemToSave, out List<string> errorsList) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionAdherentsServices>();

			errorsList = new List<string>();

			if (string.IsNullOrWhiteSpace(itemToSave.Nom)) {
				errorsList.Add("Nom obligatoire.");
			}

			if (string.IsNullOrWhiteSpace(itemToSave.Prenom)) {
				errorsList.Add("Prénom obligatoire.");
			}

			if (itemToSave.DateNaissance == DateTime.MinValue) {
				errorsList.Add("Date de naissance obligatoire.");
			}

			if (string.IsNullOrWhiteSpace(itemToSave.Adresse)) {
				errorsList.Add("Adresse obligatoire.");
			}

			if (itemToSave.Ville == null) {
				errorsList.Add("Ville obligatoire.");
			}

			// on vérifie qu'il n'y a pas déjà un item différent (ID différent) mais avec le même couple nom + prénom
			UIServices.SetBusyState();
			var itemExists = service.GetAllAdherents().Count(x => x.ToString() == itemToSave.ToString() && x.ID != itemToSave.ID) > 0;

			if (itemExists) {
				errorsList.Add("Cet adhérent existe déjà (nom + prénom).");
			}

			return errorsList.Count == 0;
		}
	}
}
