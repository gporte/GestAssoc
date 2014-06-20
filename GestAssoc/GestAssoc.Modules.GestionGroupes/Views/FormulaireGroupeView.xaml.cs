using GestAssoc.Modules.GestionGroupes.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionGroupes.Views
{
	/// <summary>
	/// Logique d'interaction pour FormulaireGroupeView.xaml
	/// </summary>
	public partial class FormulaireGroupeView : UserControl, INavigationAware, IRegionMemberLifetime
	{
		public FormulaireGroupeView() {
			InitializeComponent();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) {
			return false;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext) {
			
		}

		public void OnNavigatedTo(NavigationContext navigationContext) {
			var itemId = navigationContext.Parameters["ItemId"] ?? string.Empty;
			var parseItemId = Guid.Empty;
			Guid.TryParse(itemId.ToString(), out parseItemId);

			this.DataContext = new FormulaireGroupeViewModel(parseItemId);
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
