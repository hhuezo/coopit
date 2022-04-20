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

           /* BinaryOperator BinaryAxo = new BinaryOperator("PagosEncab.FechaOtorgamiento", 2022, BinaryOperatorType.Equal);

            DateTime FechaInicio = DateTime.Parse("2022-01-01");
            DateTime FechaFin = DateTime.Parse("2022-12-31");
            BetweenOperator betweenFechas = new BetweenOperator("FechaPago", FechaInicio, FechaFin);
            ICollection<DetallePagos> ListPagos2 = ObjectSpace.GetObjects<DetallePagos>(betweenFechas);

            foreach (DetallePagos obj in ListPagos2)
            {
                if(obj.PagosEncab.FechaOtorgamiento.Year == 2022)
                {
                    obj.Divindendo = obj.AbonoIntereses;
                }
                else
                {
                    obj.Divindendo = obj.TotalPagado;
                }
            }

            if (this.View.ObjectSpace.IsModified)
            {
                this.View.ObjectSpace.CommitChanges();
            }*/

            EncabPagos encabezado_actual = (EncabPagos)e.CurrentObject;
            BinaryOperator BinaryEncabezado = new BinaryOperator("PagosEncab", encabezado_actual, BinaryOperatorType.Equal);
            ICollection<DetallePagos> ListPagos = ObjectSpace.GetObjects<DetallePagos>(BinaryEncabezado);

            DetallePagos ultimo_pago = null;
            if (ListPagos.Count > 0)
            {
                foreach (DetallePagos obj in ListPagos)
                {
                    if (ReferenceEquals(ultimo_pago, null) || ultimo_pago.correla < obj.correla)
                    {
                        ultimo_pago = obj;
                    }
                }

                  DateTime fecha_ultimo_pago = ultimo_pago.FechaPago;
                  decimal saldoActual = ultimo_pago.saldoActual;
                  DateTime fecha_pago = DateTime.Now;


                        int meses = Math.Abs((fecha_pago.Month - fecha_ultimo_pago.Month) + 12 * (fecha_pago.Year - fecha_ultimo_pago.Year));

                       /* if(meses == 0)
                        {
                            meses = 1;
                        }*/

                        decimal interes_a_pagar = 0;
                        decimal saldo_a_pagar = 0;
                        decimal tasa = Convert.ToDecimal(0.05);

                        for (int i = 0; i < meses; i++)
                        {
                            if (interes_a_pagar == 0)
                            {
                                interes_a_pagar = saldoActual * tasa;
                            }
                            else
                            {
                                interes_a_pagar += (interes_a_pagar + saldoActual) * tasa;
                            }

                        }

                        saldo_a_pagar = saldoActual + interes_a_pagar;

                        encabezado_actual.ValorPagar = Convert.ToDouble(decimal.Round(saldo_a_pagar, 2, MidpointRounding.AwayFromZero));
                        encabezado_actual.IntFecha = Convert.ToDouble(decimal.Round(interes_a_pagar, 2, MidpointRounding.AwayFromZero));

            }
            else{
                        DateTime fecha_ultimo_pago = encabezado_actual.FechaOtorgamiento;
                        decimal saldoActual = encabezado_actual.CapitalOtorgado;
                         DateTime fecha_pago = DateTime.Now;

                        int meses = Math.Abs((fecha_pago.Month - fecha_ultimo_pago.Month) + 12 * (fecha_pago.Year - fecha_ultimo_pago.Year));

                        if (meses == 0)
                        {
                            meses = 1;
                        }

                        decimal interes_a_pagar = 0;
                        decimal saldo_a_pagar = 0;
                        decimal tasa = Convert.ToDecimal(0.05);

                        for (int i = 0; i < meses; i++)
                        {
                            if (interes_a_pagar == 0)
                            {
                                interes_a_pagar = saldoActual * tasa;
                            }
                            else
                            {
                                interes_a_pagar += (interes_a_pagar + saldoActual) * tasa;
                            }

                        }

                        saldo_a_pagar = saldoActual + interes_a_pagar;
                        encabezado_actual.ValorPagar = Convert.ToDouble(decimal.Round(saldo_a_pagar, 2, MidpointRounding.AwayFromZero));
                        encabezado_actual.IntFecha = Convert.ToDouble(decimal.Round(interes_a_pagar, 2, MidpointRounding.AwayFromZero));
            }

            if (this.View.ObjectSpace.IsModified)
            {
                this.View.ObjectSpace.CommitChanges();
            }


            /* int max = 0;
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
             * 
             * 
             }*/
        }

    }
}  

    


