using GestAssoc.Modules.GestionAdhesions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionAdhesions.Views
{
	/// <summary>
	/// Logique d'interaction pour ConsultationGroupesView.xaml
	/// </summary>
	public partial class ConsultationGroupesView : UserControl, IRegionMemberLifetime
	{
		public ConsultationGroupesView() {
			InitializeComponent();
			this.DataContext = new ConsultationGroupesViewModel();
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
