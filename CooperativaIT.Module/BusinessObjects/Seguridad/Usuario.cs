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
using DevExpress.ExpressApp.Security.Strategy;

namespace CooperativaIT.Module.BusinessObjects.Seguridad
{
    [DefaultClassOptions]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class Usuario : SecuritySystemUser
    {
        public Usuario(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        // Fields...
        private string _Email;
        private string _NombreCompleto;

        public string NombreCompleto
        {
            get { return _NombreCompleto; }
            set { SetPropertyValue("NombreCompleto", ref _NombreCompleto, value); }
        }

        public string Email
        {
            get { return _Email; }
            set { SetPropertyValue("Email", ref _Email, value); }
        }

        [Association("Usuario-UnidadAdministrativa")]
        public XPCollection<UnidadAdministrativa> UnidadAdministrativa
        {
            get { return GetCollection<UnidadAdministrativa>("UnidadAdministrativa"); }
        }

        public CriteriaOperator ObtenerFiltroUnidades()
        {
            CriteriaOperator FiltroDeUnidades = null;
            List<CriteriaOperator> Operadores = new List<CriteriaOperator>();
            foreach (UnidadAdministrativa unidadAdministrativa in this.UnidadAdministrativa)
                Operadores.Add(new BinaryOperator("ResponsableDirecto.Oid", unidadAdministrativa.Oid));
            foreach (UnidadAdministrativa unidadAdministrativa in this.UnidadAdministrativa)
                Operadores.Add(new BinaryOperator("ResponsableIndirecto.Oid", unidadAdministrativa.Oid));
            if (Operadores.Count == 0)
                Operadores.Add(new BinaryOperator("ResponsableDirecto.Oid", Guid.Empty));
            FiltroDeUnidades = CriteriaOperator.Or(Operadores.ToArray());
            return FiltroDeUnidades;
        }
    }
}
