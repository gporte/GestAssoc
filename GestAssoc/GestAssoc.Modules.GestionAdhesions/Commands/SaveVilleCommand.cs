using GestAssoc.Common.Commands;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdhesions.Commands
{
	public class SaveVilleCommand : ICommand
	{
		public SaveVilleCommand() {}
		
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
				.Resolve<IGestionVillesServices>();

			var itemToSave = parameter as Ville;

			if (service.SaveVille(itemToSave)) {
				new ShowViewCommand(ViewNames.ConsultationVilles.ToString()).Execute(null);
			}
		}
	}
}
