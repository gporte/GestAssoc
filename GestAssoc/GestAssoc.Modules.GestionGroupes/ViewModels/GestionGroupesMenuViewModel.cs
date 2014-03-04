using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionGroupes.ViewModels
{
	public class GestionGroupesMenuViewModel : ViewModelBase
	{
		public ICommand ShowConsultationGroupesCmd { get; set; }
		public ICommand ShowFormulaireCreationGroupeCmd { get; set; }

		public GestionGroupesMenuViewModel() {
			this.ShowConsultationGroupesCmd = new ShowViewCommand(ViewNames.ConsultationGroupes);
			this.ShowFormulaireCreationGroupeCmd = new ShowViewCommand(ViewNames.FormulaireGroupe);

			// trace
			NotificationHelper.WriteNotification("Affichage du RibbonTab GestionGroupes");
		}
	}
}
