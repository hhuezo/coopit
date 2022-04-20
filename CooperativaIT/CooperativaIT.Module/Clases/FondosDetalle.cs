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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace CooperativaIT.Module.Clases
{
    [DefaultClassOptions]
    [NavigationItem("Movimientos")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class FondosDetalle : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public FondosDetalle(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
      
      
        private int _Año;
        private DateTime _FechaAplicacion;
        private decimal _ValorPagado;
        private TipoFondos _TipoPago;
        private DateTime _FechaPago;
        private int _Mes;
        private FondosEncab _FondosEncab;


        [Association("FondosEncab-FondosDetalle")]
        public FondosEncab FondosEncab
        {
            get
            {
                return _FondosEncab;
            }
            set
            {
                SetPropertyValue("FondosEncab", ref _FondosEncab, value);
            }
        }

        public int Mes
        {
            get
            {
                return _Mes;
            }
            set
            {
                SetPropertyValue("Correlativo", ref _Mes, value);
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


        
        public TipoFondos TipoPago
        {
        	get
        	{
        		return _TipoPago;
        	}
        	set
        	{
        	  SetPropertyValue("TipoPago", ref _TipoPago, value);
        	}
        }


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

        [Appearance("contNum", Visibility = ViewItemVisibility.Hide, Criteria = "!IsCurrentUserInRole('Administrators')")]        
        public int año
        {
            get
            {
                return _Año;
            }
            set
            {
                SetPropertyValue("año", ref _Año, value);
            }
        }



        
    }
}
