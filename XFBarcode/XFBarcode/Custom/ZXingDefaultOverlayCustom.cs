using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Linq;

namespace XFBarcode.Custom
{
    public class ZXingDefaultOverlayCustom : ZXingDefaultOverlay
    {
        public ZXingDefaultOverlayCustom() : base()
        {
            //var result = Children.Where(c => c.GetType() == typeof(BoxView) && c.BackgroundColor==Color.Red).ToList();
            var result = Children.Where(c => c.GetType() == typeof(BoxView) ).ToList();
            foreach (var i in result)
            {
                Children.Remove(i);
            }
            var grid = new Grid()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10,0,5,0)
                
            };
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.Children.Add(new BoxView
            {
                BackgroundColor = Color.Orange,
                HeightRequest = 3,
                VerticalOptions = LayoutOptions.StartAndExpand
                },
                3, 0);

            grid.Children.Add(new BoxView
            {
                BackgroundColor = Color.Orange,
                WidthRequest = 3,
                HorizontalOptions=LayoutOptions.End,
                VerticalOptions = LayoutOptions.FillAndExpand
            },
                3, 0);


            grid.Children.Add(new BoxView
            {
                BackgroundColor = Color.Orange,
                WidthRequest = 3,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.FillAndExpand
            },
                3, 3);

            grid.Children.Add(new BoxView
            {
                BackgroundColor = Color.Orange,
                HeightRequest = 3,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End
            },
                 3, 3);

            grid.Children.Add(new BoxView
            {
                BackgroundColor = Color.Orange,
                HeightRequest = 3,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End
            },
                 0, 3);
            grid.Children.Add(new BoxView
            {
                BackgroundColor = Color.Orange,
                WidthRequest = 3,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.FillAndExpand
            },
                 0, 3);

            grid.Children.Add(new BoxView
            {
                BackgroundColor = Color.Orange,
                WidthRequest = 3,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.FillAndExpand
            },
                 0, 0);
            grid.Children.Add(new BoxView
            {
                BackgroundColor = Color.Orange,
                HeightRequest = 3,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            },
                 0, 0);

            this.Children.Add(grid, 0, 1);
        }
    }
}
