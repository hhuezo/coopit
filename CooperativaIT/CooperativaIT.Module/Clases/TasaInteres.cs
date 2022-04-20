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
    [DefaultClassOptions]
    [FriendlyKeyProperty("tasa_interes")]
    [NavigationItem("Registro")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class TasaInteres : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public TasaInteres(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
        private DateTime _Fecha_creacion;
        private int _Tasa_interes;

        public int tasa_interes
        {
            get
            {
                return _Tasa_interes;
            }
            set
            {
                SetPropertyValue("tasa_interes", ref _Tasa_interes, value);
            }
        }
       
        public DateTime fecha_creacion
        {
            get
            {
                return _Fecha_creacion;
            }
            set
            {
                SetPropertyValue("fecha_creacion", ref _Fecha_creacion, value);
            }
        }

    }
}
