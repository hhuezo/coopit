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
    public class ParameterPagos : ReportParametersObjectBase
    {
        public ParameterPagos(IObjectSpaceCreator provider) : base(provider) { 
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
            CriteriaOperator criteria = new BinaryOperator("NumeroRecibo", NumeroRecibo);
            return criteria;
        }
        public override SortProperty[] GetSorting()
        {
            SortProperty[] sorting = { new SortProperty("correla", SortingDirection.Descending) };
            return sorting;
        }

        public string NumeroRecibo { get; set; }
        [DataSourceCriteria("descripcion='Tesorero' or descripcion='Cotesorero' ")]
        public Comision FirmaContador { get; set; }

        private void UpdateData()
        {
            CriteriaOperator criteria = new BinaryOperator("NumeroRecibo", NumeroRecibo, BinaryOperatorType.Equal);
            DetallePagos CreditoActual = ObjectSpace.FindObject<DetallePagos>(criteria);
            if (!ReferenceEquals(CreditoActual, null))
            {
               

                CriteriaOperator criteriaPersona2 = new BinaryOperator("comision", FirmaContador, BinaryOperatorType.Equal);
                persona FirmaTesorero = ObjectSpace.FindObject<persona>(criteriaPersona2);
                CreditoActual.FirmaContador = FirmaTesorero.nombres + ' ' + FirmaTesorero.apellidos;


                this.ObjectSpace.CommitChanges();
            }

        }

    }
}
