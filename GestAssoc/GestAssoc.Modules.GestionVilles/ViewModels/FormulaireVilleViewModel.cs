using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionVilles.Commands;
using GestAssoc.Modules.GestionVilles.Constantes;
using GestAssoc.Modules.GestionVilles.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionVilles.ViewModels
{
	public class FormulaireVilleViewModel : ViewModelBase
	{
		private IGestionVillesServices _services;
		public ICommand SaveCmd { get; set; }
		public ICommand CancelCmd { get; set; }

		#region Item property
		private Ville _item;
		public Ville Item {
			get { return this._item; }
			set {
				if (this._item != value) {
					this._item = value;
					this.RaisePropertyChangedEvent("Item");
				}
			}
		}
		#endregion

		#region Constructors
		public FormulaireVilleViewModel(Guid itemId) {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			if (itemId == Guid.Empty) {
				this.Item = new Ville();
			}
			else {
				UIServices.SetBusyState();
				this.Item = this._services.GetVille(itemId);
			}

			this.SaveCmd = new SaveVilleCommand();
			this.CancelCmd = new ShowViewCommand(ViewNames.ConsultationVilles.ToString());

			// trace
			NotificationHelper.WriteNotification("Affichage de la vue " + ViewNames.FormulaireVille.ToString());
		}
		#endregion
	}
}
