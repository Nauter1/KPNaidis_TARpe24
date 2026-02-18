using Microsoft.Maui.Controls.Shapes;

namespace KPNaidis_TARpe24;

public partial class ValgusFoorPage : ContentPage
{

    Ellipse palla;
    Ellipse pallb;
    Ellipse pallc;
    bool ona;
    bool onb;
    bool onc;
    bool seesvaljas;
    Random rnd = new Random();
    HorizontalStackLayout hsl;
    List<string> nupud = new List<string>() { "Tagasi", "Avaleht", "Edasi" };
    VerticalStackLayout vsl;
    public ValgusFoorPage()
    {
        TapGestureRecognizer tapa = new TapGestureRecognizer();
        TapGestureRecognizer tapb = new TapGestureRecognizer();
        TapGestureRecognizer tapc = new TapGestureRecognizer();
        Grid ellipsiKonteinerA = new Grid
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        Grid ellipsiKonteinerB = new Grid
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        Grid ellipsiKonteinerC = new Grid
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        palla = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Color.FromRgb(50, 50, 50)),
            Stroke = Colors.DarkGray,
            StrokeThickness = 8,
            HorizontalOptions = LayoutOptions.Center
        };
        palla.GestureRecognizers.Add(tapa);
        pallb = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Color.FromRgb(50, 50, 50)),
            Stroke = Colors.DarkGray,
            StrokeThickness = 8,
            HorizontalOptions = LayoutOptions.Center
        };
        pallb.GestureRecognizers.Add(tapb);
        pallc = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Color.FromRgb(50, 50, 50)),
            Stroke = Colors.DarkGray,
            StrokeThickness = 8,
            HorizontalOptions = LayoutOptions.Center
        };
        pallc.GestureRecognizers.Add(tapc);
        tapa.Tapped += (sender, e) =>
        {
            if (seesvaljas == true)
            {
                if (ona == true)
                {
                    ona = false;
                    palla.Fill = Color.FromRgb(100, 100, 100);
                }
                else if (ona == false)
                {
                    ona = true;
                    palla.Fill = Color.FromRgb(255, 0, 0);
                }
            }
        };
        tapb.Tapped += (sender, e) =>
        {
            if (seesvaljas == true)
            {
                if (onb == true)
                {
                    onb = false;
                    pallb.Fill = Color.FromRgb(100, 100, 100);
                }
                else if (onb == false)
                {
                    onb = true;
                    pallb.Fill = Color.FromRgb(255, 255, 0);
                }
            }
        };
        tapc.Tapped += (sender, e) =>
        {
            if (seesvaljas == true)
            {
                if (onc == true)
                {
                    onc = false;
                    pallc.Fill = Color.FromRgb(100, 100, 100);
                }
                else if (onc == false)
                {
                    onc = true;
                    pallc.Fill = Color.FromRgb(0, 255, 0);
                }
            }
        };
        Button nupp = new Button
        {
            Text = "Sisse",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
            ZIndex = 1
        };
        Label texta = new Label
        {
            Text = "Seisa!",
            HorizontalOptions = LayoutOptions.Center, // Keskele horisontaalselt
            VerticalOptions = LayoutOptions.Center,   // Keskele vertikaalselt
            TextColor = Colors.Black,
            FontAttributes = FontAttributes.Bold
        };
        Label textb = new Label
        {
            Text = "Oota...",
            HorizontalOptions = LayoutOptions.Center, // Keskele horisontaalselt
            VerticalOptions = LayoutOptions.Center,   // Keskele vertikaalselt
            TextColor = Colors.Black,
            FontAttributes = FontAttributes.Bold
        };
        Label textc = new Label
        {
            Text = "Sõida!",
            HorizontalOptions = LayoutOptions.Center, // Keskele horisontaalselt
            VerticalOptions = LayoutOptions.Center,   // Keskele vertikaalselt
            TextColor = Colors.Black,
            FontAttributes = FontAttributes.Bold
        };
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = {},
            HorizontalOptions = LayoutOptions.Center
        };
        ellipsiKonteinerA.Children.Add(palla);
        ellipsiKonteinerA.Children.Add(texta);
        ellipsiKonteinerB.Children.Add(pallb);
        ellipsiKonteinerB.Children.Add(textb);
        ellipsiKonteinerC.Children.Add(pallc);
        ellipsiKonteinerC.Children.Add(textc);
        vsl.Children.Add(ellipsiKonteinerA);
        vsl.Children.Add(ellipsiKonteinerB);
        vsl.Children.Add(ellipsiKonteinerC);
        vsl.Children.Add(hsl);
        vsl.Add(nupp);
        nupp.Clicked += (sender, e) =>
        {
            if (seesvaljas == false)
            { 
            seesvaljas = true;
            palla.Fill = Color.FromRgb(100, 100, 100);
            pallb.Fill = Color.FromRgb(100, 100, 100);
            pallc.Fill = Color.FromRgb(100, 100, 100);
            }
        };
        Button nuppb = new Button
        {
            Text = "Väljas",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
            ZIndex = 1
        };
        vsl.Add(nuppb);
        nuppb.Clicked += (sender, e) =>
        {
            if (seesvaljas == true)
            {
                seesvaljas = false;
                ona = false;
                onb = false;
                onc = false;
                palla.Fill = Color.FromRgb(50, 50, 50);
                pallb.Fill = Color.FromRgb(50, 50, 50);
                pallc.Fill = Color.FromRgb(50, 50, 50);
            }
        };
        Content = vsl;
    }
}