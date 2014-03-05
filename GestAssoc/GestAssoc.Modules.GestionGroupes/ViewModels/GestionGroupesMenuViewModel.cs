using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionGroupes.Constantes;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionGroupes.ViewModels
{
	public class GestionGroupesMenuViewModel : ViewModelBase
	{
		public ICommand ShowConsultationGroupesCmd { get; set; }
		public ICommand ShowFormulaireCreationGroupeCmd { get; set; }

		public GestionGroupesMenuViewModel() {
			this.ShowConsultationGroupesCmd = new ShowViewCommand(ViewNames.ConsultationGroupes.ToString());
			this.ShowFormulaireCreationGroupeCmd = new ShowViewCommand(ViewNames.FormulaireGroupe.ToString());

			// trace
			NotificationHelper.WriteNotification("Affichage du RibbonTab GestionGroupes");
		}
	}
}
