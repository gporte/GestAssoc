using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionGroupes.Properties;
using GestAssoc.Modules.GestionGroupes.Services;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionGroupes.Commands
{
	public class DeleteGroupeCommand : ICommand
	{
		public InteractionRequest<IConfirmation> RqConfirmDelete { get; private set; }
		private Action _commandCallBack;

		public DeleteGroupeCommand(Action callback) {
			this.RqConfirmDelete = new InteractionRequest<IConfirmation>();
			this._commandCallBack = callback;
		}
		
		public bool CanExecute(object parameter) {
			var itemToDelete = parameter as Groupe;

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
					Content = Resources.Confirm_SuppressionGroupe + Environment.NewLine + (parameter as Groupe).ToString(),
					Title = Common.Properties.Resources.Titre_Confirmation
				},
				c => this.ExecuteCallback(c.Confirmed, parameter as Groupe)
			);
		}

		private void ExecuteCallback(bool deleteConfirmed, Groupe itemToDelete) {
			if (deleteConfirmed) {
				var service = ServiceLocator
					.Current.GetInstance<IUnityContainer>()
					.Resolve<IGestionGroupesServices>();

				try {
					UIServices.SetBusyState();
					service.DeleteGroupe(itemToDelete);

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
