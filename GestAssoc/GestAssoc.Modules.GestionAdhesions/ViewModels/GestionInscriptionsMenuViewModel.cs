using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdhesions.ViewModels
{
	public class GestionInscriptionsMenuViewModel : ViewModelBase
	{
		public ICommand ShowConsultationInscriptionsCmd { get; set; }
		public ICommand ShowFormulaireCreationInscriptionCmd { get; set; }

		public GestionInscriptionsMenuViewModel() {
			this.ShowConsultationInscriptionsCmd = new ShowViewCommand(ViewNames.ConsultationInscriptions.ToString());
			this.ShowFormulaireCreationInscriptionCmd = new ShowViewCommand(ViewNames.FormulaireInscription.ToString());

			// trace
			NotificationHelper.WriteLog(Properties.Resources.Log_Ins_AffichageMenu);
		}
	}
}
