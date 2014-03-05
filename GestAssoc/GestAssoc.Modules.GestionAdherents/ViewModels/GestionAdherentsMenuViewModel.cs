using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionAdherents.Constantes;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdherents.ViewModels
{
	public class GestionAdherentsMenuViewModel : ViewModelBase
	{
		public ICommand ShowConsultationAdherentsCmd { get; set; }
		public ICommand ShowFormulaireCreationAdherentCmd { get; set; }

		public GestionAdherentsMenuViewModel() {
			this.ShowConsultationAdherentsCmd = new ShowViewCommand(ViewNames.ConsultationAdherents.ToString());
			this.ShowFormulaireCreationAdherentCmd = new ShowViewCommand(ViewNames.FormulaireAdherent.ToString());

			// trace
			NotificationHelper.WriteNotification("Affichage du RibbonTab GestionAdherents");
		}
	}
}
