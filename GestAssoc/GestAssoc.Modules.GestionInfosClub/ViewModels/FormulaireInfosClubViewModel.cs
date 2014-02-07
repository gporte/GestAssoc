using GestAssoc.Common.BaseClasses;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInfosClub.Commands;
using GestAssoc.Modules.GestionInfosClub.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
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
				if (this._item != value) {
					this._item = value;
					this.RaisePropertyChangedEvent("Item");
				}
			}
		}
		#endregion

		public FormulaireInfosClubViewModel() {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionInfosClubServices>();

			this.Item = this._services.GetInfosClub();

			this.SaveCmd = new SaveFormulaireInfosClubCommand();
		}
	}
}
