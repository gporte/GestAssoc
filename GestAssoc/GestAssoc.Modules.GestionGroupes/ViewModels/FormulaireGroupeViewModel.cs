using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionGroupes.Commands;
using GestAssoc.Modules.GestionGroupes.Constantes;
using GestAssoc.Modules.GestionGroupes.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionGroupes.ViewModels
{
	public class FormulaireGroupeViewModel : ViewModelBase
	{
		private IGestionGroupesServices _services;
		public ICommand SaveCmd { get; set; }
		public ICommand CancelCmd { get; set; }

		#region Item property
		private Groupe _item;
		public Groupe Item {
			get { return this._item; }
			set {
				if (this._item != value) {
					this._item = value;
					this.RaisePropertyChangedEvent("Item");
				}
			}
		}
		#endregion

		#region JoursSemaine property
		private IDictionary<int, string> _joursSemaine;
		public IDictionary<int, string> JoursSemaine {
			get { return this._joursSemaine; }
			set {
				if (this._joursSemaine != value) {
					this._joursSemaine = value;
					this.RaisePropertyChangedEvent("JoursSemaine");
				}
			}
		}
		#endregion

		#region Constructors
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public FormulaireGroupeViewModel(Guid itemId) {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionGroupesServices>();

			try {
				if (itemId == Guid.Empty) {
					this.Item = new Groupe()
					{
						Saison = this._services.GetSaisonCourante(),
						HeureDebut = DefaultValueHelper.DateTimeSQLMinValue,
						HeureFin = DefaultValueHelper.DateTimeSQLMinValue
					};
				}
				else {
					UIServices.SetBusyState();
					this.Item = this._services.GetGroupe(itemId);
				}

				this.JoursSemaine = this._services.GetJoursSemaine();
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}

			this.SaveCmd = new SaveGroupeCommand();
			this.CancelCmd = new ShowViewCommand(ViewNames.ConsultationGroupes.ToString());

			// trace
			NotificationHelper.WriteNotification("Affichage de la vue " + ViewNames.FormulaireGroupe);
		}
		#endregion
	}
}
