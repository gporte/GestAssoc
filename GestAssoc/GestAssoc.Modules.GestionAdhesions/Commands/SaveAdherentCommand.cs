using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Properties;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdhesions.Commands
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
					NotificationHelper.WriteLog(Resources.Log_EnregistrementEffectue);
					new ShowViewCommand(ViewNames.ConsultationAdherents.ToString()).Execute(null);
				}
				else {
					errorsList.Insert(0, Resources.Log_EnregistrementAnnule);
					NotificationHelper.WriteLogs(errorsList);
				}
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}

		private bool IsValidForSaving(Adherent itemToSave, out List<string> errorsList) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionAdherentsServices>();

			errorsList = new List<string>();

			if (string.IsNullOrWhiteSpace(itemToSave.Nom)) {
				errorsList.Add(Resources.Err_NomObligatoire);
			}

			if (string.IsNullOrWhiteSpace(itemToSave.Prenom)) {
				errorsList.Add(Resources.Err_PrenomObligatoire);
			}

			if (itemToSave.DateNaissance == DateTime.MinValue) {
				errorsList.Add(Resources.Err_NaissanceObligatoire);
			}

			if (itemToSave.DateNaissance < DefaultValueHelper.DateTimeSQLMinValue) {
				errorsList.Add(Resources.Err_DateNaissanceTropAncienne);
			}

			if (string.IsNullOrWhiteSpace(itemToSave.Adresse)) {
				errorsList.Add(Resources.Err_AdresseObligatoire);
			}

			if (itemToSave.Ville == null) {
				errorsList.Add(Resources.Err_VilleObligatoire);
			}

			// on vérifie qu'il n'y a pas déjà un item différent (ID différent) mais avec le même couple nom + prénom
			UIServices.SetBusyState();
			var itemExists = service.GetAllAdherents().Count(x => x.ToString() == itemToSave.ToString() && x.ID != itemToSave.ID) > 0;

			if (itemExists) {
				errorsList.Add(Resources.Err_AdherentExiste);
			}

			return errorsList.Count == 0;
		}
	}
}
