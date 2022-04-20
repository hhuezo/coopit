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
    public partial class CalculoInt : ViewController
    {
        public CalculoInt()
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

        private void CalcularInt_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

           
            int max = 0;
            string numcred = "";
            decimal saldo;
            decimal Aint, capitalIni = 0;
            decimal AbonoIntereses = 0  ;
            EncabPagos clienteActual = (EncabPagos)e.CurrentObject;
            BinaryOperator BinaryEncabezado = new BinaryOperator("PagosEncab", clienteActual, BinaryOperatorType.Equal);
            CriteriaOperator CriteriaEncabezado = CriteriaOperator.And(BinaryEncabezado);
            ICollection<DetallePagos> PagoDetalle = ObjectSpace.GetObjects<DetallePagos>(CriteriaEncabezado);
            decimal capcred = clienteActual.CapitalOtorgado;
            DateTime fecotorg = clienteActual.FechaOtorgamiento;


            if (!ReferenceEquals(PagoDetalle, null))
            {


                numcred = clienteActual.referenciaCredito.ReferenciaCredito;



                foreach (DetallePagos ObjDetalle in PagoDetalle)
                {
                    if (ObjDetalle.correla > max)
                    {
                        max = ObjDetalle.correla;

                    }

                }
                decimal valorPagar = 0;

                if (max > 0)
                {
                    BinaryOperator BinaryCorrelativo = new BinaryOperator("correla", max, BinaryOperatorType.Equal);
                    CriteriaOperator Criteria = CriteriaOperator.And(BinaryEncabezado, BinaryCorrelativo);

                    DetallePagos Detalleactual = this.ObjectSpace.FindObject<DetallePagos>(Criteria);

                    int tasa = Detalleactual.PagosEncab.referenciaCredito.codigoTasaInteres.tasa_interes;
                    double tasa_i = (double)tasa / (double)100;
                    DateTime fechaPago = Detalleactual.FechaPago;
                    saldo = Detalleactual.saldoActual;
                    int mestiempo;
                    TimeSpan diferencia;
                    diferencia = DateTime.Now - fechaPago;
                    int tiempo = diferencia.Days;


                    if (fechaPago.Year < DateTime.Today.Year)
                    {
                        mestiempo = Math.Abs((DateTime.Now.Month - fechaPago.Month) + 12 * (DateTime.Now.Year - fechaPago.Year));
                    }

                    else
                    {
                        double totaldias = diferencia.Days;
                        double meses = totaldias / 30;
                        double resto = totaldias % 30;
                        if (resto >= 1 && resto <= 6)
                        {
                            mestiempo = (int)Math.Floor(meses);
                        }
                        else
                        {
                            mestiempo = (int)Math.Ceiling(meses);
                        }
                        //mestiempo = (int)Math.Ceiling(Math.Ceiling(meses));

                    }
                    if (mestiempo >= 0 && DateTime.Today.Year >= fechaPago.Year && fechaPago.Month != DateTime.Today.Month)
                    {
                        for (int i = 0; i < mestiempo; i++)
                        {

                            if (i == 0)
                            {

                                Aint = ((decimal)tasa_i * saldo);
                            }
                            else
                            {
                                capitalIni = saldo;
                                Aint = ((decimal)tasa_i * capitalIni);
                            }
                            AbonoIntereses = (decimal.Round(Aint, 2, MidpointRounding.AwayFromZero));
                            saldo = saldo + AbonoIntereses;
                            valorPagar = (decimal.Round(saldo, 2, MidpointRounding.AwayFromZero));


                            Detalleactual.PagosEncab.IntFecha = (double)AbonoIntereses;
                            clienteActual.IntFecha = (double)AbonoIntereses;

                            Detalleactual.PagosEncab.ValorPagar = (double)valorPagar;
                            

                        }
                    }
                    else
                    {
                        AbonoIntereses = 0;
                        saldo = saldo + AbonoIntereses;
                        valorPagar = (decimal.Round(saldo, 2, MidpointRounding.AwayFromZero));


                        Detalleactual.PagosEncab.IntFecha = (double)AbonoIntereses;
                        clienteActual.IntFecha = (double)AbonoIntereses;

                        Detalleactual.PagosEncab.ValorPagar = (double)valorPagar;
                        clienteActual.ValorPagar = (double)valorPagar;
                    }







                }
                else
                   
                {
                    

                    //BinaryOperator BinaryCorrelativo = new BinaryOperator("ReferenciaCredito", clienteActual, BinaryOperatorType.Equal);
                    //CriteriaOperator Criteria = CriteriaOperator.And(BinaryEncabezado, BinaryCorrelativo);

                    //EncabPagos Detalleactual = this.ObjectSpace.FindObject<EncabPagos>(Criteria);
                    
                    int tasa = clienteActual.referenciaCredito.codigoTasaInteres.tasa_interes;
                    double tasa_i = (double)tasa / (double)100;
                    DateTime fechaPago = fecotorg;
                    saldo = capcred;
                    int mestiempo;
                    TimeSpan diferencia;
                    diferencia = DateTime.Now - fechaPago;
                    int tiempo = diferencia.Days;


                    if (DateTime.Today.Year > fechaPago.Year)
                    {
                        mestiempo = Math.Abs((DateTime.Now.Month - fechaPago.Month) + 12 * (DateTime.Now.Year - fechaPago.Year));
                    }

                    else
                    {
                        decimal totaldias = diferencia.Days;
                        decimal meses = totaldias / 30;
                        mestiempo = (int)Math.Ceiling(Math.Ceiling(meses));
                    }
                    //if (mestiempo >= 0 && DateTime.Today.Year >= fechaPago.Year && fechaPago.Month != DateTime.Today.Month)
                    if (DateTime.Today.Month != fechaPago.Month)
                    {
                        if (fechaPago.Year == DateTime.Now.Year)
                        {

                            for (int i = 0; i < mestiempo; i++)
                            {

                                if (i == 0)
                                {

                                    Aint = ((decimal)tasa_i * saldo);
                                }
                                else
                                {
                                    capitalIni = saldo;
                                    Aint = ((decimal)tasa_i * capitalIni);
                                }
                                AbonoIntereses = (decimal.Round(Aint, 2, MidpointRounding.AwayFromZero)); 
                                saldo = saldo + AbonoIntereses;
                                valorPagar = (decimal.Round(saldo, 2, MidpointRounding.AwayFromZero));
                            }
                        }
                        else
                        {

                            for (int i = 0; i < mestiempo; i++)
                            {

                                if (i == 0)
                                {

                                    Aint = ((decimal)tasa_i * saldo);
                                }
                                else
                                {
                                    capitalIni = saldo;
                                    Aint = ((decimal)tasa_i * capitalIni);
                                }
                                AbonoIntereses = (decimal.Round(Aint, 2, MidpointRounding.AwayFromZero)); 
                                saldo = saldo + AbonoIntereses;
                                valorPagar = (decimal.Round(saldo, 2, MidpointRounding.AwayFromZero));

                            }
                        }

                    }


                    else
                    {
                        if ((fechaPago.Month == DateTime.Today.Month) && (fechaPago.Year == DateTime.Today.Year) && (fechaPago.Day > 25))
                        {
                            clienteActual.IntFecha = 0.00;
                            saldo = saldo + AbonoIntereses;
                            valorPagar = (decimal.Round(saldo, 2, MidpointRounding.AwayFromZero));
                        }

                        else
                        {

                            for (int i = 0; i < mestiempo; i++)
                            {

                                if (i == 0)
                                {

                                    Aint = ((decimal)tasa_i * saldo);
                                }
                                else
                                {
                                    capitalIni = saldo;
                                    Aint = ((decimal)tasa_i * capitalIni);
                                }
                                AbonoIntereses = (decimal.Round(Aint, 2, MidpointRounding.AwayFromZero));
                                saldo = saldo + AbonoIntereses;
                                valorPagar = (decimal.Round(saldo, 2, MidpointRounding.AwayFromZero));



                            }

                            ////Detalleactual.IntFecha = (double)AbonoIntereses;
                            //clienteActual.IntFecha = (double)AbonoIntereses;

                            ////Detalleactual.ValorPagar = (double)valorPagar;
                            //clienteActual.ValorPagar = (double)valorPagar;

                        }

                        //AbonoIntereses = (decimal)0.00;
                        //saldo = saldo + AbonoIntereses;
                        //valorPagar = (decimal.Round(saldo, 2, MidpointRounding.AwayFromZero));
                      

                        
                    }
                  
                }

                ////Detalleactual.IntFecha = (double)AbonoIntereses;
                clienteActual.IntFecha = (double)AbonoIntereses;

                ////Detalleactual.ValorPagar = (double)valorPagar;
                clienteActual.ValorPagar = (double)valorPagar;




                if (this.View.ObjectSpace.IsModified)
                {
                    this.View.ObjectSpace.CommitChanges();
                }
            }
        }

    }
}  

    


