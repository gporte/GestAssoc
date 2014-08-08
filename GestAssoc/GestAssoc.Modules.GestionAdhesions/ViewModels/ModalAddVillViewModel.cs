using GestAssoc.Common.InteractionRequests;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Properties;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.ComponentModel;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdhesions.ViewModels
{
	public class ModalAddVillViewModel : Notification, INotifyPropertyChanged, IPopupWindowActionAware, IRegionManagerAware
	{
		private IGestionVillesServices _services;
		public ICommand SaveCmd { get; set; }
		public ICommand CancelCmd { get; set; }

		#region Item property
		public Ville Item { get; set; }
		#endregion

		public ModalAddVillViewModel() {
			this.Title = Resources.Titre_Vil_Formulaire;

			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IGestionVillesServices, GestionVillesServices>();

			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			this.Item = new Ville();

			this.SaveCmd = new DelegateCommand(this.OKAction);
			this.CancelCmd = new DelegateCommand(this.CancelAction);

			this.RaisePropertyChanged(string.Empty);
		}
		
		public event PropertyChangedEventHandler PropertyChanged;

		public System.Windows.Window HostWindow { get; set; }

		public INotification HostNotification { get; set; }

		public Microsoft.Practices.Prism.Regions.IRegionManager RegionManager { get; set; }

		// Actions
		protected void OKAction() {
			if (this._services.SaveVille(this.Item) && this.HostWindow != null) {
				this.HostWindow.Close();
			}
		}

		protected void CancelAction() {
			if (this.HostWindow != null) {
				this.HostWindow.Close();
			}
		}

		// INotifyPropertyChange implementation
		protected virtual void RaisePropertyChanged(string propertyName) {
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
