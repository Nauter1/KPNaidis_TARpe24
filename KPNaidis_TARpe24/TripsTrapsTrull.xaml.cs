namespace KPNaidis_TARpe24;

public partial class TripsTrapsTrull : ContentPage
{
    Grid gr3x3,gr3x1;
    Switch s_grid;
    int Side = 0;
    int board = 3;
    Random rnd = new Random();
    VerticalStackLayout vsl = new VerticalStackLayout { };
	public TripsTrapsTrull()
	{
        gr3x1 = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1,GridUnitType.Star)},
                new RowDefinition { Height = new GridLength(3,GridUnitType.Star)},
                new RowDefinition { Height = new GridLength(3,GridUnitType.Star)},
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1,GridUnitType.Star)},
                new ColumnDefinition { Width = new GridLength(1,GridUnitType.Star)}
            }
        };
        s_grid = new Switch
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            IsToggled = true,
            IsEnabled = true
        };
        s_grid.Toggled += (sender, e) =>
        {
            if (e.Value)
            {
                gr3x3 = täida_gr3x3();

            }
            else
            {

            }
        };
        s_grid.Toggled += (sender, e) =>
        {
            if (e.Value)
            {
                gr3x3 = täida_gr3x3();
                gr3x1.Add(gr3x3, 0, 2);
                gr3x1.SetColumnSpan(gr3x3, 2);
            }
            else
            {
                gr3x1.RemoveAt(4);
            }
        };
        gr3x3 = täida_gr3x3();
        gr3x1.Add(s_grid, 1, 3);
        Content = gr3x3;
    }

    private Grid täida_gr3x3()
    {
        gr3x3 = new Grid();
        for (int i = 0; i < board; i++)
        {
            gr3x3.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gr3x3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                BoxView kast = new BoxView
                {
                    Color = Color.FromRgb(88, 88, 88),
                    WidthRequest = 90,
                    HeightRequest = 90,
                    BackgroundColor = Color.FromRgb(255, 255, 0),
                };
                gr3x3.Add(kast, c, r);
                int rida = r;
                int veerg = c;
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += async (s, args) =>
                {
                    kast.BackgroundColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    await DisplayAlertAsync("Koordinaadid", $"Vajutasid Lahtrisse: \nRida: {rida}\nVeerg: {veerg})", "Selge");
                };
                kast.GestureRecognizers.Add(tap);
            }
        }
        return gr3x3;
    }
}