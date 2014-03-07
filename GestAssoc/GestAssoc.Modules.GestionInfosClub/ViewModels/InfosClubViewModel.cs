using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInfosClub.Constantes;
using GestAssoc.Modules.GestionInfosClub.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;

namespace GestAssoc.Modules.GestionInfosClub.ViewModels
{
	public class InfosClubViewModel : ViewModelBase
	{
		private IGestionInfosClubServices _services;

		public ShowViewCommandWithParameter ShowEditViewCmd { get; set; }

		#region Item property
		private InfosClub _item;
		public InfosClub Item {
			get { return this._item; }
			set {
				if (this._item != value) {
					this._item = value;
					this.RaisePropertyChangedEvent("Item");
				}
			}
		}
		#endregion

		public InfosClubViewModel() {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionInfosClubServices>();

			this.ShowEditViewCmd = new ShowViewCommandWithParameter(ViewNames.FormulaireInfosClub.ToString());

			try {
				UIServices.SetBusyState();
				this.Item = this._services.GetInfosClub();
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}

			// trace
			NotificationHelper.WriteNotification("Affichage de la vue " + ViewNames.ConsultationInfosClub.ToString());
		}
	}
}
