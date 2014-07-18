using GestAssoc.Modules.GestionAdhesions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionAdhesions.Views
{
	/// <summary>
	/// Logique d'interaction pour ConsultationAdherentsView.xaml
	/// </summary>
	public partial class ConsultationAdherentsView : UserControl, IRegionMemberLifetime
	{
		public ConsultationAdherentsView() {
			InitializeComponent();
			this.DataContext = new ConsultationAdherentsViewModel();
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
