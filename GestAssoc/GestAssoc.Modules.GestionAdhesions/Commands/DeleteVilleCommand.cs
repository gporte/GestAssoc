﻿using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionAdhesions.Properties.Resources;

namespace GestAssoc.Modules.GestionAdhesions.Commands
{
	public class DeleteVilleCommand : ICommand
	{
		public InteractionRequest<IConfirmation> RqConfirmDelete { get; private set; }
		private Action _commandCallBack;

		public DeleteVilleCommand(Action callback) {
			this.RqConfirmDelete = new InteractionRequest<IConfirmation>();
			this._commandCallBack = callback;
		}

		public bool CanExecute(object parameter) {
			var itemToDelete = parameter as Ville;

			return itemToDelete != null 
				&& itemToDelete.Adherents.Count == 0 
				&& itemToDelete.InfosClubs.Count == 0;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			this.RqConfirmDelete.Raise(
				new Confirmation 
				{ 
					Content=GlblRes.Confirm_Vil_Suppression + Environment.NewLine + (parameter as Ville).ToString(), 
					Title=Common.Properties.Resources.Titre_Confirmation
				},
				c => this.ExecuteCallback(c.Confirmed, parameter as Ville)
			);
		}

		private void ExecuteCallback(bool deleteConfirmed, Ville itemToDelete) {
			if(deleteConfirmed) {
				var service = ServiceLocator
					.Current.GetInstance<IUnityContainer>()
					.Resolve<IGestionVillesServices>();

				try {
					UIServices.SetBusyState();
					service.DeleteVille(itemToDelete);

					NotificationHelper.WriteLog(GlblRes.Log_Vil_EnregistrementSupprime);

					this._commandCallBack();
				}
				catch (Exception ex) {
					NotificationHelper.ShowError(ex);
				}
			}
		}
	}
}
