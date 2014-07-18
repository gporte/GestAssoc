using GestAssoc.Modules.GestionAdhesions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestAssoc.Modules.GestionAdhesions.Views
{
	/// <summary>
	/// Logique d'interaction pour ConsultationSaisonsView.xaml
	/// </summary>
	public partial class ConsultationSaisonsView : UserControl, IRegionMemberLifetime
	{
		public ConsultationSaisonsView() {
			InitializeComponent();
			this.DataContext = new ConsultationSaisonsViewModel();
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
