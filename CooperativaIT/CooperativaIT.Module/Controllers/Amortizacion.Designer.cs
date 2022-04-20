namespace CooperativaIT.Module.Controllers
{
    partial class Amortizacion
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
            this.components = new System.ComponentModel.Container();
            this.TablaAmortizacion = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // TablaAmortizacion
            // 
            this.TablaAmortizacion.Caption = "7a2fe155-27d2-4fd9-8340-bb76ef0d3a9a";
            this.TablaAmortizacion.Category = "";
            this.TablaAmortizacion.ConfirmationMessage = null;
            this.TablaAmortizacion.Id = "7a2fe155-27d2-4fd9-8340-bb76ef0d3a9a";
            this.TablaAmortizacion.ToolTip = null;
            this.TablaAmortizacion.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.TablaAmortizacion_Execute);
            // 
            // Amortizacion
            // 
            this.Actions.Add(this.TablaAmortizacion);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction TablaAmortizacion;
    }
}
