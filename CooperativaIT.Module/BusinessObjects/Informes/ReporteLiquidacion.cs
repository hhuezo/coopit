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
using CooperativaIT.Module.BusinessObjects.Catalogos;
using CooperativaIT.Module.BusinessObjects.Enums;

namespace CooperativaIT.Module.BusinessObjects.Informes
{
    [DefaultClassOptions]
    [DeferredDeletion(false)]
    public class ReporteLiquidacion : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ReporteLiquidacion(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        private decimal _Total;
        private string _Nombre;
        private decimal _CapitalInicial;
        private DateTime _Fecha;
        private Mes _Mes;
        private decimal _Dividendos;
        private decimal _Aportacion;
        private AxoContable _AxoContable;
        private Socios _Socios;



   


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

        public AxoContable AxoContable
        {
            get
            {
                return _AxoContable;
            }
            set
            {
                SetPropertyValue("AxoContable", ref _AxoContable, value);
            }
        }
        public Socios Socios
        {
            get
            {
                return _Socios;
            }
            set
            {
                SetPropertyValue("Socios", ref _Socios, value);
            }
        }


        [NonPersistent]
        public string Nombre
        {
            get
            {
                if (!ReferenceEquals(Socios,null))
                {
                    _Nombre = Socios.Persona.nombres + " " + Socios.Persona.apellidos;
                }
                return _Nombre;
            }
            set
            {
                SetPropertyValue("Nombre", ref _Nombre, value);
            }
        }

        public decimal Aportacion
        {
            get
            {
                return _Aportacion;
            }
            set
            {
                SetPropertyValue("Aportacion", ref _Aportacion, value);
            }
        }


        public decimal Dividendos
        {
            get
            {
                return _Dividendos;
            }
            set
            {
                SetPropertyValue("Dividendos", ref _Dividendos, value);
            }
        }


        public decimal CapitalInicial
        {
            get
            {
                return _CapitalInicial;
            }
            set
            {
                SetPropertyValue("CapitalInicial", ref _CapitalInicial, value);
            }
        }


        [NonPersistent]
        public decimal Total
        {
            get
            {
                if (!ReferenceEquals(Aportacion, null) && !ReferenceEquals(Dividendos, null) && !ReferenceEquals(CapitalInicial, null))
                {
                    _Total = Aportacion + Dividendos + CapitalInicial;
                }
                return _Total;
            }
            set
            {
                SetPropertyValue("Total", ref _Total, value);
            }
        }
    }
}
