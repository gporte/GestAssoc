using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionSaisons.Constantes;
using GestAssoc.Modules.GestionSaisons.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionSaisons.Properties.Resources;

namespace GestAssoc.Modules.GestionSaisons.Commands
{
	public class ChangeSaisonCouranteCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			return parameter != null 
				&& !(parameter as Saison).EstSaisonCourante;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			var itemToSave = parameter as Saison;

			if (itemToSave != null && !itemToSave.EstSaisonCourante) {
				var service = ServiceLocator
					.Current.GetInstance<IUnityContainer>()
					.Resolve<IGestionSaisonsServices>();

				try {
					UIServices.SetBusyState();
					service.SetSaisonCourante(itemToSave);
					NotificationHelper.WriteNotification(GlblRes.Log_NouvelleSaisonCourante + itemToSave.ToString());
					new ShowViewCommand(ViewNames.ConsultationSaisons.ToString()).Execute(null);
				}
				catch (Exception ex) {
					NotificationHelper.ShowError(ex);
				}
			}
		}
	}
}
