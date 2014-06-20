using GestAssoc.Modules.GestionInscriptions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionInscriptions.Views
{
	/// <summary>
	/// Logique d'interaction pour FormulaireInscriptionView.xaml
	/// </summary>
	public partial class FormulaireInscriptionView : UserControl, INavigationAware, IRegionMemberLifetime
	{
		public FormulaireInscriptionView() {
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

			this.DataContext = new FormulaireInscriptionViewModel(parseItemId);
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
