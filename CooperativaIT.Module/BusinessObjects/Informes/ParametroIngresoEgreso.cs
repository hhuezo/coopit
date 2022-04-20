using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.Validation;
using CooperativaIT.Module.BusinessObjects.Catalogos;
using CooperativaIT.Module.BusinessObjects.Enums;
using CooperativaIT.Module.Clases;
using System.Collections.Generic;

namespace CooperativaIT.Module.BusinessObjects.Informes
{
    [DomainComponent]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/#Xaf/CustomDocument3594.
    public class ParametroIngresoEgreso : ReportParametersObjectBase
    {
        public ParametroIngresoEgreso(IObjectSpaceCreator provider) : base(provider) {
            DateTime fechaActual = DateTime.Today;
            BinaryOperator BinaryAxo = new BinaryOperator("Axo", fechaActual.Year);
            AxoContable axo_actual = this.ObjectSpace.FindObject<AxoContable>(BinaryAxo);

            if (!ReferenceEquals(axo_actual, null))
            {
                this.Axo = axo_actual;
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
            CriteriaOperator criteria = new BinaryOperator("Descripcion", "", BinaryOperatorType.NotEqual);
            return criteria;
        }
        public override SortProperty[] GetSorting()
        {
            SortProperty[] sorting = { new SortProperty("Oid", SortingDirection.Descending) };
            return sorting;
        }

        [RuleRequiredField] 
        public AxoContable Axo  { get; set; }

        private string CargaMes(Mes mes)
        {
            string numero_mes = "01";
            switch (mes)
            {
                case Enums.Mes.Enero:
                    numero_mes = "01";
                    break;

                case Enums.Mes.Febrero:
                    numero_mes = "02";
                    break;

                case Enums.Mes.Marzo:
                    numero_mes = "03";
                    break;

                case Enums.Mes.Abril:
                    numero_mes = "04";
                    break;

                case Enums.Mes.Mayo:
                    numero_mes ="05";
                    break;

                case Enums.Mes.Junio:
                    numero_mes = "06";
                    break;

                case Enums.Mes.Julio:
                    numero_mes = "07";
                    break;

                case Enums.Mes.Agosto:
                    numero_mes = "08";
                    break;

                case Enums.Mes.Septiembre:
                    numero_mes = "09";
                    break;

                case Enums.Mes.Octubre:
                    numero_mes = "10";
                    break;

                case Enums.Mes.Noviembre:
                    numero_mes = "11";
                    break;

                case Enums.Mes.Diciembre:
                    numero_mes = "12";
                    break;                    
            }

            return numero_mes;
        }
        private void CreateData()
        {  
            foreach (Socios socio in Axo.Socios)
            {
                DateTime FechaCapital = DateTime.Parse(Axo.Axo + "-01-01");
                ReporteIngresoEgreso reporte_capital = this.ObjectSpace.CreateObject<ReporteIngresoEgreso>();
                reporte_capital.Fecha = FechaCapital;
                reporte_capital.Descripcion = "Capital inicial " + Axo.Axo + " " + socio.Persona.nombres + " " + socio.Persona.apellidos;
                reporte_capital.Ingreso = Convert.ToDecimal(150.00) * socio.NumeroCuentas;
                reporte_capital.TipoMovimiento = TipoMovimiento.Aportación;
                this.ObjectSpace.CommitChanges();
                foreach(Aportacion aportacion in socio.Aportacion)
                {
                    //DateTime Fecha = DateTime.Parse(Axo.Axo + "-" + CargaMes(aportacion.Mes) + "-22");
                    //aportacion.Fecha = Fecha;

                    ReporteIngresoEgreso reporte = this.ObjectSpace.CreateObject<ReporteIngresoEgreso>();
                    reporte.Fecha = aportacion.Fecha;
                    reporte.Descripcion = "Aportacion capital " + aportacion.Mes + " " + aportacion.Socios.Persona.nombres + " " + aportacion.Socios.Persona.apellidos;
                    reporte.Ingreso = aportacion.Cantidad;
                    reporte.TipoMovimiento = TipoMovimiento.Aportación; 
                    this.ObjectSpace.CommitChanges();
                }
            }

            DateTime FechaInicio = DateTime.Parse(Axo.Axo + "-01-01");
            DateTime FechaFin = DateTime.Parse(Axo.Axo + "-12-31");

            BetweenOperator betweenFechasPrestamo = new BetweenOperator("FechaOtorgamiento", FechaInicio, FechaFin);
            ICollection<EncabPagos> ListEncabezadoPagos = ObjectSpace.GetObjects<EncabPagos>(betweenFechasPrestamo);

            if (Axo.Axo == 2022)
            {
                ReporteIngresoEgreso reporte_inical = this.ObjectSpace.CreateObject<ReporteIngresoEgreso>();
                reporte_inical.Fecha = FechaInicio;
                reporte_inical.Descripcion = "Cuadre de caja";
                reporte_inical.Ingreso = Convert.ToDecimal(8.18);
                reporte_inical.TipoMovimiento = TipoMovimiento.Prestamo;
                this.ObjectSpace.CommitChanges();
            }
           

            foreach(EncabPagos encabezado in ListEncabezadoPagos)
            {
                ReporteIngresoEgreso reporte = this.ObjectSpace.CreateObject<ReporteIngresoEgreso>();
                reporte.Fecha = encabezado.FechaOtorgamiento;
                reporte.Descripcion = "Prestamo de credito " + encabezado.referenciaCredito.ReferenciaCredito + " " + encabezado.referenciaCredito.CodigoBeneficiario.nombres + " " + encabezado.referenciaCredito.CodigoBeneficiario.apellidos;
                reporte.Ingreso = encabezado.CapitalOtorgado;
                reporte.TipoMovimiento = TipoMovimiento.Prestamo;
                this.ObjectSpace.CommitChanges();
            }

            BetweenOperator betweenFechas = new BetweenOperator("FechaPago", FechaInicio, FechaFin);
            ICollection<DetallePagos> ListPagos = ObjectSpace.GetObjects<DetallePagos>(betweenFechas);

            foreach(DetallePagos pago in ListPagos)
            {
                ReporteIngresoEgreso reporte = this.ObjectSpace.CreateObject<ReporteIngresoEgreso>();
                reporte.Fecha = pago.FechaPago;
                reporte.Descripcion = "Pago de credito " + pago.PagosEncab.referenciaCredito.ReferenciaCredito + " " + pago.PagosEncab.referenciaCredito.CodigoBeneficiario.nombres + " " + pago.PagosEncab.referenciaCredito.CodigoBeneficiario.apellidos;
                reporte.Ingreso = pago.TotalPagado;
                reporte.TipoMovimiento = TipoMovimiento.Pago;
                this.ObjectSpace.CommitChanges();
            }

        }

        private void DeleteData()
        {
            BinaryOperator Eliminar = new BinaryOperator("Descripcion", "", BinaryOperatorType.NotEqual);

            bool Seguir = true;
            while (Seguir)
            {
                if (!ReferenceEquals(this.ObjectSpace.FindObject<ReporteIngresoEgreso>(Eliminar), null))
                {
                    this.ObjectSpace.Delete(this.ObjectSpace.FindObject<ReporteIngresoEgreso>(Eliminar));
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
