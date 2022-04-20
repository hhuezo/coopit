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
using CooperativaIT.Module.Clases;
using DevExpress.ExpressApp.ConditionalAppearance;
using CooperativaIT.Module.BusinessObjects;
using CooperativaIT.Module.BusinessObjects.Enums;
using DevExpress.ExpressApp.Editors;
using CoopertativaIT.Module.BusinessObjects.Clases;



namespace CooperativaIT.Module.Clases
{
    [DefaultClassOptions]
    [NavigationItem("Movimientos")]
    
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class DetallePagos : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public DetallePagos(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
             //Parse("correla>0 and correla = [<DetallePagos>][correla >0].Max(correla)"));
            
            base.AfterConstruction();
            this._TipoPago = BusinessObjects.Enums.TiposPago.Cuota;
           
            

                }

        // Fields...

        private int _Tiempo_int;
        private decimal _SaldoPagar;
        private string _CantidaLetras;
        private bool _Guardado;
        private int _Correla;
        private decimal _TotalPagado;
        private decimal _AbonoIntereses;
        private decimal _saldoActual;
        private decimal _AbonoCapital;
        private decimal _SaldoPendiente;
        private TiposPago _TipoPago;
        private DateTime _FechaPago;
        private string _NumeroRecibo;
        private EncabPagos _PagosEncab;
        DateTime fechapagant;
        DateTime fecharef;
        decimal totasaldo = 0;
        decimal salpen = 0;
        decimal abonocap = 0;
        decimal valor_inicial;
        decimal capitalIni = 0;
        int mestiempo;
        private string _FirmaContador;

