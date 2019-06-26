using System;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Controls;
using Xamarin.Forms;

namespace MovieApp.Views
{
    public partial class UpComingMoviePage : TopTabChildPage
    {
        public UpComingMoviePage()
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
                    if (movieList.ItemsSource != null)
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
