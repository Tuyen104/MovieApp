using System;
using System.Drawing;
using CoreGraphics;
using MovieApp.Controls;
using MovieApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace MovieApp.iOS.Renderers
{
    public class CustomFrameRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            // Border
            //this.Layer.CornerRadius = 10f;
            //this.Layer.Bounds.Inset(1, 1);
            this.Layer.BorderColor = UIColor.FromRGB(204, 204, 204).CGColor;
            this.Layer.BorderWidth = (float)1;
            this.Layer.BackgroundColor = UIColor.White.CGColor;

            // Shadow
            this.Layer.ShadowColor = UIColor.Black.CGColor;
            this.Layer.ShadowOpacity = 0.2f;
            this.Layer.ShadowRadius = 3f;
            this.Layer.ShadowOffset = new SizeF(0, 0);
        }
    }
}
