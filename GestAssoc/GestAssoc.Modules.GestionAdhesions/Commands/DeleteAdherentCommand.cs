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
	public class DeleteAdherentCommand : ICommand
	{
		public InteractionRequest<IConfirmation> RqConfirmDelete { get; private set; }
		private Action _commandCallBack;

		public DeleteAdherentCommand(Action callback) {
			this.RqConfirmDelete = new InteractionRequest<IConfirmation>();
			this._commandCallBack = callback;
		}
		
		public bool CanExecute(object parameter) {
			var itemToDelete = parameter as Adherent;

			return itemToDelete != null
				&& itemToDelete.Inscriptions.Count == 0;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			this.RqConfirmDelete.Raise(
				new Confirmation
				{
					Content = Resources.Confirm_SuppressionAdherent + Environment.NewLine + (parameter as Adherent).ToString(),
					Title = Common.Properties.Resources.Titre_Confirmation
				},
				c => this.ExecuteCallback(c.Confirmed, parameter as Adherent)
			);
		}

		private void ExecuteCallback(bool deleteConfirmed, Adherent itemToDelete) {
			if (deleteConfirmed) {
				var service = ServiceLocator
					.Current.GetInstance<IUnityContainer>()
					.Resolve<IGestionAdherentsServices>();

				try {
					UIServices.SetBusyState();
					service.DeleteAdherent(itemToDelete);

					NotificationHelper.WriteLog(Resources.Log_EnregistrementSupprime);

					this._commandCallBack();
				}
				catch (Exception ex) {
					NotificationHelper.ShowError(ex);
				}
			}
		}
	}
}
