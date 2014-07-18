using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionAdhesions.Properties.Resources;

namespace GestAssoc.Modules.GestionAdhesions.Commands
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
					NotificationHelper.WriteLog(GlblRes.Log_Sai_NouvelleSaisonCourante + itemToSave.ToString());
					new ShowViewCommand(ViewNames.ConsultationSaisons.ToString()).Execute(null);
				}
				catch (Exception ex) {
					NotificationHelper.ShowError(ex);
				}
			}
		}
	}
}
