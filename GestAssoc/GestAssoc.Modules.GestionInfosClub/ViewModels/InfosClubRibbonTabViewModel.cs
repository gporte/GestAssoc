using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionInfosClub.ViewModels
{
	public class InfosClubRibbonTabViewModel : ViewModelBase
	{
		public ICommand ShowDetailsInfosClub { get; set; }
		public ICommand ShowFormulaireInfosClub { get; set; }

		public InfosClubRibbonTabViewModel() {
			this.ShowDetailsInfosClub = new ShowViewCommand(ViewNames.ConsultationInfosClub);
			this.ShowFormulaireInfosClub = new ShowViewCommand(ViewNames.FormulaireInfosClub);

			// trace
			NotificationHelper.WriteNotification("Initialisation du RibbonTab InfosClub.");
		}
	}
}
