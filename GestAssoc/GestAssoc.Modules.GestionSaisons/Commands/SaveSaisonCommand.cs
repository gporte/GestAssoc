using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionSaisons.Constantes;
using GestAssoc.Modules.GestionSaisons.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionSaisons.Commands
{
	public class SaveSaisonCommand : ICommand
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
				.Resolve<IGestionSaisonsServices>();

			var itemToSave = parameter as Saison;
			bool isNewSaison = itemToSave.ID == Guid.Empty;
			List<string> errorsList;

			try {
				if (this.IsValidForSaving(itemToSave, out errorsList)) {
					UIServices.SetBusyState();
					service.SaveSaison(itemToSave);
					NotificationHelper.WriteNotification("Enregistrement effectué.");

					// si il s'agit d'une nouvelle saison, elle devient la saison courante
					if (isNewSaison) {
						UIServices.SetBusyState();
						service.SetSaisonCourante(itemToSave);
						NotificationHelper.WriteNotification("Nouvelle saison courante : " + itemToSave.ToString());
					}

					new ShowViewCommand(ViewNames.ConsultationSaisons.ToString()).Execute(null);
				}
				else {
					errorsList.Insert(0, "Saison non valide. Enregistrement annulé.");
					NotificationHelper.WriteNotificationList(errorsList);
				}
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}

		private bool IsValidForSaving(Saison itemToSave, out List<string> errorsList) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionSaisonsServices>();

			errorsList = new List<string>();

			if (itemToSave.AnneeDebut >= itemToSave.AnneeFin) {
				errorsList.Add("L'année de fin doit être supérieure à l'année de début.");
			}

			// on vérifie qu'il n'y a pas déjà un item différent (ID différent) mais avec le même couple année début+année fin
			UIServices.SetBusyState();
			var itemExists = service.GetAllSaisons().Count(x => x.ToString() == itemToSave.ToString() && x.ID != itemToSave.ID) > 0;

			if (itemExists) {
				errorsList.Add("Cette saison existe déjà (année début + année fin).");
			}

			return errorsList.Count == 0;
		}
	}
}
