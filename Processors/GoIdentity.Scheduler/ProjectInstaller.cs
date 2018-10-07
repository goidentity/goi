using System.ComponentModel;

namespace GoIdentity.Scheduler
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();            
        }
    }
}
