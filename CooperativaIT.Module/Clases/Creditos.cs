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
using CooperativaIT.Module.BusinessObjects.Enums;
using CooperativaIT.Module.BusinessObjects;
using CoopertativaIT.Module.BusinessObjects.Clases;



namespace CooperativaIT.Module.Clases
{
    [DefaultClassOptions]
    [NavigationItem("Movimientos")]
    [FriendlyKeyProperty("ReferenciaCredito")]
    [Appearance("CategoryColoredInListView", AppearanceItemType = "ViewItem", TargetItems = "EstadoCredito",
    Criteria = "EstadoCredito = 2" , Context = "ListView", FontColor = "green", Priority = 1)]
  
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class Creditos : Entidad

    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Creditos(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {

            if (this.Session.IsNewObject(this))
            {
                DateTime fecha = DateTime.Now;
                if (FechaOtorgamiento.Year == 1)
                {
                    this.FechaOtorgamiento = fecha;
                }
            }

            if (ReferenceEquals(this.ReferenciaCredito, null))
               {
                   this.EstadoCredito = BusinessObjects.Enums.EstadoCredito.Activo;
                   
                   BinaryOperator Criteria = new BinaryOperator("tasa_interes", 5);
                   TasaInteres tasa = this.Session.FindObject<TasaInteres>(Criteria);
                    if(!ReferenceEquals(tasa, null))
                    {
                        codigoTasaInteres = tasa;
                    }


                 BinaryOperator Criteria2 = new BinaryOperator("descripcion", "A");
                 Calificacion calificacion = this.Session.FindObject<Calificacion>(Criteria2);
                   if (!ReferenceEquals(calificacion, null))
                    {
                        this.CodigoCalificacion = calificacion;
                    }
               }
          //  this.EstadoCredito = BusinessObjects.Enums.EstadoCredito.Activo;

            base.AfterConstruction();
           
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).


          
        }
        // Fields...
        private string _CodigoCredito;
        private string _FirmaContador;
     
        private string _FirmaAutorizacion;
        private EstadoCredito _EstadoCredito;
        private int _ContNum;
        private string _ReferenciaCredito;
        private Decimal _ValorUltimaCuota;
        private Decimal _ValorCuota;
        private Decimal _ValorInteres;
        private DateTime _FechaOtorgamiento;
        private Decimal _CapitalOtorgado;
        private int _NumeroCuotas;
        private Calificacion _CodigoCalificacion;
        private TasaInteres _CodigoTasaInteres;
        private persona _CodigoBeneficiario;
        private string _CantidaLetras;


       /* [Appearance("CodigoCredito", Enabled = false, Visibility = ViewItemVisibility.Hide)]
        [NonPersistent]
        public string CodigoCredito
        {
            get
            {

                if (!ReferenceEquals(this.CodigoBeneficiario, null) && !ReferenceEquals(this.ReferenciaCredito, null))
                {
                    BinaryOperator Criteria = new BinaryOperator("Oid", this.CodigoBeneficiario.Oid);
                    this.persona = this.Session.FindObject<persona>(Criteria);
                    if (!ReferenceEquals(persona, null))
                    {
                        _CodigoCredito = this.ReferenciaCredito + " - " + persona.nombres + " " + persona.apellidos;
                    }
                }
                return _CodigoCredito;
            }
            set
            {
                SetPropertyValue("CodigoCredito", ref _CodigoCredito, value);
            }
        }*/

       [Appearance("contNum", Visibility = ViewItemVisibility.Hide, Criteria = "!IsCurrentUserInRole('Administrators')")]        
        public int contNum
        {
            get
            {
                return _ContNum;
            }
            set
            {
                SetPropertyValue("contNum", ref _ContNum, value);
            }
        }
        /*[Appearance("ReferenciaCredito", Enabled = true, Criteria = "!IsCurrentUserInRole('Administrators')")]*/
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ReferenciaCredito
        {
            get
            {
                return _ReferenciaCredito;
            }
            set
            {
                SetPropertyValue("ReferenciaCredito", ref _ReferenciaCredito, value);
            }
        }

