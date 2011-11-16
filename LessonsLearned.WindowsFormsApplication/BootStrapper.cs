using System.Windows.Forms;
using StructureMap;
using Microsoft.Practices.ServiceLocation;
using StructureMap.ServiceLocatorAdapter;

namespace LessonsLearned.WindowsFormsApplication
{
    public class BootStrapper
    {

        private IContainer Container { get; set; }

        public BootStrapper(IContainer container)
        {
            Container = container;
        }

        public ApplicationContext GetAppContext()
        {
            Container.Configure(c => c.AddRegistry<DefaultRegistry>());
            var smServiceLocator = new StructureMapServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => smServiceLocator);
            Container.Inject(ServiceLocator.Current);
            return Container.GetInstance<ApplicationContext>();
        }

    }
}