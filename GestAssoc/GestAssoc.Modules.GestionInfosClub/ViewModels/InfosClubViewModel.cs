using GestAssoc.Common.BaseClasses;
using GestAssoc.Model.Interfaces;
using GestAssoc.Model.Models;
using GestAssoc.Model.Services;

namespace GestAssoc.Modules.GestionInfosClub.ViewModels
{
	public class InfosClubViewModel : ViewModelBase
	{
		private IGestionInfosClubServices _services = new GestionInfosClubServices();
		
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
			this.Item = this._services.GetInfosClub();
		}
	}
}
