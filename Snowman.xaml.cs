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
    Ellipse pallSilmA;
    Ellipse pallSilmB;
    Ellipse pallKeha;
    Ellipse pallJalad;
    Point A;
    Point B;
    Point C;
    int r;
    int g;
    int b;
    int daynight;
    int dance;
    Slider slR;
    Slider slG;
    Slider slB;


    Polygon kolmnurk;
 

    Picker snowpick;
    Button Activate;
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
        pallSilmA = new Ellipse
        {
            WidthRequest = 12,
            HeightRequest = 15,
            Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };
        pallSilmB = new Ellipse
        {
            WidthRequest = 12,
            HeightRequest = 15,
            Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };
        A = new Point(0, 16);
        B = new Point(50, 30);
        C = new Point(26, 16);
        kolmnurk = new Polygon
        {
            Points = new PointCollection
            {
                A,
                B,
                C
            },
            Fill = new SolidColorBrush(Colors.OrangeRed),
            Stroke = Colors.OrangeRed,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
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
            if (snowpick.SelectedIndex == 2)
            {
                slR.IsVisible = true;
                slG.IsVisible = true;
                slB.IsVisible = true;
                Activate.IsVisible = false;
            }
            else
            {
                slR.IsVisible = false;
                slG.IsVisible = false;
                slB.IsVisible = false;
                Activate.IsVisible = true;
            }
            AmberA.TranslateTo(0, 0);
            AmberB.TranslateTo(0, 0);
            AmberC.TranslateTo(0, 0);
            pallPea.TranslateTo(0, 0);
            pallSilmA.TranslateTo(0, 0);
            pallSilmB.TranslateTo(0, 0);
            pallKeha.TranslateTo(0, 0);
            pallJalad.TranslateTo(0, 0);
            kolmnurk.TranslateTo(0, 0);
        };
        Activate = new Button
        {
            Text = "Aktiveeri",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
            ZIndex = 1
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
            WidthRequest = 300,
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

        Activate.Clicked += (sender, e) =>
        {
            switch (snowpick.SelectedIndex)
            {
                case 0:
                    AmberA.IsVisible = false;
                    AmberB.IsVisible = false;
                    AmberC.IsVisible = false;
                    pallPea.IsVisible = false;
                    pallSilmA.IsVisible = false;
                    pallSilmB.IsVisible = false;
                    pallKeha.IsVisible = false;
                    pallJalad.IsVisible = false;
                    kolmnurk.IsVisible = false;
                    break;
                case 1:
                    AmberA.IsVisible = true;
                    AmberB.IsVisible = true;
                    AmberC.IsVisible = true;
                    pallPea.IsVisible = true;
                    pallSilmA.IsVisible = true;
                    pallSilmB.IsVisible = true;
                    pallKeha.IsVisible = true;
                    pallJalad.IsVisible = true;
                    kolmnurk.IsVisible = true;
                    AmberA.FadeToAsync(1,150);
                    AmberB.FadeToAsync(1, 150);
                    AmberC.FadeToAsync(1, 150);
                    pallPea.FadeToAsync(1, 150);
                    pallSilmA.FadeToAsync(1, 150);
                    pallSilmB.FadeToAsync(1, 150);
                    pallKeha.FadeToAsync(1, 150);
                    pallJalad.FadeToAsync(1, 150);
                    kolmnurk.FadeToAsync(1, 150);
                    break;
                case 2:
                    break;
                case 3:
                    AmberA.FadeToAsync(0, 250);
                    AmberB.FadeToAsync(0, 250);
                    AmberC.FadeToAsync(0, 250);
                    pallPea.FadeToAsync(0, 250);
                    pallSilmA.FadeToAsync(0, 250);
                    pallSilmB.FadeToAsync(0, 250);
                    pallKeha.FadeToAsync(0, 250);
                    pallJalad.FadeToAsync(0, 250);
                    kolmnurk.FadeToAsync(0, 250);
                    break;
                case 4:
                    if (dance == 0)
                    { 
                    AmberA.TranslateTo(70, 0);
                    AmberB.TranslateTo(70, 0);
                    AmberC.TranslateTo(70, 0);
                    pallPea.TranslateTo(70, 0);
                    pallSilmA.TranslateTo(70, 0);
                    pallSilmB.TranslateTo(70, 0);
                    pallKeha.TranslateTo(70, 0);
                    pallJalad.TranslateTo(70, 0);
                    kolmnurk.TranslateTo(70, 0);

                        dance = 1;
                    }
                    else
                    {
                        AmberA.TranslateTo(-70, 0);
                        AmberB.TranslateTo(-70, 0);
                        AmberC.TranslateTo(-70, 0);
                        pallPea.TranslateTo(-70, 0);
                        pallSilmA.TranslateTo(-70, 0);
                        pallSilmB.TranslateTo(-70, 0);
                        pallKeha.TranslateTo(-70, 0);
                        pallJalad.TranslateTo(-70, 0);
                        kolmnurk.TranslateTo(-70, 0);

                        dance = 0;
                    }
                    break;
                case 5:
                    TextToSpeech.SpeakAsync("Häid pühi!");
                    break;
                case 6:
                    if (daynight == 0)
                    {
                        daynight = 1;
                        snowpick.TextColor = Colors.White;
                        BackgroundColor = Colors.MidnightBlue;
                    }
                    else
                    {
                        daynight = 0;
                        snowpick.TextColor = Colors.Black;
                        BackgroundColor = Colors.White;
                    }
                    break;
            }

        };
        slR.IsVisible = false;
        slG.IsVisible = false;
        slB.IsVisible = false;
        abs = new AbsoluteLayout { Children = { AmberA, AmberB, AmberC, pallPea, pallSilmA, pallSilmB, kolmnurk, pallKeha, pallJalad, snowpick, Activate, slR, slG, slB } };

        AbsoluteLayout.SetLayoutBounds(pallPea, new Rect(120, 80, 200, 50));
        AbsoluteLayout.SetLayoutBounds(pallSilmA, new Rect(110, 60, 200, 50));
        AbsoluteLayout.SetLayoutBounds(pallSilmB, new Rect(160, 60, 200, 50));
        AbsoluteLayout.SetLayoutBounds(kolmnurk, new Rect(150, 75, 200, 50));
        AbsoluteLayout.SetLayoutBounds(AmberA, new Rect(120, 30, 200, 50));
        AbsoluteLayout.SetLayoutBounds(AmberB, new Rect(120, 30, 200, 50));
        AbsoluteLayout.SetLayoutBounds(AmberC, new Rect(120, 10, 200, 50));
        AbsoluteLayout.SetLayoutBounds(pallKeha, new Rect(120, 170, 200, 50));
        AbsoluteLayout.SetLayoutBounds(pallJalad, new Rect(120, 280, 200, 50));
        AbsoluteLayout.SetLayoutBounds(snowpick, new Rect(120, 420, 200, 50));
        AbsoluteLayout.SetLayoutBounds(Activate, new Rect(120, 490, 200, 50));
        AbsoluteLayout.SetLayoutBounds(slR, new Rect(120, 540, 200, 50));
        AbsoluteLayout.SetLayoutBounds(slG, new Rect(120, 570, 200, 50));
        AbsoluteLayout.SetLayoutBounds(slB, new Rect(120, 600, 200, 50));
        Content = abs;
    }

    private void Stepper_Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        r = (int)slR.Value;
        g = (int)slG.Value;
        b = (int)slB.Value;
        slR.MinimumTrackColor = Color.FromRgb(r, 0, 0);
        slR.MaximumTrackColor = Color.FromRgb((255 - r), 0, 0);
        slG.MinimumTrackColor = Color.FromRgb(0, g, 0);
        slG.MaximumTrackColor = Color.FromRgb(0, (255 - g), 0);
        slB.MinimumTrackColor = Color.FromRgb(0, 0, b);
        slB.MaximumTrackColor = Color.FromRgb(0, 0, (255 - b));
        pallKeha.Fill = Color.FromRgb(r, g, b);
        pallPea.Fill = Color.FromRgb(r, g, b);
        pallJalad.Fill = Color.FromRgb(r, g, b);
    }
}

/*
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



    }
    private void Stepper_Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        r = (int)slR.Value;
        g = (int)slG.Value;
        b = (int)slB.Value;
        slR.MinimumTrackColor = Color.FromRgb(r, 0, 0);
        slR.MaximumTrackColor = Color.FromRgb((255 - r), 0, 0);
        slG.MinimumTrackColor = Color.FromRgb(0, g, 0);
        slG.MaximumTrackColor = Color.FromRgb(0, (255 - g), 0);
        slB.MinimumTrackColor = Color.FromRgb(0, 0, b);
        slB.MaximumTrackColor = Color.FromRgb(0, 0, (255 - b));
        AmberA.Color = Color.FromRgb(r, g, b);
    }* 
 */