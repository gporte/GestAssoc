using GestAssoc.Modules.DataAccesLayer.Interfaces;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.DataAccesLayer
{
	public class ModuleDataAccessLayer : IModule
	{
		public void Initialize() {
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
			container.RegisterType<object, IGestionVillesServices>(typeof(IGestionVillesServices).Name);
		}
	}
}
