using GestAssoc.Modules.GestionSaisons.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionSaisons.Views
{
	/// <summary>
	/// Logique d'interaction pour FormulaireSaisonView.xaml
	/// </summary>
	public partial class FormulaireSaisonView : UserControl, INavigationAware, IRegionMemberLifetime
	{
		public FormulaireSaisonView() {
			InitializeComponent();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) {
			return false;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext) {
			
		}

		public void OnNavigatedTo(NavigationContext navigationContext) {
			var itemId = navigationContext.Parameters["ItemId"].ToString();
			var parseItemId = Guid.Empty;
			Guid.TryParse(itemId, out parseItemId);

			this.DataContext = new FormulaireSaisonViewModel(parseItemId);
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
