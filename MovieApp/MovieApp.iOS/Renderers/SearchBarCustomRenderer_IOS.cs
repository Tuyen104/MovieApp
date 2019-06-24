using System;
using System.ComponentModel;
using MovieApp.Controls;
using MovieApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBarCustom), typeof(SearchBarCustomRenderer_IOS))]
namespace MovieApp.iOS.Renderers
{
    public class SearchBarCustomRenderer_IOS : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            var searchbar = (UISearchBar)Control;
            if (e.NewElement != null)
            {
                Foundation.NSString _searchField = new Foundation.NSString("searchField");
                var textFieldInsideSearchBar = (UITextField)searchbar.ValueForKey(_searchField);
                textFieldInsideSearchBar.BackgroundColor = UIColor.FromRGB(224, 220, 220);
                textFieldInsideSearchBar.TextColor = UIColor.White;
                searchbar.TintColor = UIColor.White;
                searchbar.BarTintColor = UIColor.White;
                searchbar.SearchBarStyle = UISearchBarStyle.Minimal;
                searchbar.BarTintColor = UIColor.Clear;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            Control.ShowsCancelButton = false;
        }

    }
}
