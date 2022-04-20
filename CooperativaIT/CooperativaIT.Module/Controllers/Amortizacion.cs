using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using CooperativaIT.Module.Clases;

namespace CooperativaIT.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class Amortizacion : ViewController
    {
        public Amortizacion()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void TablaAmortizacion_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
          /*  Creditos objCurrent = (Creditos)e.CurrentObject;

            if (!ReferenceEquals(objCurrent,null))
            {

                decimal capitalOtorgado = objCurrent.CapitalOtorgado;
                int numerocuotas = objCurrent.NumeroCuotas;
                decimal interes = objCurrent.ValorInteres;
                double INT = ((double)interes) / (double)100;
                decimal ValorInteres = (decimal)INT * capitalOtorgado;

                double valor;
                double elevacion;
                valor = (1.0 + INT);
                elevacion = numerocuotas;

                double result = Math.Pow(valor, elevacion);

                double L = (double)capitalOtorgado * (INT * result) / (result - 1);
                //TablaAmortizacion TablaActual = this.ObjectSpace.CreateObject<TablaAmortizacion>();

                for (int i = 0; i <= numerocuotas; i++)
                {
                    TablaAmortizacion TablaActual = this.ObjectSpace.CreateObject<TablaAmortizacion>();

                    if (i == 0)
                    {

                        TablaActual.Eliminar = true;
                        TablaActual.Mensualidad = 0;
                        TablaActual.IntesesMensuales = 0;
                        TablaActual.Amortizacion = 0;
                        TablaActual.CapitalVivo = capitalOtorgado;
                        TablaActual.CapitalAmortizado = 0;
                        TablaActual.credito = objCurrent;
                    }
                    else
                    {
                        TablaActual.Eliminar = true; 
                        TablaActual.Mensualidad =  (decimal)L;
                         TablaActual.IntesesMensuales = (TablaActual.CapitalVivo * (decimal)INT);
                         TablaActual.Amortizacion = (decimal)L - TablaActual.IntesesMensuales;
                         TablaActual.CapitalVivo = (TablaActual.CapitalVivo - TablaActual.IntesesMensuales);
                         TablaActual.CapitalAmortizado = (TablaActual.CapitalAmortizado - (decimal)L);

                         TablaActual.credito = objCurrent;                       
                    }
                    
                    if (this.View.ObjectSpace.IsModified)
                    {
                        this.View.ObjectSpace.CommitChanges();
                    }
                }


            }

            */
        }
    }
}
