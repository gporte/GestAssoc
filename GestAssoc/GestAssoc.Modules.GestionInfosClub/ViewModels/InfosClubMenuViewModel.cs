using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionInfosClub.ViewModels
{
	public class InfosClubMenuViewModel : ViewModelBase
	{
		public ICommand ShowDetailsInfosClub { get; set; }
		public ICommand ShowFormulaireInfosClub { get; set; }

		public InfosClubMenuViewModel() {
			this.ShowDetailsInfosClub = new ShowViewCommand(ViewNames.ConsultationInfosClub);
			this.ShowFormulaireInfosClub = new ShowViewCommand(ViewNames.FormulaireInfosClub);

			// trace
			NotificationHelper.WriteNotification("Affichage du RibbonTab GestionClub");
		}
	}
}
