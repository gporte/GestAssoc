using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInfosClub.Commands;
using GestAssoc.Modules.GestionInfosClub.Constantes;
using GestAssoc.Modules.GestionInfosClub.Properties;
using GestAssoc.Modules.GestionInfosClub.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionInfosClub.ViewModels
{
	public class FormulaireInfosClubViewModel : ViewModelBase
	{
		private IGestionInfosClubServices _services;
		public ICommand SaveCmd { get; set; }
		
		#region Item property
		private InfosClub _item;
		public InfosClub Item {
			get { return this._item; }
			set {
				this.SetProperty(ref this._item, value);
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

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public FormulaireInfosClubViewModel() {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IGestionInfosClubServices, GestionInfosClubServices>();
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionInfosClubServices>();

			try {
				UIServices.SetBusyState();
				this.Item = this._services.GetInfosClub();
				this.Villes = this._services.GetAllVilles();
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}

			this.SaveCmd = new SaveFormulaireInfosClubCommand();

			// trace
			NotificationHelper.WriteNotification(Resources.Log_AffichageVue + ViewNames.FormulaireInfosClub.ToString());
		}
	}
}
