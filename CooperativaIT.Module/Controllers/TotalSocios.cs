using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using CooperativaIT.Module.Clases;
using DevExpress.Xpo;

namespace CooperativaIT.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class TotalSocios : ViewController
    {
        private IObjectSpace _ObjectSpaceCore;
        private DetailView _VistaPopup;
        public TotalSocios()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void popupSocios_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            ParametroSocio Parametro = (ParametroSocio)_VistaPopup.CurrentObject;
            //IEnumerable<TrasladoEscrituras> ObjetosSeleccionados = e.SelectedObjects.Cast<TrasladoEscrituras>();

            bool Validar = Parametro.Todos;

            if (Validar == true)
            {
                BinaryOperator BinaryClasificacion = new BinaryOperator("Clasificacion", 1, BinaryOperatorType.Equal);
                CriteriaOperator CriteriaPersona = CriteriaOperator.And(BinaryClasificacion);
                ICollection<persona> PersonasCollection = ObjectSpace.GetObjects<persona>(CriteriaPersona);

                if (!ReferenceEquals(PersonasCollection, null))
                {
                    foreach (persona ObjPersona in PersonasCollection)
                    {
                        FondosEncab objEncabezado = null;
                        int correlativo = 0;

                        //BinaryOperator Criteria = new BinaryOperator("Socio", ObjPersona, BinaryOperatorType.Equal);
                        //FondosEncab CurrentPer = this._ObjectSpaceCore.FindObject<FondosEncab>(Criteria);
                        //return CurrentUser;


                        BinaryOperator BinaryEncabezado = new BinaryOperator("Socio", ObjPersona, BinaryOperatorType.Equal);
                        FondosEncab Socio = this.ObjectSpace.FindObject<FondosEncab>(BinaryEncabezado);
                        if (ReferenceEquals(Socio, null))
                        {                          
                            FondosEncab obj = this.ObjectSpace.CreateObject<FondosEncab>();
                            obj.Socio = ObjPersona; 
                            if (this.View.ObjectSpace.IsModified)
                            {
                                this.View.ObjectSpace.CommitChanges();
                            }
                            objEncabezado = obj;
                        }
                        else
                        {
                            objEncabezado = Socio;
                        }



                        
                               
                        BinaryOperator BinaryOid = new BinaryOperator("FondosEncab",objEncabezado.Oid , BinaryOperatorType.Equal);
                        ICollection<FondosDetalle> EncabezadoDetalle = ObjectSpace.GetObjects<FondosDetalle>(BinaryOid);
                        int objconteo = EncabezadoDetalle.Count;

                        FondosDetalle union = null;


                        if (objconteo == 0)
                        {
                            FondosDetalle objDetalle = this.ObjectSpace.CreateObject<FondosDetalle>();
                            objDetalle.FondosEncab = objEncabezado;

                            //para crear el correlativo

                            int mes = Parametro.FechaAplicacion.Month;

                            objDetalle.Mes = mes;
                            objDetalle.año = Parametro.FechaAplicacion.Year;
                            objDetalle.FechaPago = Parametro.FechaPago;
                            objDetalle.TipoPago = Parametro.TipoFondos;
                            objDetalle.ValorPagado = Parametro.ValorPagado;
                            objDetalle.FechaAplicacion = Parametro.FechaAplicacion;
                        }

                        else 
                        {
                            BinaryOperator Binarymes = new BinaryOperator("Mes", Parametro.FechaAplicacion.Month, BinaryOperatorType.Equal);
                            BinaryOperator Binaryano = new BinaryOperator("año", Parametro.FechaAplicacion.Year, BinaryOperatorType.Equal);
                            CriteriaOperator DetalleCriteria = CriteriaOperator.And(BinaryOid, Binarymes, Binaryano);
                            union = this.ObjectSpace.FindObject<FondosDetalle>(DetalleCriteria);   
                    

                              if (ReferenceEquals(union, null))
                                {
                                    FondosDetalle objDetalle = this.ObjectSpace.CreateObject<FondosDetalle>();
                                    objDetalle.FondosEncab = objEncabezado;

                                    //para crear el correlativo
                          
                                    int mes = Parametro.FechaAplicacion.Month;
                                    objDetalle.Mes =mes;
                                    objDetalle.año = Parametro.FechaAplicacion.Year;
                                    objDetalle.FechaPago = Parametro.FechaPago;
                                    objDetalle.TipoPago = Parametro.TipoFondos;
                                    objDetalle.ValorPagado = Parametro.ValorPagado;
                                    objDetalle.FechaAplicacion = Parametro.FechaAplicacion;

                                }
                              else
                              {
                                  objEncabezado = Socio;
                              }
                        
                        }
                        

                        //FondosEncab objDetalle = null;
                      
                       
                        if (this.View.ObjectSpace.IsModified)
                        {
                            this.View.ObjectSpace.CommitChanges();
                        }
                      
                    }
                }


            }
            else{

                persona p = Parametro.socio;
                BinaryOperator BinaryEncabezados = new BinaryOperator("Socio", p, BinaryOperatorType.Equal);
                CriteriaOperator EncabezadoCriterias = CriteriaOperator.And(BinaryEncabezados);
                FondosEncab CurrentUser = this._ObjectSpaceCore.FindObject<FondosEncab>(EncabezadoCriterias);

                FondosEncab objEncabUno = null;

                if (ReferenceEquals(CurrentUser, null))
                {
                    FondosEncab objUno = this._ObjectSpaceCore.CreateObject<FondosEncab>();
                    objUno.Socio = p;
                    if (this.View.ObjectSpace.IsModified)
                    {
                        this.View.ObjectSpace.CommitChanges();
                    }
                    objEncabUno = objUno;
                }
                else
                {
                    //objEncabezado = Socio;
                }

                FondosDetalle objDetalle = this._ObjectSpaceCore.CreateObject<FondosDetalle>();
                objDetalle.FondosEncab = objEncabUno;
                objDetalle.FechaPago = Parametro.FechaPago;
                objDetalle.TipoPago = Parametro.TipoFondos;
                objDetalle.ValorPagado = Parametro.ValorPagado;
                objDetalle.FechaAplicacion = Parametro.FechaAplicacion;

                if (this.View.ObjectSpace.IsModified)
                {
                    this.View.ObjectSpace.CommitChanges();
                }

            }
        }

        private void popupSocios_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            _ObjectSpaceCore = this.Application.CreateObjectSpace();
            _VistaPopup = this.Application.CreateDetailView(_ObjectSpaceCore, _ObjectSpaceCore.CreateObject<ParametroSocio>());
            _VistaPopup.ViewEditMode = ViewEditMode.Edit;
            e.View = _VistaPopup;
        }

     
    }
}
