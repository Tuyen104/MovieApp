using System;
using Android.Content;
using MovieApp.Controls;
using MovieApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace MovieApp.Droid.Renderers
{
    public class CustomFrameRenderer : FrameRenderer
    {
        public CustomFrameRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement != null)
            {
                ViewGroup.SetBackgroundResource(Resource.Mipmap.FrameRendererValue);
            }
        }
    }
}
