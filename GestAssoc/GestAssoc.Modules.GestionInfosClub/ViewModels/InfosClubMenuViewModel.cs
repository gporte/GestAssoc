using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionInfosClub.Constantes;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionInfosClub.Properties.Resources;

namespace GestAssoc.Modules.GestionInfosClub.ViewModels
{
	public class InfosClubMenuViewModel : ViewModelBase
	{
		public ICommand ShowDetailsInfosClub { get; set; }
		public ICommand ShowFormulaireInfosClub { get; set; }

		public InfosClubMenuViewModel() {
			this.ShowDetailsInfosClub = new ShowViewCommand(ViewNames.ConsultationInfosClub.ToString());
			this.ShowFormulaireInfosClub = new ShowViewCommand(ViewNames.FormulaireInfosClub.ToString());

			// trace
			NotificationHelper.WriteNotification(GlblRes.Log_AffichageMenu);
		}
	}
}
