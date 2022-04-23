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
using DevExpress.ExpressApp.ConditionalAppearance;
using CooperativaIT.Module.BusinessObjects.Enums;
using CoopertativaIT.Module.BusinessObjects.Clases;
using DevExpress.ExpressApp.Editors;

namespace CooperativaIT.Module.Clases
{
    [DefaultClassOptions]
    [NavigationItem("Movimientos")]
    [FriendlyKeyProperty("referenciaCredito")]
    [ModelDefault("Caption", "Pagos")]
    [Appearance("CategoryColoredInListView", AppearanceItemType = "ViewItem", TargetItems = "EstadoCredito",
    Criteria = "EstadoCredito = 2", Context = "ListView", FontColor = "green", Priority = 1)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class EncabPagos : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public EncabPagos(Session session)
            : base(session)
        {
           
        }
        public override void AfterConstruction()
        {   

            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).


        }

        // Fields...
        private DateTime _FechaOtorgamiento;
        private double _ValorPagar;
        private double _IntFecha;
        private string _CantidaLetras;
        private EstadoCredito _EstadoCredito;
        private decimal _CapitalOtorgado;
        private clasificacion _Tipo;
        private string _Nombres;
        private Creditos _ReferenciaCredito;
        [ImmediatePostData]



        [RuleUniqueValue]
        [DataSourceCriteria("EstadoCredito=1")]
        public Creditos referenciaCredito
        {
            get
            {
                return _ReferenciaCredito;
            }
            set
            {
                SetPropertyValue("referenciaCredito", ref _ReferenciaCredito, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string nombres
        {
            get
            {
                if (!ReferenceEquals(referenciaCredito, null))
                {
                    string benefi = referenciaCredito.CodigoBeneficiario.nombres;
                    string ape = referenciaCredito.CodigoBeneficiario.apellidos;

                    _Nombres = benefi + " " + ape;
                }
                return _Nombres;
            }
            set
            {
                SetPropertyValue("nombres", ref _Nombres, value);
            }
        }

       
        public clasificacion tipo
        {
            get
            {
                if (!ReferenceEquals(referenciaCredito, null))
                {
                    _Tipo = referenciaCredito.CodigoBeneficiario.Clasificacion;
                }

                return _Tipo;
            }
            set
            {
                SetPropertyValue("tipo", ref _Tipo, value);
            }
        }
        [Appearance("CapitalOtorgado", Context = "DetailView", FontColor = "Blue", Priority = 1)]
        public decimal CapitalOtorgado
        {
            get
            {
                if (!ReferenceEquals(referenciaCredito, null))
                {
                    _CapitalOtorgado = referenciaCredito.CapitalOtorgado;
                }
                return _CapitalOtorgado;
            }
            set
            {
                SetPropertyValue("CapitalOtorgado", ref _CapitalOtorgado, value);
            }
        }
        [Appearance("FechaOtorgamiento", Context = "DetailView", FontColor = "Blue", Priority = 1)]
        public DateTime FechaOtorgamiento
        {
            get
            {
                if (!ReferenceEquals(referenciaCredito, null))
                {

                    _FechaOtorgamiento = referenciaCredito.FechaOtorgamiento;
                }

                return _FechaOtorgamiento;
            }
            set
            {
                SetPropertyValue("FechaOtorgamiento", ref _FechaOtorgamiento, value);
            }
        }

        [Appearance("Intfecha",  FontColor = "Green", Priority = 1)]
        [VisibleInListView(false)]
        [DevExpress.Xpo.DisplayName("Interés")]
        public double IntFecha
        {
            get
            {
                return _IntFecha;
            }
            set
            {
                SetPropertyValue("IntFecha", ref _IntFecha, value);
            }
        }
        [Appearance("ValorPagar",  FontColor = "Green",Priority =1)]
        [VisibleInListView(false)]
        //[VisibleInDetailView(false)]
        public double ValorPagar
        { 
            get
            {
                return _ValorPagar;
            }
            set
            {
                SetPropertyValue("ValorPagar", ref _ValorPagar, value);
            }
        }


        [Appearance("DisableProperty", Criteria = "1=1", Context = "ListView,DetailView", FontColor = "red", Priority = 1)]
        public EstadoCredito EstadoCredito
        {
            get
            {
                if (!ReferenceEquals(referenciaCredito, null))
                {
                    _EstadoCredito = referenciaCredito.EstadoCredito;
                }
                return _EstadoCredito;
            }
            set
            {
                SetPropertyValue("EstadoCredito", ref _EstadoCredito, value);
            }
        }


        [Appearance("CantidaLetras", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CantidaLetras
        {
            get
            {
                string _return = "";
                Funciones Funcion = new Funciones();
                _return = string.Format("{0} {1}", Funcion.enletras(CapitalOtorgado.ToString()), "DÓLAR(ES)");
                return _return;
                //return _CantidaLetras;
            }
            set
            {
                SetPropertyValue("CantidaLetras", ref _CantidaLetras, value);
            }
        }
        [Association("EncabPagos-DetallePagos"), DevExpress.Xpo.Aggregated()]
        public XPCollection<DetallePagos> DetallePagos
        {
            get
            {
                return GetCollection<DetallePagos>("DetallePagos");

            }

        }




        protected override void OnSaving()
        {

            if(this.Session.IsNewObject(this) && !ReferenceEquals(referenciaCredito, null))
            {
                var ListPagos = Session.Query<EncabPagos>().Where(f => f.referenciaCredito == this.referenciaCredito).ToList();
                if (ListPagos.Count > 0)
                {
                    throw new UserFriendlyException(message: "Ya existe un pago vinculado a este credito");
                }                
            }           
            
        }
     
    
    }
}
