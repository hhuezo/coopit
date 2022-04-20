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
using CooperativaIT.Module.BusinessObjects.Enums;

namespace CooperativaIT.Module.BusinessObjects.Catalogos
{
    [DefaultClassOptions]
    [NavigationItem("Configuración")]
    // [FriendlyKeyProperty("Persona")]
    public class Aportacion : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Aportacion(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            if (!IsDeleted)
            {
                DateTime fecha = DateTime.Now;
                if (Fecha.Year == 1)
                {
                    this.Fecha = fecha;
                    CargaMes(fecha.Month);
                    CalculoCantidad();

                }

            }
            
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        private DateTime _Fecha;
        private decimal _Cantidad;
        private Mes _Mes;
        private Socios _Socios;


        [ImmediatePostData]
        [RuleRequiredField]
        [DevExpress.Xpo.DisplayName("Socio")]
        [Association("Socios-Aportacion")]
        public Socios Socios
        {
            get
            {               
                return _Socios;
            }
            set
            {
                SetPropertyValue("Socios", ref _Socios, value);
            }
        }

        [ImmediatePostData]
        [RuleRequiredField]
        public Mes Mes
        {
            get
            {
                return _Mes;
            }
            set
            {
                SetPropertyValue("Mes", ref _Mes, value);
            }
        }


        [RuleRequiredField]
        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                SetPropertyValue("Fecha", ref _Fecha, value);
            }
        }

        [RuleRequiredField]
        [ModelDefault("EditMask", "#,###,##0.00")]
        [ModelDefault("DisplayFormat", "#,###,##0.00")]
        public decimal Cantidad
        {
            get
            {               
                return _Cantidad;
            }
            set
            {
                SetPropertyValue("Cantidad", ref _Cantidad, value);
            }
        }


        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (IsLoading || IsSaving)
            {
                return;
            }
            if (propertyName == "Socios")
            {
                if (!IsDeleted)
                {
                    CriteriaOperator Criteria = null;
                    Criteria = CriteriaOperator.Parse("Mes = [<Aportacion>][Socios=?].Max(Mes)", this.Socios);

                    Aportacion aportacion = this.Session.FindObject<Aportacion>(Criteria);

                    if (ReferenceEquals(aportacion, null))
                    {
                        this.Mes = Enums.Mes.Enero;
                        this.Cantidad = Socios.NumeroCuentas * 25;
                    }                  
                    else
                    {
                        this.Mes = aportacion.Mes + 1;
                        this.Cantidad = Socios.NumeroCuentas * 25;
                    }

                }

            }


        }






        private decimal CalculoCantidad()
        {
            decimal cantidad = 0;
            if(!ReferenceEquals(Socios,null))
            {
                cantidad = this.Socios.NumeroCuentas * 25;
            }


            return cantidad;

        }


        private void CargaMes(int mes)
        {
            switch (mes)
            {
                case 1:
                    this.Mes = Enums.Mes.Enero;
                    break;

                case 2:
                    this.Mes = Enums.Mes.Febrero;
                    break;

                case 3:
                    this.Mes = Enums.Mes.Marzo;
                    break;

                case 4:
                    this.Mes = Enums.Mes.Abril;
                    break;

                case 5:
                    this.Mes = Enums.Mes.Mayo;
                    break;

                case 6:
                    this.Mes = Enums.Mes.Junio;
                    break;

                case 7:
                    this.Mes = Enums.Mes.Julio;
                    break;

                case 8:
                    this.Mes = Enums.Mes.Agosto;
                    break;

                case 9:
                    this.Mes = Enums.Mes.Septiembre;
                    break;

                case 10:
                    this.Mes = Enums.Mes.Octubre;
                    break;

                case 11:
                    this.Mes = Enums.Mes.Noviembre;
                    break;

                case 12:
                    this.Mes = Enums.Mes.Diciembre;
                    break;
            }
        }


        protected override void OnSaving()
        {
            if (!IsDeleted)
            {             

                decimal cantidad = 0;
                decimal cantidad_validar = 0;
                foreach (Aportacion obj in Socios.Aportacion)
                {
                    if(this.Mes == obj.Mes)
                    {
                        cantidad += obj.Cantidad;
                    }
                    else
                    {
                        cantidad_validar += obj.Cantidad;
                    }
                }

                

                if (cantidad > (this.Socios.NumeroCuentas * 25))
                {
                    throw new UserFriendlyException("La cantidad ingresada no es valida");
                }

            }

        }
    
    
    }
      
}
