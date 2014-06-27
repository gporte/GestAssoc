using GestAssoc.ViewModels;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Views
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class ShellWindow : RibbonWindow
	{
		public ShellWindow(ShellWindowViewModel vm) {
			InitializeComponent();
			this.DataContext = vm;
		}
	}
}