        [DevExpress.Xpo.DisplayName("Nombres")]
        public persona CodigoBeneficiario
        {
            get
            {
                return _CodigoBeneficiario;
            }
            set
            {
                SetPropertyValue("CodigoBeneficiario", ref _CodigoBeneficiario, value);
            }
        }

        public TasaInteres codigoTasaInteres
        {
            get
            {
                return _CodigoTasaInteres;
            }
            set
            {
                SetPropertyValue("codigoTasaInteres", ref _CodigoTasaInteres, value);
            }
        }

        public Calificacion CodigoCalificacion
        {
            get
            {
                return _CodigoCalificacion;
            }
            set
            {
                SetPropertyValue("CodigoCalificacion", ref _CodigoCalificacion, value);
            }
        }

        public int NumeroCuotas
        {
            get
            {
                return _NumeroCuotas;
            }
            set
            {
                SetPropertyValue("NumeroCuotas", ref _NumeroCuotas, value);
            }
        }
       [ModelDefault("EditMask", "#,###,##0.000")]
       [ModelDefault("DisplayFormat", "#,###,##0.00")]
        public decimal CapitalOtorgado
        {
            get
            {
                return _CapitalOtorgado;
            }
            set
            {
                SetPropertyValue("CapitalOtorgado", ref _CapitalOtorgado, value);
            }
        }


        public DateTime FechaOtorgamiento
        {
            get
            {
                return _FechaOtorgamiento;
            }
            set
            {
                SetPropertyValue("FechaOtorgamiento", ref _FechaOtorgamiento, value);
            }
        }

        [Appearance("DisableProperty", Criteria = "1=1", Context = "ListView", FontColor = "red", Priority = 1)]
               public EstadoCredito EstadoCredito
        {
            get
            {
                return _EstadoCredito;
            }
            set
            {
                SetPropertyValue("EstadoCredito", ref _EstadoCredito, value);
            }
        }
        

