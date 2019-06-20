using System;
using Android.Content;
using MovieApp.Controls;
using MovieApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MultiLineLabel), typeof(MultiLineLabelRenderer_Droid))]
namespace MovieApp.Droid.Renderers
{
    public class MultiLineLabelRenderer_Droid : LabelRenderer
    {
        public MultiLineLabelRenderer_Droid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var baseLabel = (MultiLineLabel)this.Element;
            if(baseLabel != null)
            {
                Control.SetMaxLines(baseLabel.MaxLines);
            }
        }
    }
}
