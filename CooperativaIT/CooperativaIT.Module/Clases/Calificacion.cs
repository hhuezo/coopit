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

namespace CooperativaIT.Module.Clases
{
    [DefaultClassOptions]
    [FriendlyKeyProperty("descripcion")]
    [NavigationItem("Registro")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class Calificacion : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Calificacion(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }


        // Fields...
        private int _RangoFinal;
        private int _RagoInicial;
        private string _Descripcion;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                SetPropertyValue("descripcion", ref _Descripcion, value);
            }
        }

        public int ragoInicial
        {
            get
            {
                return _RagoInicial;
            }
            set
            {
                SetPropertyValue("ragoInicial", ref _RagoInicial, value);
            }
        }

        public int rangoFinal
        {
            get
            {
                return _RangoFinal;
            }
            set
            {
                SetPropertyValue("rangoFinal", ref _RangoFinal, value);
            }
        }
    }
}
