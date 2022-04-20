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
    [NavigationItem("Movimientos")]
    [ImageName("BO_Contact")]
    public class FondosEncab : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public FondosEncab(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        private persona _Socio;

        //[DataSourceCriteria("Clasificacion=1")]
        public persona Socio
        {
            get
            {
                return _Socio;
            }
            set
            {
                SetPropertyValue("Socio", ref _Socio, value);
            }
        }
        


        [Association("FondosEncab-FondosDetalle"), DevExpress.Xpo.Aggregated()]
        public XPCollection<FondosDetalle> FondosDetalle
        {
            get
            {
                return GetCollection<FondosDetalle>("FondosDetalle");

            }

        }

    }
}
