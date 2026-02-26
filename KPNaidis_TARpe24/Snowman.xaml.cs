using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System.Runtime.Intrinsics.Arm;

namespace KPNaidis_TARpe24;

public partial class Snowman : ContentPage
{
    BoxView AmberA;
    BoxView AmberB;
    BoxView AmberC;
    Ellipse pallPea;
    Ellipse pallKeha;
    Ellipse pallJalad;

    Picker snowpick;
    AbsoluteLayout abs;

    public Snowman()
    {
        
        pallPea = new Ellipse
        {
            WidthRequest = 125,
            HeightRequest = 125,
            Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };
        AmberA = new BoxView
        {
            Color = Color.FromRgb(0, 0, 0),
            WidthRequest = 40,
            HeightRequest = 80,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            CornerRadius = 0,
        };
        AmberB = new BoxView
        {
            Color = Color.FromRgb(0, 0, 0),
            WidthRequest = 50,
            HeightRequest = 30,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            CornerRadius = 0,
        };
        AmberC = new BoxView
        {
            Color = Color.FromRgb(127, 0, 255),
            WidthRequest = 40,
            HeightRequest = 5,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            CornerRadius = 0,
        };
        pallKeha = new Ellipse
        {
            WidthRequest = 150,
            HeightRequest = 150,
            Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };
        pallJalad = new Ellipse
        {
            WidthRequest = 175,
            HeightRequest = 175,
            Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };
        snowpick = new Picker
        {
            Title = "Snowman Valik",
            ItemsSource = new List<string> { "Peida", "Näita", "Muuda värv","Sulata","Tantsi","TTS","Ööreþiim" },
            HorizontalOptions = LayoutOptions.Center
        };
        snowpick.SelectedIndexChanged += (sender, e) =>
        {
            switch (snowpick.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        };
        abs = new AbsoluteLayout { Children = { AmberA, AmberB, AmberC, pallPea, pallKeha, pallJalad, snowpick } };

        AbsoluteLayout.SetLayoutBounds(pallPea, new Rect(120, 80, 200, 50));
        AbsoluteLayout.SetLayoutBounds(AmberA, new Rect(120, 30, 200, 50));
        AbsoluteLayout.SetLayoutBounds(AmberB, new Rect(120, 30, 200, 50));
        AbsoluteLayout.SetLayoutBounds(AmberC, new Rect(120, 10, 200, 50));
        AbsoluteLayout.SetLayoutBounds(pallKeha, new Rect(120, 170, 200, 50));
        AbsoluteLayout.SetLayoutBounds(pallJalad, new Rect(120, 280, 200, 50));
        AbsoluteLayout.SetLayoutBounds(snowpick, new Rect(120, 420, 200, 50));
        Content = abs;
    }
}