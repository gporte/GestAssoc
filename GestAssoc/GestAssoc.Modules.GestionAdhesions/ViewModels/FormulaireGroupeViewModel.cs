using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Commands;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Properties;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdhesions.ViewModels
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
				this.SetProperty(ref this._item, value);
			}
		}
		#endregion

		#region JoursSemaine property
		private IDictionary<int, string> _joursSemaine;
		public IDictionary<int, string> JoursSemaine {
			get { return this._joursSemaine; }
			set {
				this.SetProperty(ref this._joursSemaine, value);
			}
		}
		#endregion

		#region Constructors
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public FormulaireGroupeViewModel(Guid itemId) {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>()
				.RegisterType<IGestionGroupesServices, GestionGroupesServices>();

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
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.FormulaireGroupe);
		}
		#endregion
	}
}
