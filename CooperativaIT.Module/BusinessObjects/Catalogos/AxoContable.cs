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

namespace CooperativaIT.Module.BusinessObjects.Catalogos
{
    [DefaultClassOptions]
    [NavigationItem("Configuración")]
    [ModelDefault("Caption", "Año contable")]
    [FriendlyKeyProperty("Axo")]
    public class AxoContable : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public AxoContable(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }


        // Fields...
        private bool _Activo;
        private int _Axo;

        [DevExpress.Xpo.DisplayName("Año")]
        public int Axo
        {
            get
            {
                return _Axo;
            }
            set
            {
                SetPropertyValue("Axo", ref _Axo, value);
            }
        }


        public bool Activo
        {
            get
            {
                return _Activo;
            }
            set
            {
                SetPropertyValue("Activo", ref _Activo, value);
            }
        }

        [Association("AxoContable-Socios")]
        public XPCollection<Socios> Socios
        {
            get
            {
                return GetCollection<Socios>("Socios");
            }
        }
    }
}
