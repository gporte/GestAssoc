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
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdhesions.ViewModels
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
				this.SetProperty(ref this._item, value);
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
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.FormulaireSaison.ToString());
		}
		#endregion
	}
}
