using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionVilles.ViewModels
{
	public class GestionVillesRibbonTabViewModel : ViewModelBase
	{
		public ICommand ShowConsultationVillesView { get; set; }
		public ICommand ShowFormulaireVilleCreation { get; set; }

		public GestionVillesRibbonTabViewModel() {
			this.ShowConsultationVillesView = new ShowViewCommand(ViewNames.ConsultationVilles);
			this.ShowFormulaireVilleCreation = new ShowViewCommand(ViewNames.FormulaireVille);
		}
	}
}
