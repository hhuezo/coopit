using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ReportsV2;
using CooperativaIT.Module.BusinessObjects.Catalogos;
using CooperativaIT.Module.BusinessObjects.Enums;
using DevExpress.Persistent.Validation;
using CooperativaIT.Module.Clases;
using System.Collections.Generic;

namespace CooperativaIT.Module.BusinessObjects.Informes
{
    [DomainComponent]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/#Xaf/CustomDocument3594.
    public class ParametersLiquidacion : ReportParametersObjectBase
    {
        public ParametersLiquidacion(IObjectSpaceCreator provider) : base(provider) {

            DateTime fechaActual = DateTime.Today;
            BinaryOperator BinaryAxo = new BinaryOperator("Axo", fechaActual.Year);
            AxoContable axo_actual = this.ObjectSpace.FindObject<AxoContable>(BinaryAxo);

            if (!ReferenceEquals(axo_actual, null))
            {
                this.axo_contable = axo_actual;
            }
        }
        protected override IObjectSpace CreateObjectSpace()
        {
            return objectSpaceCreator.CreateObjectSpace(typeof(object));
        }
        public override CriteriaOperator GetCriteria()
        {
            DeleteData();
            CreateData();
            CriteriaOperator criteria = new BinaryOperator("Aportacion", 0, BinaryOperatorType.NotEqual);
            return criteria;
        }
        public override SortProperty[] GetSorting()
        {
            SortProperty[] sorting = { new SortProperty("Socios", SortingDirection.Ascending) };
            return sorting;
        }


         [RuleRequiredField]

        // Fields...

         [DevExpress.Xpo.DisplayName("Año")]
        public AxoContable axo_contable { get; set; }

          private void CreateData()
          {

          
               DateTime FechaInicio = DateTime.Parse(axo_contable.Axo + "-01-01");
               DateTime FechaFin = DateTime.Parse(axo_contable.Axo + "-12-31");
               BetweenOperator betweenFechas = new BetweenOperator("FechaPago", FechaInicio, FechaFin);
               ICollection<DetallePagos> ListPagos = ObjectSpace.GetObjects<DetallePagos>(betweenFechas);

               decimal total_pagos = 0;

               foreach (DetallePagos pagos in ListPagos)
               {
                   total_pagos += pagos.Divindendo;
                  
               }

              if(axo_contable.Axo == 2022)
              {
                  total_pagos = total_pagos - Convert.ToDecimal( 8.18);
              }

               BetweenOperator betweenFechasEncabezado = new BetweenOperator("FechaOtorgamiento", FechaInicio, FechaFin);
               BinaryOperator binaryEstado = new BinaryOperator("EstadoCredito",EstadoCredito.Cancelado, BinaryOperatorType.NotEqual );
               CriteriaOperator EncabezadoOperator = CriteriaOperator.And(betweenFechasEncabezado);
               ICollection<EncabPagos> ListEncabezadoPagos = ObjectSpace.GetObjects<EncabPagos>(EncabezadoOperator);
               decimal total_encabezado_pagos = 0;
               foreach (EncabPagos encabezado_pagos in ListEncabezadoPagos)
               {
                   total_encabezado_pagos += encabezado_pagos.CapitalOtorgado;
               }

               decimal ingreso = total_pagos;

               int numero_cuentas = 0;
               foreach (Socios socio in axo_contable.Socios)
               {
                   numero_cuentas += socio.NumeroCuentas;
               }

               ingreso = ingreso - (numero_cuentas * 25);

               decimal dividendo = ingreso / numero_cuentas;
               foreach(Socios socio in axo_contable.Socios)
               {

                   decimal total_aportacion = 0;
                   foreach(Aportacion aportacion in socio.Aportacion)
                   {
                       total_aportacion += aportacion.Cantidad ;
                   }             

                  

                   ReporteLiquidacion reporte = this.ObjectSpace.CreateObject<ReporteLiquidacion>();
                   reporte.Socios = socio;
                   reporte.Aportacion = total_aportacion;
                   reporte.CapitalInicial = Convert.ToDecimal(150.00) * socio.NumeroCuentas;
                   reporte.Dividendos = (dividendo * socio.NumeroCuentas);
                   this.ObjectSpace.CommitChanges();
               }

          }

      
        private void DeleteData()
          {
              BinaryOperator Eliminar = new BinaryOperator("Socios.NumeroCuentas",0, BinaryOperatorType.NotEqual);

              bool Seguir = true;
              while (Seguir)
              {
                  if (!ReferenceEquals(this.ObjectSpace.FindObject<ReporteLiquidacion>(Eliminar), null))
                  {
                      this.ObjectSpace.Delete(this.ObjectSpace.FindObject<ReporteLiquidacion>(Eliminar));
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
