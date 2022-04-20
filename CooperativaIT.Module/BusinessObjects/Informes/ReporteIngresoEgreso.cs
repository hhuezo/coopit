using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using CooperativaIT.Module.BusinessObjects.Enums;

namespace CooperativaIT.Module.BusinessObjects.Informes
{
    [DefaultClassOptions]
    [DeferredDeletion(false)]
    public class ReporteIngresoEgreso : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ReporteIngresoEgreso(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        private TipoMovimiento _TipoMovimiento;
        private string _Descripcion;
        private decimal _Total;
        private decimal _Egreso;
        private decimal _Ingreso;
        private DateTime _Fecha;

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                SetPropertyValue("Fecha", ref _Fecha, value);
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                SetPropertyValue("Descripcion", ref _Descripcion, value);
            }
        }

        public decimal Ingreso
        {
            get
            {
                return _Ingreso;
            }
            set
            {
                SetPropertyValue("Ingreso", ref _Ingreso, value);
            }
        }


        public decimal Egreso
        {
            get
            {
                return _Egreso;
            }
            set
            {
                SetPropertyValue("Egreso", ref _Egreso, value);
            }
        }


        public decimal Total
        {
            get
            {
                return _Total;
            }
            set
            {
                SetPropertyValue("Total", ref _Total, value);
            }
        }

        // 1- aportacion , 2- ingreso pago, 3- prestamo
        public TipoMovimiento TipoMovimiento
        {
            get
            {
                return _TipoMovimiento;
            }
            set
            {
                SetPropertyValue("TipoMovimiento", ref _TipoMovimiento, value);
            }
        }
    }
}
