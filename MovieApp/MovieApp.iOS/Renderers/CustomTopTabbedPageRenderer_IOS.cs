using System;
using CoreGraphics;
using MovieApp.Controls;
using MovieApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTopTabbedPage), typeof(CustomTopTabbedPageRenderer_IOS))]
namespace MovieApp.iOS.Renderers
{
    public class CustomTopTabbedPageRenderer_IOS : TabbedRenderer
    {
        bool init;

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (init)//because ViewDidLayoutSubviews called many times, so that add init flag to prevent the code below called many times
                return;

            CGRect tabFrame = TabBar.Frame;
            tabFrame.Height = 40;
            tabFrame.Y = View.Frame.Y;
            TabBar.Frame = tabFrame;
            TabBar.Items[0].TitlePositionAdjustment = new UIOffset(0, -10);
            TabBar.Items[1].TitlePositionAdjustment = new UIOffset(0, -10);

            TabBar.Items[0].Tag = 10;
            TabBar.Items[1].Tag = 11;

            UITextAttributes txtAttributes = new UITextAttributes
            {
                Font = UIFont.PreferredBody
            };
            TabBar.Items[0].SetTitleTextAttributes(txtAttributes, UIControlState.Normal);
            TabBar.Items[1].SetTitleTextAttributes(txtAttributes, UIControlState.Normal);

            var maxY = TabBar.Frame.GetMaxY();
            var maxX = TabBar.Frame.GetMaxX();

            var centerX = maxX / 2f;
            var boxHeight = 2;
            var box = new UIView(new CGRect(0, maxY - boxHeight, centerX, boxHeight))
            {
                //BackgroundColor = ((Color)App.Current.Resources["ThemeTextColor"]).ToUIColor()
            };
            box.GestureRecognizers = null;

            (ViewController as UITabBarController).ViewControllerSelected += (sender, e) => {
                if(e.ViewController.TabBarItem.Tag == 10){
                    box.Frame = new CGRect(0, box.Frame.Y, box.Frame.Width, box.Frame.Height);//Called many times
                }else if(e.ViewController.TabBarItem.Tag == 11){
                    box.Frame = new CGRect(centerX, box.Frame.Y, box.Frame.Width, box.Frame.Height);//Called many times
                }
            };

            if (!init)
            {
                View.AddSubview(box);
                init = true;
            }

        }
    }
}
