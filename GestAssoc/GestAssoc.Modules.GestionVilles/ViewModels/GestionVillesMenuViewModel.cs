using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionVilles.ViewModels
{
	public class GestionVillesMenuViewModel : ViewModelBase
	{
		public ICommand ShowConsultationVillesCmd { get; set; }
		public ICommand ShowFormulaireCreationVilleCmd { get; set; }

		public GestionVillesMenuViewModel() {
			this.ShowConsultationVillesCmd = new ShowViewCommand(ViewNames.ConsultationVilles);
			this.ShowFormulaireCreationVilleCmd = new ShowViewCommand(ViewNames.FormulaireVille);

			// trace
			NotificationHelper.WriteNotification("Affichage du RibbonTab GestionVilles");
		}
	}
}
