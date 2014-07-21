using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionAdhesions.Properties.Resources;

namespace GestAssoc.Modules.GestionAdhesions.Commands
{
	public class SaveVilleCommand : ICommand
	{
		public SaveVilleCommand() {}
		
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
					
					NotificationHelper.WriteLog(GlblRes.Log_Vil_EnregistrementEffectue);

					new ShowViewCommand(ViewNames.ConsultationVilles.ToString()).Execute(null);
				}
				else {
					NotificationHelper.ShowUserNotification(string.Join(Environment.NewLine, errorsList.ToArray()));

					errorsList.Insert(0,GlblRes.Log_Vil_EnregistrementAnnule);					
					NotificationHelper.WriteLogs(errorsList);
				}				
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}

		private bool IsValidForSaving(Ville itemToSave, out List<string> errorsList) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			errorsList = new List<string>();

			if (string.IsNullOrWhiteSpace(itemToSave.Libelle)) {
				errorsList.Add(GlblRes.Err_Vil_LibelleObligatoire);
			}

			if (string.IsNullOrWhiteSpace(itemToSave.CodePostal)) {
				errorsList.Add(GlblRes.Err_Vil_CodePostalObligatoire);
			}

			// on vérifie qu'il n'y a pas déjà un item différent (ID différent) mais avec le même couple code postal+libellé
			UIServices.SetBusyState();
			var itemExists = service.GetAllVilles().Count(x => x.ToString() == itemToSave.ToString() && x.ID != itemToSave.ID) > 0;

			if (itemExists) {
				errorsList.Add(GlblRes.Err_Vil_Existe);
			}

			return errorsList.Count == 0;
		}
	}
}
