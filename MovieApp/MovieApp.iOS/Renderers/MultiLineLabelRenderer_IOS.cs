using System;
using MovieApp.Controls;
using MovieApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MultiLineLabel), typeof(MultiLineLabelRenderer_IOS))]
namespace MovieApp.iOS.Renderers
{
    public class MultiLineLabelRenderer_IOS : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var baseLabel = (MultiLineLabel)this.Element;
            if(baseLabel != null)
            {
                Control.Lines = baseLabel.MaxLines;
            }
        }
    }
}
