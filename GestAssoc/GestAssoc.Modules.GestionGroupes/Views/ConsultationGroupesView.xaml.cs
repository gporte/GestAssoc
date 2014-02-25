using GestAssoc.Modules.GestionGroupes.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionGroupes.Views
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
