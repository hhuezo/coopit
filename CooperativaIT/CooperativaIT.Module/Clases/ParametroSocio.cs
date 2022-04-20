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
using CooperativaIT.Module.BusinessObjects;
using CooperativaIT.Module.BusinessObjects.Enums;

namespace CooperativaIT.Module.Clases
{
    [NonPersistent]
    public class ParametroSocio : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ParametroSocio(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
        private int _MesApli;
        private TipoFondos _TipoFondos;
        private DateTime _FechaAplicacion;
        private decimal _ValorPagado;
        private TiposPago _TipoPago;
        private DateTime _FechaPago;
        private persona _Socio;
        private bool _Todos;

        public bool Todos
        {
            get
            {
                return _Todos;
            }
            set
            {
                SetPropertyValue("Todos", ref _Todos, value);
            }
        }

        [DataSourceCriteria("Clasificacion=1")]
        public persona socio
        {
            get
            {
                return _Socio;
            }
            set
            {
                SetPropertyValue("socio", ref _Socio, value);
            }
        }


        public int MesApli
        {
            get
            {
                return _MesApli;
            }
            set
            {
                SetPropertyValue("MesApli", ref _MesApli, value);
            }
        }

       // [RuleRequiredField]
        public DateTime FechaPago
        {
            get
            {
                return _FechaPago;
            }
            set
            {
                SetPropertyValue("FechaPago", ref _FechaPago, value);
            }
        }

        //[RuleValueComparison("Debe ser mayor que cero", DefaultContexts.Save, ValueComparisonType.GreaterThan, "0")]
        public TipoFondos TipoFondos
        {
            get
            {
                return _TipoFondos;
            }
            set
            {
                SetPropertyValue("TipoFondos", ref _TipoFondos, value);
            }
        }


        // [RuleRequiredField]
        public decimal ValorPagado
        {
            get
            {
                return _ValorPagado;
            }
            set
            {
                SetPropertyValue("ValorPagado", ref _ValorPagado, value);
            }
        }


         //[RuleRequiredField]
        public DateTime FechaAplicacion
        {
            get
            {
                return _FechaAplicacion;
            }
            set
            {
                SetPropertyValue("FechaAplicacion", ref _FechaAplicacion, value);
            }
        }
        
    }
}
