namespace CooperativaIT.Module.Controllers
{
    partial class TotalSocios
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
            this.popupSocios = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // popupSocios
            // 
            this.popupSocios.AcceptButtonCaption = null;
            this.popupSocios.CancelButtonCaption = null;
            this.popupSocios.Caption = "Ingreso Masivo";
            this.popupSocios.ConfirmationMessage = null;
            this.popupSocios.Id = "c7bc2f74-2e3d-4aa3-8836-448be745de47";
            this.popupSocios.TargetObjectType = typeof(CooperativaIT.Module.Clases.FondosEncab);
            this.popupSocios.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.popupSocios.ToolTip = null;
            this.popupSocios.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.popupSocios.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.popupSocios_CustomizePopupWindowParams);
            this.popupSocios.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.popupSocios_Execute);
            // 
            // TotalSocios
            // 
            this.Actions.Add(this.popupSocios);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction popupSocios;
    }
}
