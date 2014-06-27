using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInfosClub.Constantes;
using GestAssoc.Modules.GestionInfosClub.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using GlblRes = global::GestAssoc.Modules.GestionInfosClub.Properties.Resources;

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
				this.SetProperty(ref this._item, value);
			}
		}
		#endregion

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public InfosClubViewModel() {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IGestionInfosClubServices, GestionInfosClubServices>();
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
			NotificationHelper.WriteLog(GlblRes.Log_AffichageVue + ViewNames.ConsultationInfosClub.ToString());
		}
	}
}
