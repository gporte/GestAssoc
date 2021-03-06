﻿using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Commands;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdhesions.ViewModels
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
				this.SetProperty(ref this._item, value);
			}
		}
		#endregion

		#region Adherents property
		private ObservableCollection<Adherent> _adherents;
		public ObservableCollection<Adherent> Adherents {
			get { return this._adherents; }
			set {
				this.SetProperty(ref this._adherents, value);
			}
		}
		#endregion

		#region Groupes property
		private ObservableCollection<Groupe> _groupes;
		public ObservableCollection<Groupe> Groupes {
			get { return this._groupes; }
			set {
				this.SetProperty(ref this._groupes, value);
			}
		}
		#endregion

		#region Statuts property
		private IDictionary<int, string> _statuts;
		public IDictionary<int, string> Statuts {
			get { return this._statuts; }
			set {
				this.SetProperty(ref this._statuts, value);
			}
		}
		#endregion

		#region Constructors
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public FormulaireInscriptionViewModel(Guid itemId) {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IGestionInscriptionsServices, GestionInscriptionServices>();

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

			this.Statuts = this._services.GetStatuts();

			// trace
			NotificationHelper.WriteLog(Properties.Resources.Log_AffichageVue + ViewNames.FormulaireInscription);
		}
		#endregion
	}
}
