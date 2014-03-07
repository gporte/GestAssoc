using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionGroupes.Constantes;
using GestAssoc.Modules.GestionGroupes.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
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
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionGroupesServices>();

			var itemToSave = parameter as Groupe;
			List<string> errorsList;

			try {
				if (this.IsValidForSaving(itemToSave, out errorsList)) {
					UIServices.SetBusyState();
					service.SaveGroupe(itemToSave);
					NotificationHelper.WriteNotification("Enregistrement effectué.");
					new ShowViewCommand(ViewNames.ConsultationGroupes.ToString()).Execute(null);
				}
				else {
					errorsList.Insert(0, "Groupe non valide. Enregistrement annulé.");
					NotificationHelper.WriteNotificationList(errorsList);
				}
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}

		private bool IsValidForSaving(Groupe itemToSave, out List<string> errorsList) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionGroupesServices>();

			errorsList = new List<string>();

			if (string.IsNullOrWhiteSpace(itemToSave.Libelle)) {
				errorsList.Add("Libellé obligatoire.");
			}

			if (itemToSave.HeureDebut == DateTime.MinValue) {
				errorsList.Add("Heure de début obligatoire.");
			}

			if (itemToSave.HeureFin == DateTime.MinValue) {
				errorsList.Add("Heure de fin obligatoire.");
			}

			if((itemToSave.HeureDebut.Hour > itemToSave.HeureFin.Hour)
				|| (itemToSave.HeureDebut.Hour == itemToSave.HeureFin.Hour && itemToSave.HeureDebut.Minute >= itemToSave.HeureFin.Minute)) {
					errorsList.Add("L'heure de fin doit être strictement supérieure à l'heure de début.");
			}

			// on vérifie qu'il n'y a pas déjà un item différent (ID différent) mais avec le même couple libellé+créneau
			UIServices.SetBusyState();
			var itemExists = service.GetAllGroupes().Count(x => x.ToString() == itemToSave.ToString() && x.ID != itemToSave.ID) > 0;

			if (itemExists) {
				errorsList.Add("Ce groupe existe déjà (libellé + créneau).");
			}

			return errorsList.Count == 0;
		}
	}
}
