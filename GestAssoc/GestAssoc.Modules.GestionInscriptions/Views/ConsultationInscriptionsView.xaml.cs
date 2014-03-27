using GestAssoc.Modules.GestionInscriptions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionInscriptions.Views
{
	/// <summary>
	/// Logique d'interaction pour ConsultationInscriptionsView.xaml
	/// </summary>
	public partial class ConsultationInscriptionsView : UserControl, IRegionMemberLifetime
	{
		public ConsultationInscriptionsView() {
			InitializeComponent();
			this.DataContext = new ConsultationInscriptionsViewModel();
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
