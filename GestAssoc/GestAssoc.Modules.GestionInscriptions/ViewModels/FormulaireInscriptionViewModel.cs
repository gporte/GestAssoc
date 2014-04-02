using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInscriptions.Commands;
using GestAssoc.Modules.GestionInscriptions.Constantes;
using GestAssoc.Modules.GestionInscriptions.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionInscriptions.ViewModels
{
	public class FormulaireInscriptionViewModel : ViewModelBase
	{
		private IGestionInscriptionsServices _services;
		public ICommand SaveCmd { get; set; }
		public ICommand CancelCmd { get; set; }

		#region Item property
		private Inscription _item;
		public Inscription Item {
			get { return this._item; }
			set {
				if (this._item != value) {
					this._item = value;
					this.RaisePropertyChangedEvent("Item");
				}
			}
		}
		#endregion

		#region Adherents property
		private ObservableCollection<Adherent> _adherents;
		public ObservableCollection<Adherent> Adherents {
			get { return this._adherents; }
			set {
				if (this._adherents != value) {
					this._adherents = value;
					this.RaisePropertyChangedEvent("Adherents");
				}
			}
		}
		#endregion

		#region Groupes property
		private ObservableCollection<Groupe> _groupes;
		public ObservableCollection<Groupe> Groupes {
			get { return this._groupes; }
			set {
				if (this._groupes != value) {
					this._groupes = value;
					this.RaisePropertyChangedEvent("Groupes");
				}
			}
		}
		#endregion

		#region Statuts property
		private ObservableCollection<int> _statuts;
		public ObservableCollection<int> Statuts {
			get { return this._statuts; }
			set {
				if (this._statuts != value) {
					this._statuts = value;
					this.RaisePropertyChangedEvent("Statuts");
				}
			}
		}
		#endregion

		#region Constructors
		public FormulaireInscriptionViewModel(Guid itemId) {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionInscriptionsServices>();

			try {
				if (itemId == Guid.Empty) {
					this.Item = new Inscription()
					{
						DateCreation = DateTime.Now,
						DateModification = DateTime.Now
					};
				}
				else {
					UIServices.SetBusyState();
					this.Item = this._services.GetInscription(itemId);
				}

				UIServices.SetBusyState();
				this.Adherents = this._services.GetAllAdherents();
				this.Groupes = this._services.GetAllGroupes();
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}

			this.SaveCmd = new SaveInscriptionCommand();
			this.CancelCmd = new ShowViewCommand(ViewNames.ConsultationInscriptions.ToString());

			this.Statuts = new ObservableCollection<int>(new List<int>() { 0, 1, 2 });

			// trace
			NotificationHelper.WriteNotification("Affichage de la vue " + ViewNames.FormulaireInscription);
		}
		#endregion
	}
}
