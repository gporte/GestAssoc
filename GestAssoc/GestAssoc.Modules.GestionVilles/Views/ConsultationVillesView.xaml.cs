using GestAssoc.Modules.GestionVilles.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionVilles.Views
{
	/// <summary>
	/// Logique d'interaction pour ConsultationVillesView.xaml
	/// </summary>
	public partial class ConsultationVillesView : UserControl, IRegionMemberLifetime
	{
		public ConsultationVillesView() {
			InitializeComponent();
			this.DataContext = new ConsultationVillesViewModel();
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
