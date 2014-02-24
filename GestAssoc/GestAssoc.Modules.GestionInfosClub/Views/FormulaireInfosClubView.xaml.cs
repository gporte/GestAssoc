using GestAssoc.Modules.GestionInfosClub.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionInfosClub.Views
{
	/// <summary>
	/// Logique d'interaction pour FormulaireInfosClubView.xaml
	/// </summary>
	public partial class FormulaireInfosClubView : UserControl, IRegionMemberLifetime
	{
		public FormulaireInfosClubView() {
			InitializeComponent();
			this.DataContext = new FormulaireInfosClubViewModel();
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
