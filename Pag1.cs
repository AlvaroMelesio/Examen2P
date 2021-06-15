using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examen2P
{
    [Activity(Label = "Pag1")]
    public class Pag1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Pag1);

            var Imagen = FindViewById<ImageView>(Resource.Id.imagen);
            Imagen.SetImageResource(Resource.Drawable.LogoLaSalle);

            var btnGuardar = FindViewById<TextView>(Resource.Id.btnguardar);
            var btnBuscar = FindViewById<TextView>(Resource.Id.btnbuscar);
            var txtSalir = FindViewById<TextView>(Resource.Id.txtsalir);

            txtSalir.Click += delegate
            {
                System.Environment.Exit(0);
            };

            btnBuscar.Click += delegate
            {
                var Buscar = new Intent(this, typeof(Buscar));
                StartActivity(Buscar);
            };

            btnGuardar.Click += delegate
            {
                var Guardar= new Intent(this, typeof(Guardar));
                StartActivity(Guardar);
            };
            // Create your application here
        }
    }
}