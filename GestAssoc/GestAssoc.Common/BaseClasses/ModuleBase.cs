using GestAssoc.Common.Constantes;
using System;

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
		protected string GetRegionName(RibbonTabRegion tabRegion) {
			switch (tabRegion) {
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
