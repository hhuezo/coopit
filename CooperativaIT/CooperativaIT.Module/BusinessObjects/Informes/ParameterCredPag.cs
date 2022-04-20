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
    public class ParameterCredPag : ReportParametersObjectBase
    {
        public ParameterCredPag(IObjectSpaceCreator provider) : base(provider) { }
        protected override IObjectSpace CreateObjectSpace()
        {
            return objectSpaceCreator.CreateObjectSpace(typeof(object));
        }
        public override CriteriaOperator GetCriteria()
        {
            CriteriaOperator criteria = new BinaryOperator("ReferenciaCredito", NumeroCredito);
            return criteria;
        }
        public override SortProperty[] GetSorting()
        {
            SortProperty[] sorting = { new SortProperty("ReferenciaCredito", SortingDirection.Descending) };
            return sorting;
        }
      
        public string NumeroCredito { get; set; }

      
    }
}
