using System;
using Android.Content;
using Android.Widget;
using MovieApp.Controls;
using MovieApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SearchBarCustom), typeof(SearchBarCustomRenderer_Droid))]
namespace MovieApp.Droid.Renderers
{
    public class SearchBarCustomRenderer_Droid : SearchBarRenderer
    {
        public SearchBarCustomRenderer_Droid(Context context) : base(context)
        {
        }

    }
}

