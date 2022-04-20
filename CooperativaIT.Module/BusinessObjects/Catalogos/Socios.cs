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
using CooperativaIT.Module.Clases;

namespace CooperativaIT.Module.BusinessObjects.Catalogos
{
    [DefaultClassOptions]
    [NavigationItem("Configuración")]
    [FriendlyKeyProperty("Persona")]
    public class Socios : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Socios(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        private int _NumeroCuentas;
        private persona _Persona;
        private AxoContable _AxoContable;

        [DevExpress.Xpo.DisplayName("Año")]
        [Association("AxoContable-Socios")]
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

        [DevExpress.Xpo.DisplayName("Nombre")]
         public persona Persona
         {
             get
             {
                 return _Persona;
             }
             set
             {
                 SetPropertyValue("Persona", ref _Persona, value);
             }
         }


         public int NumeroCuentas
         {
             get
             {
                 return _NumeroCuentas;
             }
             set
             {
                 SetPropertyValue("NumeroCuentas", ref _NumeroCuentas, value);
             }
         }

         [DevExpress.Xpo.DisplayName("Aportaciones")]
         [Association("Socios-Aportacion")]
         public XPCollection<Aportacion> Aportacion
         {
             get
             {
                 return GetCollection<Aportacion>("Aportacion");
             }
         }
    }
}
