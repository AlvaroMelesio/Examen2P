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
    [Activity(Label = "Guardar")]
    public class Guardar : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Guardar);

            var txtVolver = FindViewById<TextView>(Resource.Id.txtvolver);
            var btnGuardar = FindViewById<Button>(Resource.Id.btnguardar);
            var txtNumero = FindViewById<EditText>(Resource.Id.txtnum);
            var txtSaldo = FindViewById<EditText>(Resource.Id.txtsaldo);
            var txtVol = FindViewById<TextView>(Resource.Id.txt);
            

            txtVol.Click += delegate
            {
                var Volver = new Intent(this, typeof(Pag1));
                StartActivity(Volver);
            };

            txtVolver.Click += delegate
            {
                double Numero = double.Parse(txtNumero.Text);
                double Saldo = double.Parse(txtSaldo.Text);
                try
                {
                    var WS = new Azure.WebService();
                    if (WS.Actualizar(Numero, Saldo))
                        Toast.MakeText(this, "Recarga Exitosa", ToastLength.Long).Show();
                    else
                        Toast.MakeText(this, "Recarga Fallida", ToastLength.Long).Show();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };

            btnGuardar.Click += delegate
            {
                double Numero = double.Parse(txtNumero.Text);
                double Saldo = double.Parse(txtSaldo.Text);
                try
                {
                    var WS = new Azure.WebService();
                    if (WS.Guardar(Numero, Saldo))
                        Toast.MakeText(this, "Recarga Exitosa", ToastLength.Long).Show();
                    else
                        Toast.MakeText(this, "Recarga Fallida", ToastLength.Long).Show();
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