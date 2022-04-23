namespace CooperativaIT.Module.Controllers
{
    partial class CalculoInt
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
            this.CalcularInt = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.CrearPago = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // CalcularInt
            // 
            this.CalcularInt.Caption = "Calcular Interes";
            this.CalcularInt.ConfirmationMessage = null;
            this.CalcularInt.Id = "618775e5-5a2f-4d00-9917-54870b8f7c38";
            this.CalcularInt.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.CalcularInt.TargetObjectType = typeof(CooperativaIT.Module.Clases.EncabPagos);
            this.CalcularInt.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.CalcularInt.ToolTip = null;
            this.CalcularInt.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.CalcularInt.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CalcularInt_Execute);
            // 
            // CrearPago
            // 
            this.CrearPago.Caption = "Crear pago";
            this.CrearPago.ConfirmationMessage = "Desea crear el pago?";
            this.CrearPago.Id = "41d81864-ee23-4e35-a929-19faf8ea0b92";
            this.CrearPago.TargetObjectType = typeof(CooperativaIT.Module.Clases.Creditos);
            this.CrearPago.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.CrearPago.ToolTip = null;
            this.CrearPago.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.CrearPago.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CrearPago_Execute);
            // 
            // CalculoInt
            // 
            this.Actions.Add(this.CalcularInt);
            this.Actions.Add(this.CrearPago);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction CalcularInt;
        private DevExpress.ExpressApp.Actions.SimpleAction CrearPago;
    }
}
