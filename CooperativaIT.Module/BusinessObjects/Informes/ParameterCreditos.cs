using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ReportsV2;
using CooperativaIT.Module.Clases;

namespace CooperativaIT.Module.BusinessObjects.Informes
{
    [DomainComponent]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/#Xaf/CustomDocument3594.
    public class ParameterCreditos : ReportParametersObjectBase
    {
        public ParameterCreditos(IObjectSpaceCreator provider) : base(provider) {

            CriteriaOperator criteriaPersona = new BinaryOperator("descripcion", "Presidente", BinaryOperatorType.Equal);
            Comision FirmaPresidente = ObjectSpace.FindObject<Comision>(criteriaPersona);
            if (!ReferenceEquals(FirmaPresidente, null))
            {
                FirmaAutorizado = FirmaPresidente;
            }

            CriteriaOperator criteriaPersona2 = new BinaryOperator("descripcion", "Tesorero", BinaryOperatorType.Equal);
            Comision FirmaPresidente2 = ObjectSpace.FindObject<Comision>(criteriaPersona2);
            if (!ReferenceEquals(FirmaPresidente2, null))
            {
                FirmaContador = FirmaPresidente2;
            }
        
        }
        protected override IObjectSpace CreateObjectSpace()
        {
            return objectSpaceCreator.CreateObjectSpace(typeof(object));
        }
        public override CriteriaOperator GetCriteria()
        {
            UpdateData();
            CriteriaOperator criteria = new BinaryOperator("ReferenciaCredito", NumeroCredito);
            return criteria;
        }
        public override SortProperty[] GetSorting()
        {
            SortProperty[] sorting = { new SortProperty("ReferenciaCredito", SortingDirection.Descending) };
            return sorting;
        }

        public string NumeroCredito { get; set; }


        [DataSourceCriteria("descripcion='Presidente'or descripcion='Vicepresidente' ")]
        public Comision  FirmaAutorizado { get; set; }
        [DataSourceCriteria("descripcion='Tesorero' or descripcion='Cotesorero' ")]
        public Comision FirmaContador { get; set; }


        private void UpdateData()
        {
            CriteriaOperator criteria = new BinaryOperator("ReferenciaCredito", NumeroCredito, BinaryOperatorType.Equal);
            Creditos CreditoActual = ObjectSpace.FindObject<Creditos>(criteria);
            if (!ReferenceEquals(CreditoActual, null))
                {
                    CriteriaOperator criteriaPersona = new BinaryOperator("comision", FirmaAutorizado, BinaryOperatorType.Equal);
                    persona FirmaPresidente = ObjectSpace.FindObject<persona>(criteriaPersona);
                    CreditoActual.FirmaAutorizacion = FirmaPresidente.nombres + ' ' + FirmaPresidente.apellidos;

                    CriteriaOperator criteriaPersona2 = new BinaryOperator("comision", FirmaContador, BinaryOperatorType.Equal);
                    persona FirmaTesorero = ObjectSpace.FindObject<persona>(criteriaPersona2);
                    CreditoActual.FirmaContador = FirmaTesorero.nombres + ' ' + FirmaTesorero.apellidos;
                    

                    this.ObjectSpace.CommitChanges();
                }
            
        }
    }
}
