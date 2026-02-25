using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace KPNaidis_TARpe24;

public partial class RGBSlider : ContentPage
{
    Label lbl;
    Slider slR;
    Slider slG;
    Slider slB;
    Slider slA;
    Slider slC;
    int R;
    int G;
    int B;
    int C;
    int A;
    Ellipse pallR;
    Ellipse pallG;
    Ellipse pallB;
    Ellipse pallA;
    BoxView cubeCorner;
    BoxView ColorBox;
    HorizontalStackLayout hsl;
    VerticalStackLayout vsl;
    AbsoluteLayout abs;

    public RGBSlider()
    {
        lbl = new Label
        {
            BackgroundColor = Color.FromRgb(120, 144, 133),
            Text = ". . ."
        };
        pallR = new Ellipse
        {
            WidthRequest = 50,
            HeightRequest = 50,
            Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0)),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };
        pallG = new Ellipse
        {
            WidthRequest = 50,
            HeightRequest = 50,
            Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0)),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };
        pallB = new Ellipse
        {
            WidthRequest = 50,
            HeightRequest = 50,
            Fill = new SolidColorBrush(Color.FromRgb(0, 0,255)),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };
        pallA = new Ellipse
        {
            WidthRequest = 50,
            HeightRequest = 50,
            Fill = new SolidColorBrush(Color.FromRgba(0, 0, 0, 255)),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };
        cubeCorner = new BoxView
        {
            Color = Color.FromRgb(0, 0, 0),
            WidthRequest = 50,
            HeightRequest = 50,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            CornerRadius = 0,
        };
        ColorBox = new BoxView
        {
            Color = Color.FromRgba(0, 0, 0, A),
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(255,255,255,A),
            CornerRadius = 0,
        };
        slR = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 255,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Color.FromRgb(254, 0, 0),
            MaximumTrackColor = Color.FromRgb(0, 0, 0),
            ThumbColor = Color.FromRgb(155, 155, 155),
            WidthRequest = 300
        };
        slR.ValueChanged += Stepper_Slider_ValueChanged;
        slG = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 255,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Color.FromRgb(0, 254, 0),
            MaximumTrackColor = Color.FromRgb(0, 0, 0),
            ThumbColor = Color.FromRgb(155, 155, 155),
            WidthRequest = 300
        };
        slG.ValueChanged += Stepper_Slider_ValueChanged;
        slB = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 255,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Color.FromRgb(0, 0, 254),
            MaximumTrackColor = Color.FromRgb(0, 0, 0),
            ThumbColor = Color.FromRgb(155, 155, 155),
            WidthRequest = 300
        };
        slB.ValueChanged += Stepper_Slider_ValueChanged;
        slA = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 255,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Color.FromRgb(0, 0, 0),
            MaximumTrackColor = Color.FromRgb(255, 255, 255),
            ThumbColor = Color.FromRgb(155, 155, 155),
            WidthRequest = 300
        };
        slA.ValueChanged += Stepper_Slider_ValueChanged;
        slC = new Slider
        {
            Minimum = 0,
            Maximum = 100,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Color.FromRgb(0, 0, 0),
            MaximumTrackColor = Color.FromRgb(255, 255, 255),
            ThumbColor = Color.FromRgb(155, 155, 155),
            WidthRequest = 300
        };
        slC.ValueChanged += Stepper_Slider_ValueChanged;
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = { ColorBox, pallR, slR, pallG, slG, pallB, slB, pallA, slA, cubeCorner, slC },
            HorizontalOptions = LayoutOptions.Center
        };
        /*List<View> controls = new List<View> { slR, slG, slB };
        for (int i = 0; i < controls.Count; i++)
        {
            double yKoht = 0.2 + i * 0.2;
            AbsoluteLayout.SetLayoutBounds(controls[i], new Rect(0.5, yKoht, 300, 60));
            AbsoluteLayout.SetLayoutFlags(controls[i], AbsoluteLayoutFlags.PositionProportional);
        }*/
        Content = vsl;
    }
    private void Stepper_Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        R = (int)slR.Value;
        G = (int)slG.Value;
        B = (int)slB.Value;
        A = (int)slA.Value;
        C = (int)slC.Value;
        slR.MinimumTrackColor = Color.FromRgb(R, 0, 0);
        slR.MaximumTrackColor = Color.FromRgb((255 - R), 0, 0);
        slG.MinimumTrackColor = Color.FromRgb(0, G, 0);
        slG.MaximumTrackColor = Color.FromRgb(0, (255 - G), 0);
        slB.MinimumTrackColor = Color.FromRgb(0, 0, B);
        slB.MaximumTrackColor = Color.FromRgb(0, 0, (255 - B));
        pallR.Fill = Color.FromRgb(R, 0, 0);
        pallG.Fill = Color.FromRgb(0, G, 0);
        pallB.Fill = Color.FromRgb(0, 0, B);
        pallA.Fill = Color.FromRgba(0, 0, 0, A);
        cubeCorner.CornerRadius = C;
        ColorBox.Color = Color.FromRgba(R, G, B, A);
        ColorBox.CornerRadius = C;
    }
}