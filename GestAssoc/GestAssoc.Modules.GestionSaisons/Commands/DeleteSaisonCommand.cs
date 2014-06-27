﻿using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionSaisons.Constantes;
using GestAssoc.Modules.GestionSaisons.Properties;
using GestAssoc.Modules.GestionSaisons.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionSaisons.Properties.Resources;

namespace GestAssoc.Modules.GestionSaisons.Commands
{
	public class DeleteSaisonCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			var itemToDelete = parameter as Saison;

			return itemToDelete != null
				&& itemToDelete.Groupes.Count == 0;

		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionSaisonsServices>();

			var itemToDelete = parameter as Saison;

			try {
				UIServices.SetBusyState();
				service.DeleteSaison(itemToDelete);

				NotificationHelper.WriteLog(GlblRes.Log_ElementSupprime);

				// La saison la plus récente devient la saison courante
				UIServices.SetBusyState();
				var newSaisonCourante = service.GetAllSaisons().LastOrDefault();

				if (newSaisonCourante != null) {
					UIServices.SetBusyState();
					service.SetSaisonCourante(newSaisonCourante);
					NotificationHelper.WriteLog(Resources.Log_NouvelleSaisonCourante + newSaisonCourante.ToString());
				}
				else {
					NotificationHelper.WriteLog(GlblRes.Log_AucuneSaisonCourante);
				}

				new ShowViewCommand(ViewNames.ConsultationSaisons.ToString()).Execute(null);
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}
	}
}
