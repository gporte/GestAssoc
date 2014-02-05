using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using System.Windows.Input;

namespace GestAssoc.ViewModels
{
	public class ShellWindowViewModel : ViewModelBase
	{
		public ICommand ShowViewCmd { get; set; }

		public ShellWindowViewModel() {
			// TODO bouchon
			//this.ShowViewCmd = new ShowViewCommand();
			this.ShowViewCmd = new ShowViewCommandWithParameter("toto");
		}
	}
}
