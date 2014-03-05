using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionSaisons.Commands;
using GestAssoc.Modules.GestionSaisons.Constantes;
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
		public FormulaireSaisonViewModel(Guid itemId) {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionSaisonsServices>();

			if (itemId == Guid.Empty) {
				var now = DateTime.Now;

				this.Item = new Saison()
				{
					AnneeDebut = now.Year,
					AnneeFin = now.AddYears(1).Year
				};
			}
			else {
				UIServices.SetBusyState();
				this.Item = this._services.GetSaison(itemId);
			}

			this.SaveCmd = new SaveSaisonCommand();
			this.CancelCmd = new ShowViewCommand(ViewNames.ConsultationSaisons.ToString());

			// trace
			NotificationHelper.WriteNotification("Affichage de la vue " + ViewNames.FormulaireSaison.ToString());
		}
		#endregion
	}
}
