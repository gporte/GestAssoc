using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Properties;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdhesions.ViewModels
{
	public class FormulaireVilleViewModel : ViewModelBase
	{
		private IGestionVillesServices _services;
		public ICommand SaveCmd { get; set; }
		public ICommand CancelCmd { get; set; }

		#region Item property
		private Ville _item;
		public Ville Item {
			get { return this._item; }
			set {
				this.SetProperty(ref this._item, value);
			}
		}
		#endregion

		#region Constructors
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public FormulaireVilleViewModel(Guid itemId) : base() {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IGestionVillesServices, GestionVillesServices>();

			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			if (itemId == Guid.Empty) {
				this.Item = new Ville();
			}
			else {
				try {
					UIServices.SetBusyState();
					this.Item = this._services.GetVille(itemId);
				}
				catch (Exception ex) {
					NotificationHelper.ShowError(ex);
				}
			}

			this.SaveCmd = new DelegateCommand<Ville>(
				(vil) => this.ExecuteSave(vil)
			);

			this.CancelCmd = new ShowViewCommand(ViewNames.ConsultationVilles.ToString());

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.FormulaireVille.ToString());
		}
		#endregion

		private void ExecuteSave(Ville ville) {
			if (this._services.SaveVille(ville)) {
				new ShowViewCommand(ViewNames.ConsultationVilles.ToString()).Execute(null);
			}
		}
	}
}
