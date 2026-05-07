using Microsoft.Maui.Layouts;

namespace KPNaidis_TARpe24;

public partial class MaluMang : ContentPage
{
    private Game? game;
    private int counter = 0;
    private Random rng = new Random();

    public MaluMang()
    {
        InitializeComponent();

        ThemePicker.ItemsSource = new List<Theme>
        {
            new Theme("Hele", Colors.White, Colors.Black, "Roboto"),
            new Theme("Tume", Colors.Black, Colors.White, "Pacifico"),
            new Theme("Sinine", Colors.LightBlue, Colors.DarkBlue, "Lobster")
        };

        ThemePicker.SelectedIndexChanged += ThemePicker_SelectedIndexChanged;
        ThemePicker.SelectedIndex = 0;
    }

    private void ThemePicker_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (ThemePicker.SelectedItem is Theme theme)
        {
            theme.Apply(this);
        }
    }

    private async void OnStartClicked(object sender, EventArgs e)
    {
        if (ThemePicker.SelectedItem is not Theme theme)
        {
            await DisplayAlert("Error", "Choose theme", "OK");
            return;
        }

        var player = new Player("Player", 0);

        if (game != null)
        {
            game.Stop();
        }

        game = new Game(player, theme);

        GameContainer.Children.Clear();

        GameContainer.Children.Add(game.GameGrid);

        await game.Start();
    }



}