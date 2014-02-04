using GestAssoc.Modules.GestionInfosClub.ViewModels;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionInfosClub.Views
{
	/// <summary>
	/// Logique d'interaction pour InfosClubView.xaml
	/// </summary>
	public partial class InfosClubView : UserControl
	{
		public InfosClubView(InfosClubViewModel vm) {
			InitializeComponent();
			this.DataContext = vm;
		}
	}
}
