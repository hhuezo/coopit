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

namespace CooperativaIT.Module.Clases
{
    //[DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class TablaAmortizacion : Entidad
            { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public TablaAmortizacion(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
        private int _Corre;
        private DateTime _FechaPago;
        private decimal _CapitalAmortizado;
        private decimal _CapitalVivo;
        private decimal _Amortizacion;
        private decimal _IntesesMensuales;
        private decimal _Mensualidad;
        private Creditos _Credito;
        private bool _Eliminar;

        public bool Eliminar
        {
            get
            {
                return _Eliminar;
            }
            set
            {
                SetPropertyValue("Eliminar", ref _Eliminar, value);
            }
        }

        public Creditos credito
        {
            get
            {
                return _Credito;
            }
            set
            {
                SetPropertyValue("credito", ref _Credito, value);
            }
        }


        public int corre
        {
            get
            {
                return _Corre;
            }
            set
            {
                SetPropertyValue("corre", ref _Corre, value);
            }
        }


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
        public decimal Mensualidad
        {
            get
            {
                return _Mensualidad;
            }
            set
            {
                SetPropertyValue("Mensualidad", ref _Mensualidad, value);
            }
        }

        public decimal IntesesMensuales
        {
            get
            {
                return _IntesesMensuales;
            }
            set
            {
                SetPropertyValue("IntesesMensuales", ref _IntesesMensuales, value);
            }
        }


        public decimal Amortizacion
        {
            get
            {
                return _Amortizacion;
            }
            set
            {
                SetPropertyValue("Amortizacion", ref _Amortizacion, value);
            }
        }


        public decimal CapitalVivo
        {
            get
            {
                return _CapitalVivo;
            }
            set
            {
                SetPropertyValue("CapitalVivo", ref _CapitalVivo, value);
            }
        }


        public decimal CapitalAmortizado
        {
            get
            {
                return _CapitalAmortizado;
            }
            set
            {
                SetPropertyValue("CapitalAmortizado", ref _CapitalAmortizado, value);
            }
        }
    }
}
