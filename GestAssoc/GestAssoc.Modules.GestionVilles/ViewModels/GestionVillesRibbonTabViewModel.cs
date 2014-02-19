using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionVilles.ViewModels
{
	public class GestionVillesRibbonTabViewModel : ViewModelBase
	{
		public ICommand ShowConsultationVillesCmd { get; set; }
		public ICommand ShowFormulaireCreationVilleCmd { get; set; }

		public GestionVillesRibbonTabViewModel() {
			this.ShowConsultationVillesCmd = new ShowViewCommand(ViewNames.ConsultationVilles);
			this.ShowFormulaireCreationVilleCmd = new ShowViewCommand(ViewNames.FormulaireVille);
		}
	}
}
