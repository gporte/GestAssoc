using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionVilles.Constantes;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionVilles.ViewModels
{
	public class GestionVillesMenuViewModel : ViewModelBase
	{
		public ICommand ShowConsultationVillesCmd { get; set; }
		public ICommand ShowFormulaireCreationVilleCmd { get; set; }

		public GestionVillesMenuViewModel() {
			this.ShowConsultationVillesCmd = new ShowViewCommand(ViewNames.ConsultationVilles.ToString());
			this.ShowFormulaireCreationVilleCmd = new ShowViewCommand(ViewNames.FormulaireVille.ToString());

			// trace
			NotificationHelper.WriteNotification("Affichage du RibbonTab GestionVilles");
		}
	}
}
