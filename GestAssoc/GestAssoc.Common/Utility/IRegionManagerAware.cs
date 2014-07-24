using Microsoft.Practices.Prism.Regions;

namespace GestAssoc.Common.Utility
{
	public interface IRegionManagerAware
	{
		IRegionManager RegionManager { get; set; }
	}
}
