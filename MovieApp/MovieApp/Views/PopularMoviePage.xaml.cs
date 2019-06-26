using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using MovieApp.Controls;
using MovieApp.Entities.Server;
using MovieApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace MovieApp.Views
{
    public partial class PopularMoviePage : TopTabChildPage
    {
        public PopularMoviePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(
            this, "ScrollToTop", (arg) => {
                ScrollToFirst();
            });
        }

        public void ScrollToFirst()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    if ( movieList.ItemsSource != null)
                    {
                        var firstItem = movieList.ItemsSource.Cast<object>().FirstOrDefault();
                        if (firstItem != null)
                        {
                            movieList.ScrollTo(firstItem, ScrollToPosition.MakeVisible, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            });
        }

    }
}
