using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ReportsV2;
using CooperativaIT.Module.Clases;

namespace CooperativaIT.Module.BusinessObjects.Informes
{
    [DomainComponent]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/#Xaf/CustomDocument3594.
    public class ParametroAmotizacion : ReportParametersObjectBase
    {
        public ParametroAmotizacion(IObjectSpaceCreator provider) : base(provider) {
            //CriteriaOperator criteria = new BinaryOperator("corre", 0);
            //TablaAmortizacion obj = ObjectSpace.FindObject<TablaAmortizacion>(Criteria);
            ////Comision FirmaPresidente2 = ObjectSpace.FindObject<Comision>(criteriaPersona2);
        }
        protected override IObjectSpace CreateObjectSpace()
        {
            return objectSpaceCreator.CreateObjectSpace(typeof(object));
        }

        public override CriteriaOperator GetCriteria()
        {
            DeleteData();
            UpdateData();
            
            CriteriaOperator criteria = new BinaryOperator("Eliminar", true);
            
            //CriteriaOperator criteria = null;
            return criteria;
        }
        public override SortProperty[] GetSorting()
        {


            SortProperty[] sorting = { new SortProperty("credito", SortingDirection.Descending) };
            return sorting;
        }
        [ImmediatePostData()]
        public Creditos Credito { get; set; }

        private void UpdateData()
        {
            if (!ReferenceEquals(Credito, null))
            {
                //decimal capitalOtorgado = Credito.CapitalOtorgado;
                int numerocuotas = Credito.NumeroCuotas;
                //decimal interes = Credito.codigoTasaInteres.tasa_interes;
                //double INT = ((double)interes) / (double)100;
                //decimal ValorInteres = (decimal)INT * capitalOtorgado;

                //double valor;
                //double elevacion;
                //valor = (1.0 + INT);
                //elevacion = numerocuotas;

                //double result = Math.Pow(valor, elevacion);

                //double L = (double)capitalOtorgado * (INT * result) / (result - 1);
                //TablaAmortizacion TablaActual = this.ObjectSpace.CreateObject<TablaAmortizacion>();

                for (int i = 0; i <= numerocuotas; i++)
                {



                    double valor;
                    double elevacion;
                    decimal capvivo;
                    TablaAmortizacion TablaActual = this.ObjectSpace.CreateObject<TablaAmortizacion>();
                    decimal capitalOtorgado = Credito.CapitalOtorgado;
                    //int numerocuotas = Credito.NumeroCuotas;
                    decimal interes = Credito.codigoTasaInteres.tasa_interes;
                   
                    double INT = ((double)interes) / (double)100;
                    valor = (1.0 + INT);
                    elevacion = numerocuotas;
                    double result = Math.Pow(valor, elevacion);
                    //decimal ValorInteres = (decimal)INT * capitalOtorgado;
                    double L = (double)Credito.CapitalOtorgado * (INT * result) / (result - 1);
                  
                    
                    
               

                    if (i == 0)
                    {
                       
                        TablaActual.Eliminar = true;
                        TablaActual.Mensualidad = 0;
                        TablaActual.IntesesMensuales = 0;
                        TablaActual.Amortizacion = 0;
                        TablaActual.CapitalVivo = capitalOtorgado;
                        TablaActual.CapitalAmortizado = 0;
                        TablaActual.credito = Credito;
                        TablaActual.corre = i;
                        TablaActual.FechaPago = Credito.FechaOtorgamiento;
                        //this.ObjectSpace.CommitChanges();

                    }
                    else
                    {
                        //BinaryOperator Criteria = new BinaryOperator("corre",i-1);

                        CriteriaOperator criteria = new BinaryOperator("corre",i-1, BinaryOperatorType.Equal);
                        TablaAmortizacion itemActual = ObjectSpace.FindObject<TablaAmortizacion>(criteria);

                        if (!ReferenceEquals(itemActual, null))
                        {

                            capvivo = itemActual.CapitalVivo;
                            decimal capamor = itemActual.CapitalAmortizado ;
                        
                        }

                        decimal ValorInteres = ((decimal)INT * itemActual.CapitalVivo);
                       

                       

                       

                        TablaActual.Eliminar = true;
                        TablaActual.Mensualidad = (decimal)L;
                        TablaActual.IntesesMensuales = (itemActual.CapitalVivo * (decimal)INT);
                        TablaActual.Amortizacion = (decimal)L - TablaActual.IntesesMensuales;
                        TablaActual.CapitalVivo = (itemActual.CapitalVivo - ( TablaActual.Amortizacion));
                        TablaActual.CapitalAmortizado = ( TablaActual.Amortizacion + itemActual.CapitalAmortizado);
                        TablaActual.credito = Credito;
                        TablaActual.corre = i;
                        TablaActual.FechaPago = Credito.FechaOtorgamiento.AddMonths(i);
                        //this.ObjectSpace.CommitChanges();
                        
                    }

                    //if (this.ObjectSpace.IsModified)
                    //{
                        this.ObjectSpace.CommitChanges();
                    //}
                }

                //this.ObjectSpace.CommitChanges();

            }
        }
         private void DeleteData()
        {
            BinaryOperator Eliminar = new BinaryOperator("Eliminar", true);
            bool Seguir = true;
            while (Seguir)
            {
                if (!ReferenceEquals(this.ObjectSpace.FindObject<TablaAmortizacion>(Eliminar), null))
                {
                    this.ObjectSpace.Delete(this.ObjectSpace.FindObject<TablaAmortizacion>(Eliminar));
                    this.ObjectSpace.CommitChanges();
                }
                else
                {
                    Seguir = false;
                }
            }


        }

    
    }
}
