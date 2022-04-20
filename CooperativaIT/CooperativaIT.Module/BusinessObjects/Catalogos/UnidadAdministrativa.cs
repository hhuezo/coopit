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
using CooperativaIT.Module.BusinessObjects.Seguridad;

namespace CooperativaIT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Organization")]
    public class UnidadAdministrativa : Entidad100 
    {
        public UnidadAdministrativa(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [Association("Usuario-UnidadAdministrativa")]
        public XPCollection<Usuario> Usuario
        {
            get {return GetCollection<Usuario>("Usuario");}
        }
    }
}