        [ModelDefault("EditMask", "#,###,##0.00")]
        [ModelDefault("DisplayFormat", "#,###,##0.00")]
        [Appearance("ValorCuota", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public Decimal ValorCuota
        {
            get
            {
               
                return _ValorCuota;
            }
            set
            {
                SetPropertyValue("ValorCuota", ref _ValorCuota, value);
            }
        }
        [ModelDefault("EditMask", "#,###,##0.00")]
        [ModelDefault("DisplayFormat", "#,###,##0.00")]
        [Appearance("ValorInteres", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public Decimal ValorInteres
        {
            get
            {
               
                return _ValorInteres;
            }
            set
            {
                SetPropertyValue("valorInteres", ref _ValorInteres, value);
            }
        }
        [ModelDefault("EditMask", "#,###,##0.00")]
        [ModelDefault("DisplayFormat", "#,###,##0.00")]
        [Appearance("valor_ultima_cuota", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public Decimal valor_ultima_cuota
        {
            get
            {
                return _ValorUltimaCuota;
            }
            set
            {
                SetPropertyValue("ValorUltimaCuota", ref _ValorUltimaCuota, value);
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

        private void Calculo()
        {
            if (!ReferenceEquals(CodigoBeneficiario, null))
            {
                double i = ((double)codigoTasaInteres.tasa_interes) / (double)100;
                ValorInteres = (decimal)i * CapitalOtorgado;

                double valor;
                double elevacion;
                valor = (1.0 + i);
                elevacion = NumeroCuotas;
            
                double result = Math.Pow(valor,elevacion);       
                            
                    double L = (double)CapitalOtorgado * (i * result ) / (result - 1);
                    ValorCuota = (decimal)L;
                
            }
           
        
        }

         [Appearance("FirmaAutorizacion", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FirmaAutorizacion
        {
            get
            {
                return _FirmaAutorizacion;
            }
            set
            {
                SetPropertyValue("FirmaAutorizacion", ref _FirmaAutorizacion, value);
            }
        }


         [Appearance("FirmaContador", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FirmaContador
        {
            get
            {
                return _FirmaContador;
            }
            set
            {
                SetPropertyValue("FirmaContador", ref _FirmaContador, value);
            }
        }

        private void correlativo()
        {
            if (!ReferenceEquals(CodigoBeneficiario, null) && contNum ==0)
            {
                int max = 0;
                //Creditos obj = Session.FindObject<Creditos>(CriteriaOperator.Parse("contNum>0 and contNum = [<Creditos>][contNum >0].Max(contNum)"));
                //if (!ReferenceEquals(obj, null))
                //{
                //    contNum = obj.contNum + 1;
                //}
                //else
                //{
                //    contNum = 1;
                //}
                //Este es para un incremento de una lista
                var ListFechas = Session.Query<Creditos>().Where(f => f.contNum > 0).ToList();
                if (!ReferenceEquals(ListFechas, null))
                {
                    foreach (Creditos ObjCredito in ListFechas)
                    {
                        if (ObjCredito.contNum > max)
                        {
                            max = ObjCredito.contNum;
                        }
                    }
                    contNum = max + 1;
                }
                else
                {
                    contNum = 1;
                }

                ReferenciaCredito = contNum.ToString("D4");

                //CriteriaOperator Criteria = null;
                //int secuencia = 1;
                //int VarActivo = 0;
                //Criteria = CriteriaOperator.Parse("contNum = [<Credito>].Max(contNum)");

                //Creditos credito = this.Session.FindObject<Creditos>(Criteria);

                //if (credito != null)
                //{
                //    VarActivo = Int32.Parse(activo.Correlativo);
                //    Criteria = CriteriaOperator.Parse("Correlativo = [<Activo>][SubClase=?].Max(CorrelativoInt)", SubClase);
                //    credito = this.Session.FindObject<Creditos>(Criteria);
                //    secuencia = credito.contNum + 1;
                //}
                //else
                //{
                //    secuencia = 1;
                //}
                //contNum = secuencia;
                //ReferenciaCredito = secuencia.ToString("D3");
            }


        
        }

        //private void GrabarEncab()
        //{
        //    int max = 0;
        //    if (!ReferenceEquals(CodigoBeneficiario, null))
        //    {
        //        //var ListPagos = Session.Query<DetallePagos>().Where(f => f.PagosEncab == this.PagosEncab).ToList();
        //        var ListCred = Session.Query<Creditos>().Where(f => f.contNum > 0).ToList();
        //        if (!ReferenceEquals(ListCred, null))
        //        {
        //            foreach (Creditos Encabgrab in ListCred)
        //            {
        //                if (Encabgrab.contNum > max)
        //                {
        //                    max = Encabgrab.contNum;
                           
        //                    ReferenciaCredito = Encabgrab.ReferenciaCredito;
                            
                            
        //                }

        //            }

                    


        //        }


        //    }
           

        //}
 
        
        
        
        private void generarPago()
        {
            if (this.Session.IsNewObject(this) && !ReferenceEquals(CodigoBeneficiario, null))
            {
                if (!ReferenceEquals(ReferenciaCredito, null))
                {
                    BinaryOperator binaryReferencia = new BinaryOperator("referenciaCredito.ReferenciaCredito", ReferenciaCredito);
                    EncabPagos pago = this.Session.FindObject<EncabPagos>(binaryReferencia);
                    if (ReferenceEquals(pago, null))
                    {
                        EncabPagos obj = new EncabPagos(Session);
                        obj.referenciaCredito = this;
                        obj.nombres = CodigoBeneficiario.nombres + ' ' + CodigoBeneficiario.apellidos;
                        obj.tipo = CodigoBeneficiario.Clasificacion;
                        obj.CapitalOtorgado = this.CapitalOtorgado;
                        obj.FechaOtorgamiento = this.FechaOtorgamiento;
                        obj.EstadoCredito = BusinessObjects.Enums.EstadoCredito.Activo;
                        obj.CantidaLetras = this.CantidaLetras;
                        obj.Save();
                    }

                }
            }
        }
        
        protected override void OnSaving()
        {

           
             

            if (!ReferenceEquals(CodigoBeneficiario, null))
            {

                Calculo();
                correlativo();

               

            }
        }




        [Appearance("persona", Enabled = false, Visibility = ViewItemVisibility.Hide)]
        public persona persona { get; set; }
    }

}
