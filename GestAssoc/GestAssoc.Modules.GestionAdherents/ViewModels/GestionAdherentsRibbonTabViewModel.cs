using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdherents.ViewModels
{
	public class GestionAdherentsRibbonTabViewModel : ViewModelBase
	{
		public ICommand ShowConsultationAdherentsCmd { get; set; }
		public ICommand ShowFormulaireCreationAdherentCmd { get; set; }

		public GestionAdherentsRibbonTabViewModel() {
			this.ShowConsultationAdherentsCmd = new ShowViewCommand(ViewNames.ConsultationAdherents);
			this.ShowFormulaireCreationAdherentCmd = new ShowViewCommand(ViewNames.FormulaireAdherent);

			// trace
			NotificationHelper.WriteNotification("Affichage du RibbonTab GestionAdherents");
		}
	}
}
