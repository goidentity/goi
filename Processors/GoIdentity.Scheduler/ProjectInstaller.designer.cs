
namespace GoIdentity.Scheduler
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.goIdentityInstaller = new System.ServiceProcess.ServiceInstaller();
            this.goIdentityProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // goIdentityInstaller
            // 
            this.goIdentityInstaller.Description = "GoIdentity Hosts all Scheduled Jobs";
            this.goIdentityInstaller.DisplayName = "GoIdentity – Scheduled Job";
            this.goIdentityInstaller.ServiceName = "GoIdentityJobServiceHost";
            this.goIdentityInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // goIdentityProcessInstaller
            // 
            this.goIdentityProcessInstaller.Password = null;
            this.goIdentityProcessInstaller.Username = null;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.goIdentityInstaller,
            this.goIdentityProcessInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceInstaller goIdentityInstaller;
        private System.ServiceProcess.ServiceProcessInstaller goIdentityProcessInstaller;
    }
}