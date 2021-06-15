using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;




namespace Examen2P
{
    [Activity(Label = "Buscar")]
    public class Buscar : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Buscar);

            var txtVolver = FindViewById<TextView>(Resource.Id.txtvolver);
            var btnBuscar = FindViewById<Button>(Resource.Id.btnbuscar);
            var txtNumero = FindViewById<EditText>(Resource.Id.txtnum);
            var txtSaldo = FindViewById<TextView>(Resource.Id.txtsaldo);

            txtVolver.Click += delegate
            {
                var Volver = new Intent(this, typeof(Pag1));
                StartActivity(Volver);
            };

            btnBuscar.Click += delegate
            {
                double Numero = double.Parse(txtNumero.Text);
                var Conjunto = new DataSet();
                DataRow Renglon;
                try
                {
                    var WS = new Azure.WebService();
                    Conjunto = WS.Busqueda(Numero);
                    Renglon = Conjunto.Tables["Datos"].Rows[0];
                    txtSaldo.Text = "Tu saldo es de: $" + Renglon["Saldo"].ToString() + " mxn.";
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };
            // Create your application here
        }
    }
}