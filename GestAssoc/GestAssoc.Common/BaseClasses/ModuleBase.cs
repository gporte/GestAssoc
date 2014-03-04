using GestAssoc.Common.Constantes;

namespace GestAssoc.Common.BaseClasses
{
	public enum RibbonTabRegion
	{
		Inscriptions,
		Referentiel,
		Autres
	};
	
	public abstract class ModuleBase
	{
		protected RibbonTabRegion TabRegion { get; set; }

		protected ModuleBase() {
			this.TabRegion = RibbonTabRegion.Autres;
		}

		protected string GetRegionName() {
			switch (this.TabRegion) {
				case RibbonTabRegion.Inscriptions:
					return RegionNames.RibbonTabInscriptionsRegion;

				case RibbonTabRegion.Referentiel:
					return RegionNames.RibbonTabReferentielRegion;

				case RibbonTabRegion.Autres:
				default:
					return RegionNames.RibbonTabAutreRegion;
			}
		}
	}
}
