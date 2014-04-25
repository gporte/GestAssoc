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
using System.Collections.ObjectModel;
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

		#region Villes property
		private ObservableCollection<Ville> _villes;
		public ObservableCollection<Ville> Villes {
			get { return this._villes; }
			set {
				if (this._villes != value) {
					this._villes = value;
					this.RaisePropertyChangedEvent("Villes");
				}
			}
		}
		#endregion

		#region Constructors
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public FormulaireAdherentViewModel(Guid itemId) {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionAdherentsServices>();

			try {
				if (itemId == Guid.Empty) {
					this.Item = new Adherent()
					{
						DateNaissance = DefaultValueHelper.DateTimeSQLMinValue,
						DateCreation = DateTime.Now,
						DateModification = DateTime.Now
					};
				}
				else {
					UIServices.SetBusyState();
					this.Item = this._services.GetAdherent(itemId);
				}

				UIServices.SetBusyState();
				this.Villes = this._services.GetAllVilles();
				this.Sexes = this._services.GetSexes();
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}

			this.SaveCmd = new SaveAdherentCommand();
			this.CancelCmd = new ShowViewCommand(ViewNames.ConsultationAdherents.ToString());			

			// trace
			NotificationHelper.WriteNotification("Affichage de la vue " + ViewNames.FormulaireAdherent);
		}
		#endregion
	}
}
