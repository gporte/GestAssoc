using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionSaisons.Commands;
using GestAssoc.Modules.GestionSaisons.Constantes;
using GestAssoc.Modules.GestionSaisons.Properties;
using GestAssoc.Modules.GestionSaisons.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionSaisons.ViewModels
{
	public class FormulaireSaisonViewModel : ViewModelBase
	{
		private IGestionSaisonsServices _services;
		public ICommand SaveCmd { get; set; }
		public ICommand CancelCmd { get; set; }

		#region Item property
		private Saison _item;
		public Saison Item {
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
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public FormulaireSaisonViewModel(Guid itemId) {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IGestionSaisonsServices, GestionSaisonsServices>();

			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionSaisonsServices>();

			if (itemId == Guid.Empty) {
				var now = DateTime.Today;

				this.Item = new Saison()
				{
					AnneeDebut = now.Year,
					AnneeFin = now.AddYears(1).Year
				};
			}
			else {
				try {
					UIServices.SetBusyState();
					this.Item = this._services.GetSaison(itemId);
				}
				catch (Exception ex) {
					NotificationHelper.ShowError(ex);
				}
			}

			this.SaveCmd = new SaveSaisonCommand();
			this.CancelCmd = new ShowViewCommand(ViewNames.ConsultationSaisons.ToString());

			// trace
			NotificationHelper.WriteNotification(Resources.Log_AffichageVue + ViewNames.FormulaireSaison.ToString());
		}
		#endregion
	}
}
