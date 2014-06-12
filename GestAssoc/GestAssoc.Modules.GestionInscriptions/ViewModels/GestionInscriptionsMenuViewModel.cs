using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionInscriptions.Constantes;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionInscriptions.ViewModels
{
	public class GestionInscriptionsMenuViewModel : ViewModelBase
	{
		public ICommand ShowConsultationInscriptionsCmd { get; set; }
		public ICommand ShowFormulaireCreationInscriptionCmd { get; set; }

		public GestionInscriptionsMenuViewModel() {
			this.ShowConsultationInscriptionsCmd = new ShowViewCommand(ViewNames.ConsultationInscriptions.ToString());
			this.ShowFormulaireCreationInscriptionCmd = new ShowViewCommand(ViewNames.FormulaireInscription.ToString());

			// trace
			NotificationHelper.WriteNotification(Properties.Resources.Log_AffichageMenu);
		}
	}
}
