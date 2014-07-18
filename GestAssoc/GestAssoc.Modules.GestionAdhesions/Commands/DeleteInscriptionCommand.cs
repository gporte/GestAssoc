using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Properties;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdhesions.Commands
{
	public class DeleteInscriptionCommand : ICommand
	{
		public InteractionRequest<IConfirmation> RqConfirmDelete { get; private set; }
		private Action _commandCallBack;

		public DeleteInscriptionCommand(Action callback) {
			this.RqConfirmDelete = new InteractionRequest<IConfirmation>();
			this._commandCallBack = callback;
		}
		
		public bool CanExecute(object parameter) {
			return true;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			this.RqConfirmDelete.Raise(
				new Confirmation
				{
					Content = Resources.Confirm_Ins_Suppression + Environment.NewLine + (parameter as Inscription).ToString(),
					Title = Common.Properties.Resources.Titre_Confirmation
				},
				c => this.ExecuteCallback(c.Confirmed, parameter as Inscription)
			);
		}

		private void ExecuteCallback(bool deleteConfirmed, Inscription itemToDelete) {
			if (deleteConfirmed) {
				var service = ServiceLocator
					.Current.GetInstance<IUnityContainer>()
					.Resolve<IGestionInscriptionsServices>();

				try {
					UIServices.SetBusyState();
					service.DeleteInscription(itemToDelete);

					NotificationHelper.WriteLog(Resources.Log_Ins_EnregistrementSupprime);

					this._commandCallBack();
				}
				catch (Exception ex) {
					NotificationHelper.ShowError(ex);
				}
			}
		}
	}
}
