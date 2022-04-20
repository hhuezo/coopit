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
using System.Xml.Serialization;
using CooperativaIT.Module.BusinessObjects.Enums;
using DevExpress.ExpressApp.ConditionalAppearance;
using CooperativaIT.Module.BusinessObjects;
namespace CooperativaIT.Module.Clases
{

    
    
    [DefaultClassOptions]
    [DefaultProperty("nombres")]
    [FriendlyKeyProperty("apellidos")]
    [NavigationItem ("Registro")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class persona : Entidad

    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public persona(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this._Clasificacion = BusinessObjects.Enums.clasificacion.Socio;
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        // Fields...
      
     
        private Comision _Comision;
       private string _Telefono;
        private string _DUI;
        private clasificacion  _Clasificacion;
        private string _Apellidos;
   
        private string _Nombres;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string nombres
        {
            get
            {
                return _Nombres;
            }
            set
            {
                SetPropertyValue("nombres", ref _Nombres, value);
            }

        }

    
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string apellidos
        {
        	get
        	{
        		return _Apellidos;
        	}
        	set
        	{
        	  SetPropertyValue("apellidos", ref _Apellidos, value);
        	}
        }


        [ImmediatePostData]
        public clasificacion  Clasificacion
        {
        	get
        	{
        		return _Clasificacion;
        	}
        	set
        	{
        	  SetPropertyValue("Clasificacion", ref _Clasificacion, value);
        	}
        }

        [Appearance("Estado", Enabled = false, Criteria = "Clasificacion = 2")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Comision comision
        {
            get
            {
               return _Comision;
             }
               
            set
            {
                SetPropertyValue("comision", ref _Comision, value);
            }
        }

        


        [ModelDefault("EditMask","00000000-0")]
        [Size(11)]
        
        public string DUI
        {
            get
            {
                return _DUI;
            }
            set
            {
                SetPropertyValue("DUI", ref _DUI, value);
            }
        }

       
        [ModelDefault("EditMask","(000)-0000-0000")]
        [Size(15)]
        public string telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                SetPropertyValue("telefono", ref _Telefono, value);
            }
        }
        
        
         
    }

}
