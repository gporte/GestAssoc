using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInfosClub.Constantes;
using GestAssoc.Modules.GestionInfosClub.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionInfosClub.Properties.Resources;

namespace GestAssoc.Modules.GestionInfosClub.Commands
{
	public class SaveFormulaireInfosClubCommand : ICommand
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
				.Resolve<IGestionInfosClubServices>();

			var itemToSave = parameter as InfosClub;
			List<string> errorsList;
			itemToSave.Ville_ID = itemToSave.Ville.ID;

			try {
				if (this.IsValidForSaving(itemToSave, out errorsList)) {
					UIServices.SetBusyState();
					service.SaveInfosClub(itemToSave);
					NotificationHelper.WriteLog(GlblRes.Log_EnregistrementTermine);
					new ShowViewCommand(ViewNames.ConsultationInfosClub.ToString()).Execute(null);
				}
				else {
					errorsList.Insert(0, GlblRes.Log_EnregistrementAnnule);
					NotificationHelper.WriteLogs(errorsList);
				}
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
			
		}

		private bool IsValidForSaving(InfosClub itemToSave, out List<string> errorsList) {
			var service = ServiceLocator
				.Current.GetInstance<IGestionInfosClubServices>();

			errorsList = new List<string>();

			if (string.IsNullOrWhiteSpace(itemToSave.Nom)) {
				errorsList.Add(GlblRes.Err_NomObligatoire);
			}

			if (string.IsNullOrWhiteSpace(itemToSave.Adresse)) {
				errorsList.Add(GlblRes.Err_AdresseObligatoire);
			}

			if (itemToSave.Ville == null) {
				errorsList.Add(GlblRes.Err_VilleObligatoire);
			}

			return errorsList.Count == 0;
		}
	}
}
