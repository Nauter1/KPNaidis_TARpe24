using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System.Runtime.Intrinsics.Arm;

namespace KPNaidis_TARpe24;

public partial class Snowman : ContentPage
{
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
            Title = "Snowman Valik"
        };
        abs = new AbsoluteLayout { Children = { pallPea, pallKeha, pallJalad, snowpick } };
        AbsoluteLayout.SetLayoutBounds(pallPea, new Rect(120, 80, 200, 50));
        AbsoluteLayout.SetLayoutBounds(pallKeha, new Rect(120, 170, 200, 50));
        AbsoluteLayout.SetLayoutBounds(pallJalad, new Rect(120, 280, 200, 50));
        AbsoluteLayout.SetLayoutBounds(snowpick, new Rect(120, 420, 200, 50));
        Content = abs;
    }
}