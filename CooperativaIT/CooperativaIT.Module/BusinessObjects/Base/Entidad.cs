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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace CooperativaIT.Module.BusinessObjects
{
    
    [NonPersistent]
    public class Entidad : BaseObject
    {
        public Entidad(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        // Fields...
        private DateTime _FechaDeIngreso;
        private string _UsuarioCreador;

        [Appearance("UsuarioCreador", Visibility = ViewItemVisibility.Hide)]
        public string UsuarioCreador
        {
            get {return _UsuarioCreador;}
            set {SetPropertyValue("UsuarioCreador", ref _UsuarioCreador, value);}
        }
        
        [Appearance("FechaDeIngreso", Visibility = ViewItemVisibility.Hide)]
        public DateTime FechaDeIngreso
        {
            get {return _FechaDeIngreso;}
            set {SetPropertyValue("FechaDeIngreso", ref _FechaDeIngreso, value);}
        }

        protected override void OnSaving()
        {
            if (UsuarioCreador == null)
            {
                UsuarioCreador = SecuritySystem.CurrentUserName;
                FechaDeIngreso = DateTime.Now;
            }
            base.OnSaving();
        }
    }
}
