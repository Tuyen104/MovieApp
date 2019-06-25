using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using MovieApp.Controls;
using MovieApp.Entities.Server;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace MovieApp.Views
{
    public partial class PopularMoviePage : TopTabChildPage
    {
        public PopularMoviePage()
        {
            InitializeComponent();

            //var items = (InfiniteScrollCollection<Movie>) movieList.ItemsSource;
            //if (string.IsNullOrWhiteSpace(searchBar.Text))
            //{
            //    movieList.ScrollTo(items.FirstOrDefault(), ScrollToPosition.MakeVisible, true);
            //}

        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            ScrollToFirst();
        }

        public void ScrollToFirst()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    if (searchBar.Text.Equals("") && movieList.ItemsSource != null)
                    {
                        var firstItem = movieList.ItemsSource.Cast<object>().FirstOrDefault();
                        if (firstItem != null)
                        {
                            movieList.ScrollTo(firstItem, ScrollToPosition.Start, false);
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
