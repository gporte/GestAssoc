using GestAssoc.Modules.GestionInfosClub.ViewModels;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionInfosClub.Views
{
	/// <summary>
	/// Logique d'interaction pour FormulaireInfosClubView.xaml
	/// </summary>
	public partial class FormulaireInfosClubView : UserControl
	{
		public FormulaireInfosClubView() {
			InitializeComponent();
			this.DataContext = new FormulaireInfosClubViewModel();
		}
	}
}
