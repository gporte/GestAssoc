﻿using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionGroupes.Constantes;
using GestAssoc.Modules.GestionGroupes.Properties;
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
					NotificationHelper.WriteLog(Resources.Log_EnregistrementEffectue);
					new ShowViewCommand(ViewNames.ConsultationGroupes.ToString()).Execute(null);
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

		private bool IsValidForSaving(Groupe itemToSave, out List<string> errorsList) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionGroupesServices>();

			errorsList = new List<string>();

			if (string.IsNullOrWhiteSpace(itemToSave.Libelle)) {
				errorsList.Add(Resources.Err_LibelleObligatoire);
			}

			if (itemToSave.HeureDebut == DateTime.MinValue) {
				errorsList.Add(Resources.Err_HeureDebutObligatoire);
			}

			if (itemToSave.HeureFin == DateTime.MinValue) {
				errorsList.Add(Resources.Err_HeureFinObligatoire);
			}

			if((itemToSave.HeureDebut.Hour > itemToSave.HeureFin.Hour)
				|| (itemToSave.HeureDebut.Hour == itemToSave.HeureFin.Hour && itemToSave.HeureDebut.Minute >= itemToSave.HeureFin.Minute)) {
					errorsList.Add(Resources.Err_HeureDebutHeureFin);
			}

			// on vérifie qu'il n'y a pas déjà un item différent (ID différent) mais avec le même couple libellé+créneau
			UIServices.SetBusyState();
			var itemExists = service.GetAllGroupes().Count(x => x.ToString() == itemToSave.ToString() && x.ID != itemToSave.ID) > 0;

			if (itemExists) {
				errorsList.Add(Resources.Err_GroupeExiste);
			}

			return errorsList.Count == 0;
		}
	}
}
