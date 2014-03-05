using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdherents.Commands;
using GestAssoc.Modules.GestionAdherents.Constantes;
using GestAssoc.Modules.GestionAdherents.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdherents.ViewModels
{
	public class FormulaireAdherentViewModel : ViewModelBase
	{
		private IGestionAdherentsServices _services;
		public ICommand SaveCmd { get; set; }
		public ICommand CancelCmd { get; set; }

		#region Item property
		private Adherent _item;
		public Adherent Item {
			get { return this._item; }
			set {
				if (this._item != value) {
					this._item = value;
					this.RaisePropertyChangedEvent("Item");
				}
			}
		}
		#endregion

		#region Sexe property
		private IDictionary<int, string> _sexes;
		public IDictionary<int, string> Sexes {
			get { return this._sexes; }
			set {
				if (this._sexes != value) {
					this._sexes = value;
					this.RaisePropertyChangedEvent("Sexes");
				}
			}
		}
		#endregion

		#region Constructors
		public FormulaireAdherentViewModel(Guid itemId) {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionAdherentsServices>();

			if (itemId == Guid.Empty) {
				this.Item = new Adherent();
			}
			else {
				UIServices.SetBusyState();
				this.Item = this._services.GetAdherent(itemId);
			}

			this.SaveCmd = new SaveAdherentCommand();
			this.CancelCmd = new ShowViewCommand(ViewNames.ConsultationAdherents.ToString());
			this.Sexes = this._services.GetSexes();

			// trace
			NotificationHelper.WriteNotification("Affichage de la vue " + ViewNames.FormulaireAdherent);
		}
		#endregion
	}
}
