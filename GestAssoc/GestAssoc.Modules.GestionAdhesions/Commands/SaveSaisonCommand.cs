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
using GlblRes = global::GestAssoc.Modules.GestionAdhesions.Properties.Resources;

namespace GestAssoc.Modules.GestionAdhesions.Commands
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
					NotificationHelper.WriteLog(GlblRes.Log_Sai_EnregistrementEffectue);

					// si il s'agit d'une nouvelle saison, elle devient la saison courante
					if (isNewSaison) {
						UIServices.SetBusyState();
						service.SetSaisonCourante(itemToSave);
						NotificationHelper.WriteLog(Resources.Log_Sai_NouvelleSaisonCourante + itemToSave.ToString());
					}

					new ShowViewCommand(ViewNames.ConsultationSaisons.ToString()).Execute(null);
				}
				else {
					errorsList.Insert(0, GlblRes.Log_Sai_EnregistrementAnnule);
					NotificationHelper.WriteLogs(errorsList);
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
				errorsList.Add(GlblRes.Err_Sai_AnneeDebutAnneeFin);
			}

			// on vérifie qu'il n'y a pas déjà un item différent (ID différent) mais avec le même couple année début+année fin
			UIServices.SetBusyState();
			var itemExists = service.GetAllSaisons().Count(x => x.ToString() == itemToSave.ToString() && x.ID != itemToSave.ID) > 0;

			if (itemExists) {
				errorsList.Add(GlblRes.Err_Sai_Existe);
			}

			return errorsList.Count == 0;
		}
	}
}
