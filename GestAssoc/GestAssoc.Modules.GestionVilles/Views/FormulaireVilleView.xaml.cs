using GestAssoc.Modules.GestionVilles.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionVilles.Views
{
	/// <summary>
	/// Logique d'interaction pour FormulaireVilleView.xaml
	/// </summary>
	public partial class FormulaireVilleView : UserControl, INavigationAware, IRegionMemberLifetime
	{
		public FormulaireVilleView() {
			InitializeComponent();
		}

		public void OnNavigatedTo(NavigationContext navigationContext) {
			var itemId = navigationContext.Parameters["ItemId"] ?? string.Empty;
			var parseItemId = Guid.Empty;
			Guid.TryParse(itemId.ToString(), out parseItemId);

			this.DataContext = new FormulaireVilleViewModel(parseItemId);
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) {
			return false;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext) {
			
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
