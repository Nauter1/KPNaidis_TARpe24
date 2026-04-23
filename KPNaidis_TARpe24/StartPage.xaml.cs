namespace KPNaidis_TARpe24;

public partial class StartPage : ContentPage
{
	VerticalStackLayout vst;
	ScrollView sv;
	public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(), new FigurePage(), new Timer_Page(), new ValgusFoorPage(), new DateTimePage(), new StepperSliderPage(), new RGBSlider(), new Snowman(), new PopupPage(), new PickerImagePage(), new TripsTrapsTrull(), new KontaktAndmed(), new DynamicList(), new RiikValik(), new KarusselPages(), new InteraktiivneKarussel() };
	public List<string> LeheNimed = new List<string>() { "Tekst", "Kujund", "Timer", "Foor", "DateTime", "Stepper", "RGB Slider", "Snowman", "PopUp", "Grid", "Trips-Traps-Trull", "Kontakt Andmed", "Dynamic List", "Riik Valik", "KarusselPages", "InteraktiivneKarussel" };
	public StartPage()
	{
		// Title = "Avaleht";
		vst = new VerticalStackLayout { Padding = 20, Spacing = 15 };
		for (int i=0; i < Lehed.Count; i++)
		{
			Button nupp = new Button
			{
				Text = LeheNimed[i],
				FontSize = 36,
				FontFamily = "Digital System 400",
				BackgroundColor = Colors.LightGray,
				TextColor = Colors.Black,
				CornerRadius = 10,
				HeightRequest = 60,
				ZIndex = i
			};
			vst.Add(nupp);
			nupp.Clicked += (sender, e) =>
			{
				var valik = Lehed[nupp.ZIndex];
				Navigation.PushAsync(valik);
			};
		}
		Button nulliNupp = new Button
		{
			Text = "Nulli seaded (testimiseks)",
			BackgroundColor = Colors.Red,
			TextColor = Colors.White,
			CornerRadius = 10,
			HeightRequest = 50,
			Margin = new Thickness(0, 30, 0, 0)
		};
		nulliNupp.Clicked += async (sender, e) =>
		{
			Preferences.Default.Remove("EsimeneKäivitamine");
			await DisplayAlertAsync("Edukalt nullitud", "Mälu on tühjendatud. Kui sa lehe uuesti avad, käitub äpp nagu täiesti uus!", "OK");
		};
		vst.Add(nulliNupp);
		sv = new ScrollView { Content = vst };
		Content = sv;
		//InitializeComponent();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		// 1. loeme seadme mälust muutuja "EsimeneKäivitamine".
		// Kui sellist muutujat pole (äpp on uus), annab see vaikimisi väärtuseks 'true'.
		bool onEsimeneStart = Preferences.Default.Get("EsimeneKäivitamine", true);
		// 2. kui on esimene start, kuvame dialoogiakna
		if (onEsimeneStart)
		{
			bool vastus = await DisplayAlertAsync("Tere tulemast!",
				"Tundub, et avasid selle rakenduse esimest korda. kas soovid näha lühikest juhendit?",
				"Jah palun",
				"Ei, saan ise hakkama");
			if (vastus)
			{
				await DisplayAlertAsync("Juhend",
					"Siin on sinu lühike juhend: vali menüüst sobiv teema ja uuri, kuidas elemendid töötavad!",
					"Selge");

				// 3. Salvestame info, et esimene käivitamine on tehtud.
				Preferences.Default.Set("EsimeneKäivitamine", false);
			}
		}
	}
}