using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdherents.Commands;
using GestAssoc.Modules.GestionAdherents.Constantes;
using GestAssoc.Modules.GestionAdherents.Properties;
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
				this.SetProperty(ref this._item, value);
			}
		}
		#endregion

		#region Sexe property
		private IDictionary<int, string> _sexes;
		public IDictionary<int, string> Sexes {
			get { return this._sexes; }
			set {
				this.SetProperty(ref this._sexes, value);
			}
		}
		#endregion

		#region Villes property
		private ObservableCollection<Ville> _villes;
		public ObservableCollection<Ville> Villes {
			get { return this._villes; }
			set {
				this.SetProperty(ref this._villes, value);
			}
		}
		#endregion

		#region Constructors
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public FormulaireAdherentViewModel(Guid itemId) {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>()
				.RegisterType<IGestionAdherentsServices, GestionAdherentsServices>();

			this._services = ServiceLocator.Current.GetInstance<IUnityContainer>().Resolve<IGestionAdherentsServices>();

			try {
				if (itemId == Guid.Empty) {
					this.Item = new Adherent()
					{
						DateNaissance = DateTime.Today,
						DateCreation = DateTime.Today,
						DateModification = DateTime.Today
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
			NotificationHelper.WriteNotification(Resources.Log_AffichageVue + ViewNames.FormulaireAdherent);
		}
		#endregion
	}
}
