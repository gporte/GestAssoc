using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInscriptions.Constantes;
using GestAssoc.Modules.GestionInscriptions.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionInscriptions.Commands
{
	public class SaveInscriptionCommand : ICommand
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
				.Resolve<IGestionInscriptionsServices>();

			var itemToSave = parameter as Inscription;
			List<string> errorsList;

			try {
				if (this.IsValidForSaving(itemToSave, out errorsList)) {
					this.SetStatus(itemToSave);

					// la notion de section n'étant actuellement pas utilisée, on assignera automatiquement la section par défaut.
					itemToSave.Section = service.GetAllSections().Single(x => x.EstDefaut);

					UIServices.SetBusyState();
					service.SaveInscription(itemToSave);
					NotificationHelper.WriteLog(Properties.Resources.Log_EnregistrementEffectue);
					new ShowViewCommand(ViewNames.ConsultationInscriptions.ToString()).Execute(null);
				}
				else {
					errorsList.Insert(0, Properties.Resources.Log_EnregistrementAnnule);
					NotificationHelper.WriteLogs(errorsList);
				}
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}

		private bool IsValidForSaving(Inscription itemToSave, out List<string> errorsList) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionInscriptionsServices>();

			errorsList = new List<string>();

			if (itemToSave.Adherent == null) {
				errorsList.Add(Properties.Resources.Err_AdherentObligatoire);
			}

			if (itemToSave.Groupe == null) {
				errorsList.Add(Properties.Resources.Err_GroupeObligatoire);
			}

			// on vérifie qu'il n'y a pas déjà un item différent (ID différent) mais avec le même couple adhérent + groupe
			UIServices.SetBusyState();
			var itemExists = service.GetAllInscriptions().Count(x => x.ToString() == itemToSave.ToString() && x.ID != itemToSave.ID) > 0;

			if (itemExists) {
				errorsList.Add(Properties.Resources.Err_InscriptionExiste);
			}

			return errorsList.Count == 0;
		}

		private void SetStatus(Inscription itemToSave) {
			if (itemToSave.CertificatMedicalRemis && itemToSave.Cotisation > 0) {
				itemToSave.StatutInscription = 1;
				NotificationHelper.WriteLog(Properties.Resources.Log_StatutValide);
			}
		}
	}
}