        [Association("EncabPagos-DetallePagos")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public EncabPagos PagosEncab
        {
            get
            {
                return _PagosEncab;
            }
            set
            {
                SetPropertyValue("PagosEncab", ref _PagosEncab, value);
            }
        }

        [Appearance("correla", Visibility = ViewItemVisibility.Hide, Criteria = "!IsCurrentUserInRole('Administrators')")]   
       
        public int correla
        {
            get
            {

                return _Correla;
            }

            set
            {
                SetPropertyValue("correla", ref _Correla, value);
            }
        }

        [Appearance("NumeroRecibo", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        [ModelDefault("EditMask", "0000")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NumeroRecibo
        {
            get
            {

                return _NumeroRecibo;



            }
            set
            {
                SetPropertyValue("NumeroRecibo", ref _NumeroRecibo, value);
            }
        }

        public DateTime FechaPago
        {
            get
            {

                return _FechaPago;
            }
            set
            {
                SetPropertyValue("FechaPago", ref _FechaPago, value);
            }
        }


        public TiposPago TipoPago
        {
            get
            {
                return _TipoPago;
            }
            set
            {
                SetPropertyValue("TipoPago", ref _TipoPago, value);
            }
        }
        [ModelDefault("EditMask", "#,###,##0.00")]
        [ModelDefault("DisplayFormat", "#,###,##0.00")]
        public decimal TotalPagado
        {
            get
            {

                return _TotalPagado;
            }
            set
            {
                SetPropertyValue("TotalPagado", ref _TotalPagado, value);
            }
        }
        [ModelDefault("EditMask", "#,###,##0.00")]
        [ModelDefault("DisplayFormat", "#,###,##0.00")]
        [Appearance("AbonoIntereses", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public decimal AbonoIntereses
        {
            get
            {
               
                
                return _AbonoIntereses;
            }
            set
            {
                SetPropertyValue("AbonoIntereses", ref _AbonoIntereses, value);
            }
        }

        [ModelDefault("EditMask", "#,###,##0.00")]
        [ModelDefault("DisplayFormat", "#,###,##0.00")]
        [Appearance("AbonoCapital", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public decimal AbonoCapital
        {
            get
            {
                //if (!ReferenceEquals(this.TotalPagado, null))
                //{
                //    _AbonoCapital = (_TotalPagado - _AbonoIntereses);
                //}

                return _AbonoCapital;
            }
            set
            {
                SetPropertyValue("AbonoCapital", ref _AbonoCapital, value);
            }
        }



        [ModelDefault("EditMask", "#,###,##0.00")]
        [ModelDefault("DisplayFormat", "#,###,##0.00")]
        [Appearance("SaldoPendiente", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public decimal SaldoPendiente
        {
            get
            {
               

                return _SaldoPendiente;
            }
            set
            {
                SetPropertyValue("SaldoPendiente", ref _SaldoPendiente, value);
            }
        }

        [ModelDefault("EditMask", "#,###,##0.00")]
        [ModelDefault("DisplayFormat", "#,###,##0.00")]
        [Appearance("saldoActual", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public decimal saldoActual
        {
            get
            {

                return _saldoActual;
            }
            set
            {
                SetPropertyValue("saldoActual", ref _saldoActual, value);
            }
        }

         [Appearance("SaldoPagar", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public decimal SaldoPagar
        {
            get
            {
                return _SaldoPagar;
            }
            set
            {
                SetPropertyValue("SaldoPagar", ref _SaldoPagar, value);
            }
        }

        [Appearance("ReferenciaCredito", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CantidaLetras
        {
            get
            {
                string _return = "";
                Funciones Funcion = new Funciones();
                _return = string.Format("{0} {1}", Funcion.enletras(TotalPagado.ToString()), "DÓLAR(ES)");
                return _return;
                //return _CantidaLetras;
            }
            set
            {
                SetPropertyValue("CantidaLetras", ref _CantidaLetras, value);
            }
        }
        [Appearance("FirmaContador", Visibility = ViewItemVisibility.Hide, Criteria = "!IsCurrentUserInRole('Administrators')")]
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
         [Appearance("Guardado", Visibility = ViewItemVisibility.Hide, Criteria = "!IsCurrentUserInRole('Administrators')")]     
        public bool Guardado
        {
            get
            {
                return _Guardado;
            }
            set
            {
                SetPropertyValue("Guardado", ref _Guardado, value);
            }
        }


         [VisibleInListView(false)]
         [VisibleInDetailView(false)]
         public int tiempo_int
         {
             get
             {
                 return _Tiempo_int;
             }
             set
             {
                 SetPropertyValue("tiempo_int", ref _Tiempo_int, value);
             }
         }

        private void correlativo()
        {
            if (!ReferenceEquals(PagosEncab, null) && correla == 0)
            {
                int NumeroRe = 0;
                int max = 0;
                BinaryOperator Criteria = new BinaryOperator("PagoEncab", PagosEncab );
                DetallePagos obj = Session.FindObject<DetallePagos>(CriteriaOperator.Parse("NumeroRecibo >0  and NumeroRecibo = [<DetallePagos>][NumeroRecibo >0].Max(NumeroRecibo)", Criteria));
                var ListPagosEn = Session.Query<DetallePagos>().Where(f => f.PagosEncab == PagosEncab).ToList();
                if (!ReferenceEquals(obj, null))
                {
                    NumeroRe = Convert.ToInt16(obj.NumeroRecibo) + 1 ;                
                }
                else
                {
                    NumeroRe = 1 ;
                }

                NumeroRecibo = NumeroRe.ToString("D4");
                //contNum.ToString("D4")

                var ListPagos = Session.Query<DetallePagos>().Where(f => f.PagosEncab == this.PagosEncab).ToList();

                int correlativo = 0;
                decimal saldo = 0;
                decimal TotalAintcap = 0;
                decimal AbonoAcumulado = 0;
                int dias_dif = 0;

                // calculo de interesa
                int tasa = PagosEncab.referenciaCredito.codigoTasaInteres.tasa_interes;
                double tasa_i = (double)tasa / (double)100;


                foreach (DetallePagos detalle in ListPagos)
                {

                    if (detalle.correla > correlativo)
                    {
                        correlativo = detalle.correla;
                        saldo = detalle.saldoActual;
                        fechapagant = detalle.FechaPago;
                        salpen = detalle.SaldoPendiente;
                        abonocap = detalle.AbonoCapital;


                    }


                }

                correlativo++;

                correla = correlativo;


                if (correla == 1)
                {

                    valor_inicial = PagosEncab.CapitalOtorgado;
                    SaldoPagar = valor_inicial;
                 
                    DateTime fechaotroga = PagosEncab.referenciaCredito.FechaOtorgamiento;
                    //calculo del tiempo
                    TimeSpan diferencia;
                    diferencia = FechaPago - PagosEncab.referenciaCredito.FechaOtorgamiento;
                    int tiempo = diferencia.Days;
                    
                    if (FechaPago.Year > PagosEncab.referenciaCredito.FechaOtorgamiento.Year)
                    {
                        mestiempo = Math.Abs((FechaPago.Month - PagosEncab.referenciaCredito.FechaOtorgamiento.Month) + 12 * (FechaPago.Year - PagosEncab.referenciaCredito.FechaOtorgamiento.Year));
                    }

                    else
                    {

                        double totaldias = diferencia.Days;
                        double meses = totaldias / 30;
                        double resto = totaldias % 30;
                        if (resto >= 1 && resto <= 6)
                        {
                            mestiempo = (int)Math.Floor(meses);
                        }
                        else
                        {
                            mestiempo = (int)Math.Ceiling(meses);
                        }
                   
                    }
                                     
                    decimal Aint = 0;
                    decimal captot = 0;

                   
                    if (FechaPago.Month != PagosEncab.referenciaCredito.FechaOtorgamiento.Month)
                    {
                        if (FechaPago.Year == fechaotroga.Year)
                        {
                            //provisional
                            var cultureInfo = new System.Globalization.CultureInfo("de-DE");
                            String fechadate = "31 May 2020";
                            fecharef = DateTime.Parse(fechadate, cultureInfo);
                            if (FechaPago > fecharef)
                            {
                                //esto es provisional
                                for (int i = 0; i < mestiempo; i++)
                                {

                                    if (i == 0)
                                    {
                                        capitalIni = SaldoPagar;
                                        Aint = (decimal.Round((decimal)tasa_i * SaldoPagar, 2, MidpointRounding.AwayFromZero));
                                    }
                                    else
                                    {
                                        capitalIni = saldo;
                                        Aint = (decimal.Round((decimal)tasa_i * capitalIni, 2, MidpointRounding.AwayFromZero));
                                    }

                                    if (PagosEncab.referenciaCredito.CodigoBeneficiario.Clasificacion == clasificacion.Socio)
                                    {

                                        TotalAintcap = AbonoAcumulado;
                                        AbonoIntereses = TotalAintcap;
                                        captot = capitalIni;
                                        saldo = captot;

                                    }
                                    else
                                    {
                                        AbonoAcumulado = AbonoAcumulado + Aint;
                                        TotalAintcap = AbonoAcumulado;
                                        AbonoIntereses = TotalAintcap;
                                        captot = capitalIni;
                                        saldo = captot;
                                    }

                                }
                            }
                            else
                            {

                                for (int i = 0; i < mestiempo; i++)
                                {

                                    if (i == 0)
                                    {
                                        capitalIni = SaldoPagar;
                                        Aint = (decimal.Round((decimal)tasa_i * SaldoPagar, 2, MidpointRounding.AwayFromZero));
                                    }
                                    else
                                    {
                                        capitalIni = saldo;
                                        Aint = (decimal.Round((decimal)tasa_i * capitalIni, 2, MidpointRounding.AwayFromZero));
                                    }

                                    AbonoAcumulado = AbonoAcumulado + Aint;
                                    TotalAintcap = Aint;
                                    AbonoIntereses = TotalAintcap;
                                    captot = capitalIni + Aint;
                                    saldo = captot;



                                }



                            }
                        }
                        // verificar este cuando el año es diferente
                        else //if ((FechaPago.Month == PagosEncab.referenciaCredito.FechaOtorgamiento.Month) && (FechaPago.Year == fechaotroga.Year) && (fechaotroga.Day > 25))
                        {

                            for (int i = 0; i < mestiempo; i++)
                            {

                                if (i == 0)
                                {
                                    capitalIni = SaldoPagar;
                                    Aint = (decimal.Round((decimal)tasa_i * SaldoPagar, 2, MidpointRounding.AwayFromZero));
                                    //AbonoIntereses = AbonoIntereses + Aint;
                                }
                                else
                                {
                                    capitalIni = saldo;
                                    Aint = (decimal.Round((decimal)tasa_i * capitalIni, 2, MidpointRounding.AwayFromZero));

                                }

                                AbonoAcumulado = AbonoAcumulado + Aint;
                                TotalAintcap = Aint;
                                AbonoIntereses = TotalAintcap;
                                captot = capitalIni + Aint;
                                saldo = captot;


                            }

                        }

                        //esto son los datos que se reflejan
                        if (TotalPagado <  TotalAintcap )
                        {

                            decimal intcapitalizado = TotalAintcap - TotalPagado;
                            AbonoCapital = 0;
                            AbonoIntereses = TotalPagado;
                            saldoActual = decimal.Round((capitalIni + intcapitalizado) - AbonoCapital, 2, MidpointRounding.AwayFromZero);
                            totasaldo = decimal.Round(saldoActual, 2, MidpointRounding.AwayFromZero);
                            SaldoPagar = totasaldo;
                        }
                        else
                        {
                            AbonoCapital = decimal.Round(TotalPagado - AbonoAcumulado, 2, MidpointRounding.AwayFromZero);
                            saldoActual = decimal.Round(capitalIni - AbonoCapital, 2);
                            totasaldo = decimal.Round(capitalIni - AbonoCapital, 2, MidpointRounding.AwayFromZero);
                            SaldoPagar = capitalIni;

                            //AbonoCapital = decimal.Round(TotalPagado - TotalAintcap, 2, MidpointRounding.AwayFromZero);
                            //saldoActual = decimal.Round(capitalIni - AbonoCapital, 2);
                            //totasaldo = decimal.Round(capitalIni - AbonoCapital, 2, MidpointRounding.AwayFromZero);
                            //SaldoPagar = capitalIni;
                        }
                        if (totasaldo <= (decimal)0.01)
                        {
                            saldoActual = 0;
                        }
                        else
                        {
                            saldoActual = totasaldo;
                        }

                        // saldo pendiente
                        decimal prest = ((saldoActual * (decimal)tasa_i) + saldoActual);
                        SaldoPendiente = prest;


                    }
                    else
                    {
                        if ((FechaPago.Month == PagosEncab.referenciaCredito.FechaOtorgamiento.Month) && (FechaPago.Year == fechaotroga.Year) && (fechaotroga.Day > 25))
                        {
                            SaldoPagar = PagosEncab.referenciaCredito.CapitalOtorgado;

                            AbonoIntereses = 0;
                            AbonoCapital = decimal.Round(TotalPagado - AbonoIntereses, 2);
                            saldoActual = decimal.Round(SaldoPagar - AbonoCapital, 2);
                            totasaldo = decimal.Round(SaldoPagar - AbonoCapital, 2);
                            //SaldoPagar = valor_inicial - saldoActual;

                            //esto son los datos que se reflejan
                            AbonoCapital = decimal.Round(TotalPagado - AbonoIntereses, 2, MidpointRounding.AwayFromZero);
                            totasaldo = decimal.Round(SaldoPagar - AbonoCapital, 2, MidpointRounding.AwayFromZero);
                            if (totasaldo <= (decimal)0.01)
                            {
                                saldoActual = 0;
                            }
                            else
                            {
                                saldoActual = totasaldo;
                            }
                            // saldo pendiente
                            decimal prest = ((saldoActual * (decimal)tasa_i) + saldoActual);
                            SaldoPendiente = prest;


                        }
                        else
                        {
                           
                            
                            for (int i = 0; i < mestiempo; i++)
                            {

                                if (i == 0)
                                {
                                    capitalIni = SaldoPagar;
                                    Aint = (decimal.Round((decimal)tasa_i * SaldoPagar, 2, MidpointRounding.AwayFromZero));
                                }
                                else
                                {
                                    capitalIni = saldo;
                                    Aint = (decimal.Round((decimal)tasa_i * capitalIni, 2, MidpointRounding.AwayFromZero));
                                }

                                AbonoAcumulado = AbonoAcumulado + Aint;
                                TotalAintcap = Aint;
                                AbonoIntereses = TotalAintcap;
                                captot = capitalIni + Aint;
                                saldo = captot;


                            }
                            if (TotalPagado < AbonoIntereses)
                            {

                                
                                decimal intcapitalizado = AbonoIntereses - TotalPagado;
                                AbonoCapital = 0;
                                AbonoIntereses = TotalPagado;
                                saldoActual = decimal.Round((capitalIni + intcapitalizado) - AbonoCapital, 2, MidpointRounding.AwayFromZero);
                                totasaldo = decimal.Round(saldoActual, 2, MidpointRounding.AwayFromZero);
                                SaldoPagar = totasaldo;
                            }
                            else
                            //esto son los datos que se reflejan
                            AbonoCapital = decimal.Round(TotalPagado - AbonoIntereses, 2, MidpointRounding.AwayFromZero);
                            totasaldo = decimal.Round(SaldoPagar - AbonoCapital, 2, MidpointRounding.AwayFromZero);
                            if (totasaldo <= (decimal)0.01)
                            {
                                saldoActual = 0;
                            }
                            else
                            {
                                saldoActual = totasaldo;
                            }

                            // saldo pendiente
                            decimal prest = ((saldoActual * (decimal)tasa_i) + saldoActual);
                            SaldoPendiente = prest;
                        }
                    }
                }

                // empieza cuando ya existe un Pagos
                else
                {
                    valor_inicial = saldo;
                    SaldoPagar = valor_inicial;
                    // calculo de tiempo ya realizado un pago
                    TimeSpan diferencia1;
                    diferencia1 = (FechaPago - fechapagant);
                    int tiempo = diferencia1.Days;
                    decimal Aint = 0;
                    decimal captot = 0;
                    decimal prest = 0;
                    if (FechaPago.Year > fechapagant.Year)
                    {
                        mestiempo = Math.Abs((FechaPago.Month - fechapagant.Month) + 12 * (FechaPago.Year - fechapagant.Year));
                    }

                    else
                    {
                        double totaldias = diferencia1.Days;
                        double meses = totaldias / 30;
                        double resto = totaldias % 30;
                        if (resto >= 1 && resto <= 10)
                        {
                            mestiempo  = (int)Math.Floor(meses);
                        }
                        else
                        {
                            mestiempo = (int)Math.Ceiling(meses);
                        }
                    }
                    // calculo de interes
                   
                    if (FechaPago.Month != fechapagant.Month)
                    {
                        if (FechaPago.Year == fechapagant.Year)
                        {
                            var cultureInfo = new System.Globalization.CultureInfo("de-DE");
                            String fechadate = "31 May 2020";
                            fecharef = DateTime.Parse(fechadate, cultureInfo);



                            if (FechaPago > fecharef)
                            {
                                //esto es provisional
                                for (int i = 0; i < mestiempo; i++)
                                {

                                    if (i == 0)
                                    {
                                        capitalIni = SaldoPagar;
                                        Aint = (decimal.Round((decimal)tasa_i * SaldoPagar, 2, MidpointRounding.AwayFromZero));
                                    }
                                    else
                                    {
                                        capitalIni = saldo;
                                        Aint = (decimal.Round((decimal)tasa_i * capitalIni, 2, MidpointRounding.AwayFromZero));
                                    }
                                    if (PagosEncab.referenciaCredito.CodigoBeneficiario.Clasificacion == clasificacion.Socio)
                                        
                                    {
                                        
                                        TotalAintcap = AbonoAcumulado;
                                        AbonoIntereses = TotalAintcap;
                                        captot = capitalIni ;
                                        saldo = captot;

                                    }
                                    else
                                    {
                                    AbonoAcumulado = AbonoAcumulado + Aint;
                                    TotalAintcap = AbonoAcumulado;
                                    AbonoIntereses = TotalAintcap;
                                    captot = capitalIni ;
                                    saldo = captot;}

                                }
                            }
                            else
                            {
                                for (int i = 0; i < mestiempo; i++)
                                {

                                    if (i == 0)
                                    {
                                        capitalIni = SaldoPagar;
                                        Aint = (decimal.Round((decimal)tasa_i * SaldoPagar, 2, MidpointRounding.AwayFromZero));
                                    }
                                    else
                                    {
                                        capitalIni = saldo;
                                        Aint = (decimal.Round((decimal)tasa_i * capitalIni, 2, MidpointRounding.AwayFromZero));
                                    }

                                    AbonoAcumulado = AbonoAcumulado + Aint;
                                    TotalAintcap = Aint;
                                    AbonoIntereses = TotalAintcap;
                                    captot = capitalIni + Aint;
                                    saldo = captot;


                                }
                            }
                        }
                        // verificar este cuando el año es diferente
                        else //if ((FechaPago.Month == PagosEncab.referenciaCredito.FechaOtorgamiento.Month) && (FechaPago.Year == fechaotroga.Year) && (fechaotroga.Day > 25))
                        {
                            var cultureInfo = new System.Globalization.CultureInfo("de-DE");
                            String fechadate = "31 May 2020";
                            fecharef = DateTime.Parse(fechadate, cultureInfo);



                            if (FechaPago > fecharef)
                            {
                                //esto es provisional
                                for (int i = 0; i < mestiempo; i++)
                                {

                                    if (i == 0)
                                    {
                                        capitalIni = SaldoPagar;
                                        Aint = (decimal.Round((decimal)tasa_i * SaldoPagar, 2, MidpointRounding.AwayFromZero));
                                    }
                                    else
                                    {
                                        capitalIni = saldo;
                                        Aint = (decimal.Round((decimal)tasa_i * capitalIni, 2, MidpointRounding.AwayFromZero));
                                    }
                                    if (PagosEncab.referenciaCredito.CodigoBeneficiario.Clasificacion == clasificacion.Socio)
                                    {

                                        TotalAintcap = AbonoAcumulado;
                                        AbonoIntereses = TotalAintcap;
                                        captot = capitalIni;
                                        saldo = captot;

                                    }
                                    else
                                    {
                                        AbonoAcumulado = AbonoAcumulado + Aint;
                                        TotalAintcap = AbonoAcumulado;
                                        AbonoIntereses = TotalAintcap;
                                        captot = capitalIni;
                                        saldo = captot;
                                    }
                                    //AbonoAcumulado = AbonoAcumulado + Aint;
                                    //TotalAintcap = Aint;
                                    //AbonoIntereses = TotalAintcap;
                                    //captot = capitalIni + Aint;
                                    //saldo = captot;

                                }
                            }
                            else
                            {
                                for (int i = 0; i < mestiempo; i++)
                                {

                                    if (i == 0)
                                    {
                                        capitalIni = SaldoPagar;
                                        Aint = (decimal.Round((decimal)tasa_i * SaldoPagar, 2, MidpointRounding.AwayFromZero));
                                    }
                                    else
                                    {
                                        capitalIni = saldo;
                                        Aint = (decimal.Round((decimal)tasa_i * capitalIni, 2, MidpointRounding.AwayFromZero));
                                    }

                                    AbonoAcumulado = AbonoAcumulado + Aint;
                                    TotalAintcap = Aint;
                                    AbonoIntereses = TotalAintcap;
                                    captot = capitalIni + Aint;
                                    saldo = captot;

                                }
                            }
                        }
                        //esto son los datos que se reflejan
                        if (TotalPagado < AbonoIntereses)
                        {
                            //AbonoIntereses = TotalPagado;
                            decimal intcapitalizado = AbonoIntereses - TotalPagado;
                            AbonoIntereses = TotalPagado;
                            AbonoCapital = 0;
                            saldoActual = decimal.Round((capitalIni + intcapitalizado) - AbonoCapital, 2, MidpointRounding.AwayFromZero);
                            totasaldo = decimal.Round(saldoActual, 2, MidpointRounding.AwayFromZero);
                            SaldoPagar = totasaldo;
                        }
                        else
                        {
                            AbonoCapital = decimal.Round(TotalPagado - AbonoIntereses, 2, MidpointRounding.AwayFromZero);
                            saldoActual = decimal.Round(capitalIni - AbonoCapital, 2);
                            totasaldo = decimal.Round(capitalIni - AbonoCapital, 2, MidpointRounding.AwayFromZero);
                            SaldoPagar = capitalIni;
                        }
                        if (totasaldo <= (decimal)0.01)
                        {
                            saldoActual = 0;
                        }
                        else
                        {
                            saldoActual = totasaldo;
                        }

                        // saldo pendiente
                        prest = ((saldoActual * (decimal)tasa_i) + saldoActual);
                        SaldoPendiente = prest;
                    }
                    else
                    {
                        if ((FechaPago.Month == fechapagant.Month) && (FechaPago.Year == fechapagant.Year) && (fechapagant.Day >= 1 && FechaPago.Day <= 31) && FechaPago.Month != 2)
                        {
                            SaldoPagar = SaldoPagar;
                            AbonoIntereses = 0;
                            AbonoCapital = decimal.Round(TotalPagado - AbonoIntereses, 2);
                            saldoActual = decimal.Round(SaldoPagar - AbonoCapital, 2);
                            totasaldo = decimal.Round(SaldoPagar - AbonoCapital, 2);
                            //SaldoPagar = saldoActual;
                            //esto son los datos que se reflejan
                            AbonoCapital = decimal.Round(TotalPagado - AbonoIntereses, 2, MidpointRounding.AwayFromZero);
                            totasaldo = decimal.Round(SaldoPagar - AbonoCapital, 2, MidpointRounding.AwayFromZero);
                            if (totasaldo <= (decimal)0.01)
                            {
                                saldoActual = 0;
                            }
                            else
                            {
                                saldoActual = totasaldo;
                            }
                            // saldo pendiente
                            SaldoPagar = SaldoPagar;
                            prest = ((saldoActual * (decimal)tasa_i) + saldoActual);
                            SaldoPendiente = prest;


                        }
                        else if ((FechaPago.Month == fechapagant.Month) && (FechaPago.Year == fechapagant.Year) && (fechapagant.Day >= 25 && FechaPago.Day <= 31) && FechaPago.Month != 2)
                        {
                            SaldoPagar = SaldoPagar;
                            AbonoIntereses = 0;
                            AbonoCapital = decimal.Round(TotalPagado - AbonoIntereses, 2);
                            saldoActual = decimal.Round(SaldoPagar - AbonoCapital, 2);
                            totasaldo = decimal.Round(SaldoPagar - AbonoCapital, 2);
                            //SaldoPagar = valor_inicial - saldoActual;

                            //esto son los datos que se reflejan
                            AbonoCapital = decimal.Round(TotalPagado - AbonoIntereses, 2, MidpointRounding.AwayFromZero);
                            totasaldo = decimal.Round(SaldoPagar - AbonoCapital, 2, MidpointRounding.AwayFromZero);
                            if (totasaldo <= (decimal)0.01)
                            {
                                saldoActual = 0;
                            }
                            else
                            {
                                saldoActual = totasaldo;
                            }
                            // saldo pendiente
                            prest = ((saldoActual * (decimal)tasa_i) + saldoActual);
                            SaldoPendiente = prest;

                        }
                        else
                        {
                            
                        
                            for (int i = 0; i < mestiempo; i++)
                            {

                                if (i == 0)
                                {
                                    capitalIni = SaldoPagar;
                                    Aint = (decimal.Round((decimal)tasa_i * SaldoPagar, 2, MidpointRounding.AwayFromZero));
                                }
                                else
                                {
                                    capitalIni = saldo;
                                    Aint = (decimal.Round((decimal)tasa_i * capitalIni, 2, MidpointRounding.AwayFromZero));
                                }

                                AbonoAcumulado = AbonoAcumulado + Aint;
                                TotalAintcap = Aint;
                                AbonoIntereses = TotalAintcap;
                                captot = capitalIni + Aint;
                                saldo = captot;



                            }

                            //esto son los datos que se reflejan
                            AbonoCapital = decimal.Round(TotalPagado - AbonoIntereses, 2, MidpointRounding.AwayFromZero);
                            totasaldo = decimal.Round(SaldoPagar - AbonoCapital, 2, MidpointRounding.AwayFromZero);

                            if (totasaldo <= (decimal)0.01)
                            {
                                saldoActual = 0;
                            }
                            else
                            {
                                saldoActual = ((capitalIni) - AbonoCapital);
                                SaldoPagar = ((saldoActual) + AbonoCapital);
                            }

                            // saldo pendiente
                            SaldoPagar = capitalIni;
                            prest = ((saldoActual * (decimal)tasa_i) + saldoActual);
                            SaldoPendiente = prest;

                        }

                    }
                    //BinaryOperator Criteria = new BinaryOperator("PagosEncab", DetallePagos);
                    //BinaryOperator Criteria2 = new BinaryOperator("correla", 0, BinaryOperatorType.Equal);
                    //CriteriaOperator DetalleCriteria = CriteriaOperator.And(Criteria, Criteria2);
                    //DetallePagos ObjDetalle = this.Session.FindObject<DetallePagos>(DetalleCriteria);

                    tiempo_int = mestiempo;
                }
                if (saldoActual == 0)
                {

                    PagosEncab.referenciaCredito.EstadoCredito = EstadoCredito.Cancelado;

                }
            }
        }

        protected override void OnSaving()
        {
            if (!ReferenceEquals(PagosEncab, null)  && !ReferenceEquals(Guardado,true))
            {
                correlativo();
            //    abonoInt();
               // saldopen();
                Guardado = true;
               // saldoAct();

               


            }
        }
    }
   }

