﻿using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInfosClub.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionInfosClub.Commands
{
	public class SaveFormulaireInfosClubCommand : ICommand
	{
		public bool CanExecute(object parameter) {
			return true;
		}

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter) {
			var service = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionInfosClubServices>();

			var itemToSave = parameter as InfosClub;
			itemToSave.Ville_ID = itemToSave.Ville.ID;

			try {
				service.SaveInfosClub(itemToSave);
				new ShowViewCommand(ViewNames.ConsultationInfosClub).Execute(null);
			}
			catch (Exception) {				
				throw;
			}
			
		}
	}
}
