using Microsoft.Maui.Graphics.Text;

namespace KPNaidis_TARpe24;

public partial class PopupPage : ContentPage
{
	Button Query;
    Button MathAddition;
    Button MathSubtraction;
    Button MathMultiplication;
    Random rnd = new Random();

    string nimi;
    string result;
    VerticalStackLayout vsl;
	public PopupPage()
	{
        // 1. loome esimese nupu (lihtne teade)
        Button alertButton = new Button
        {
            Text = "Teade",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };
        alertButton.Clicked += AlertButtonClicked;

        Button alertYesNoButton = new Button
        {
            Text = "Jah või ei",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };
        alertYesNoButton.Clicked += AlertYesNoButtonClicked;

        Button alertListButton = new Button
        {
            Text = "Valik",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };
        alertListButton.Clicked += AlertListButtonClicked;

        Button alertQuestButton = new Button
        {
            Text = "Küsimus",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };
        alertQuestButton.Clicked += AlertQuestButtonClicked;

        Query = new Button
        {
            Text = "Sisesta Nimi..",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
            ZIndex = 1
        };
        Query.Clicked += QueryClicked;
        MathAddition = new Button
        {
            Text = "Liitmine",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
            ZIndex = 1
        };
        MathAddition.Clicked += MathAdditionClicked;
        MathSubtraction = new Button
        {
            Text = "Lahutamine",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
            ZIndex = 1
        };
        MathSubtraction.Clicked += MathSubtractionClicked;
        MathMultiplication = new Button
        {
            Text = "Korrutamine",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
            ZIndex = 1
        };
        MathMultiplication.Clicked += MathMultiplicationClicked;

        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = { Query, MathAddition, MathSubtraction, MathMultiplication , alertButton, alertYesNoButton, alertListButton, alertQuestButton },
            HorizontalOptions = LayoutOptions.Center
        };
        Content = vsl;
    }
    private async void AlertButtonClicked(object? sender, EventArgs e)
    {
        await DisplayAlertAsync("Teade", "Teil on uus teade", "OK");
    }
    private async void AlertYesNoButtonClicked(object? sender, EventArgs e)
    {
        bool result = await DisplayAlertAsync("Kinnitus", "Kas oled kindel?", "Olen Kindel", "Ei Ole Kindel");
        await DisplayAlertAsync("Teade", "Teie valik on: " + (result ? "Jah" : "Ei"), "Ok");
    }
    private async void AlertListButtonClicked(object? sender, EventArgs e)
    {
        string action = await DisplayActionSheetAsync("Mida teha?", "Loobu", "Kustutada", "Tantsida", "Laulda", "Joonestada");
        if (action != null && action != "Loobu")
        {
            await DisplayAlertAsync("Valik", "Sa valisid tegevuse: " + action, "OK");
        }
    }
    private async void AlertQuestButtonClicked(object sender, EventArgs e)
    {
        string result1 = await DisplayPromptAsync("Küsimus", "Kuidas läheb?", placeholder: "Tore!");
        string result2 = await DisplayPromptAsync("Vasta", "Millega võrdub 5+5?", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);
    }
    private async void QueryClicked(object sender, EventArgs e)
    {
        nimi = await DisplayPromptAsync("Küsimus", "Mis on sinu nimi?", placeholder: "Sisesta nimi");
        await DisplayAlertAsync("Teade", "Tere " + nimi + "!", "OK");
        Preferences.Default.Set("DefaultNimi", nimi);
    }
    private async void MathAdditionClicked(object sender, EventArgs e)
    {
        int A = rnd.Next(1, 100);
        int B = rnd.Next(1, 100);
        int C = A + B;
        int resultM = int.Parse(await DisplayPromptAsync("Küsimus", "Mis on " + A + " + " + B + "?", placeholder: "Sisesta Vastus", keyboard: Keyboard.Numeric));
        try 
        { 
            if (resultM == C)
            {
                await DisplayAlertAsync("Õige!", resultM + " on Õige Vastus!", "OK");
            }
            else
                await DisplayAlertAsync("Vale..", resultM + " on Vale Vastus!", "OK");
        }
        catch
        {

        }
    }
    private async void MathSubtractionClicked(object sender, EventArgs e)
    {
        int A = rnd.Next(1, 100);
        int B = rnd.Next(1, 100);
        int C = A - B;
        int resultM = int.Parse(await DisplayPromptAsync("Küsimus", "Mis on " + A + " - " + B + "?", placeholder: "Sisesta Vastus", keyboard: Keyboard.Numeric));
        try
        {
            if (resultM == C)
            {
                await DisplayAlertAsync("Õige!", resultM + " on Õige Vastus!", "OK");
            }
            else
                await DisplayAlertAsync("Vale..", resultM + " on Vale Vastus!", "OK");
        }
        catch
        {

        }
    }
    private async void MathMultiplicationClicked(object sender, EventArgs e)
    {
        int A = rnd.Next(1, 100);
        int B = rnd.Next(1, 100);
        int C = A * B;
        int resultM = int.Parse(await DisplayPromptAsync("Küsimus", "Mis on " + A + " * " + B + "?", placeholder: "Sisesta Vastus", keyboard: Keyboard.Numeric));
        try
        {
            if (resultM == C)
            {
                await DisplayAlertAsync("Õige!", resultM + " on Õige Vastus!", "OK");
            }
            else
                await DisplayAlertAsync("Vale..", resultM + " on Vale Vastus!", "OK");
        }
        catch
        {

        }
    }
    private async void MathQuiz(object sender, EventArgs e)
    {
        int A = rnd.Next(1, 100);
        int B = rnd.Next(1, 100);
        int C = A * B;
        int resultM = int.Parse(await DisplayPromptAsync("Küsimus", "Mis on " + A + " * " + B + "?", placeholder: "Sisesta Vastus", keyboard: Keyboard.Numeric));
        try
        {
            if (resultM != null)
            {
            if (resultM == C)
            {
                await DisplayAlertAsync("Õige!", resultM + " on Õige Vastus!", "OK");
            }
            else
                await DisplayAlertAsync("Vale..", resultM + " on Vale Vastus!", "OK");
            }
        }
        catch
        {

        }
    }
}