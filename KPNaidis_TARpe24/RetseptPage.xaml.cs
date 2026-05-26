using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;
using static KPNaidis_TARpe24.RiikValik;

namespace KPNaidis_TARpe24;

public partial class RetseptPage : ContentPage
{
    private readonly string _failiTee;
    Entry entryNimi, entryKategooria, entryPildilink;
    string valitudPildiTee = "";
    Label lblValitudPilt;
    public ICommand LisaCommand { get; }
    public ICommand KustutaCommand { get; }
    public ObservableCollection<Retsept> Recipes { get; set; } = new();
    ListView list;
    public RetseptPage()
	{
        this.Title = "Riikide haldus";

        // 1. SISESTUSVÄLJAD
        entryNimi = new Entry { Placeholder = "Nimi" };
        entryKategooria = new Entry { Placeholder = "Kategooria" };
        entryPildilink = new Entry { Placeholder = "Pildi link" };

        // 2. PILDI VALIMISE KONTROLLID
        Button btnValiPilt = new Button { Text = "📷 Vali pilt galeriist", BackgroundColor = Colors.LightBlue };
        btnValiPilt.Clicked += BtnValiPilt_Clicked;

        lblValitudPilt = new Label { Text = "Pilti pole valitud (kasutatakse vaikimisi pilti)", FontSize = 12, TextColor = Colors.Gray };


        // Määrame turvalise asukoha, kuhu fail salvestatakse
        _failiTee = Path.Combine(FileSystem.AppDataDirectory, "retseptid.json");

        Button btnKustuta = new Button { Text = "Kustuta valitud riik", BackgroundColor = Colors.LightPink };
        btnKustuta.Clicked += Kustuta_Clicked;

        /*LisaCommand = new Command(LisaTermin);
        KustutaCommand = new Command<Retsept>(KustutaTermin);*/

        LaeAndmed();
        list = new ListView
        {
            HasUnevenRows = true,
            ItemsSource = Recipes,
            SelectionMode = ListViewSelectionMode.Single
        };

        list.ItemTapped += List_ItemTapped;

        list.ItemTemplate = new DataTemplate(() =>
        {
            // Pildi element
            Image imgPilt = new Image
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Aspect = Aspect.AspectFit,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 10, 0) // Veeris paremal
            };
            imgPilt.SetBinding(Image.SourceProperty, "Pildilink");

            // Tekstide elemendid
            Label lblNimetus = new Label { FontSize = 18, FontAttributes = FontAttributes.Bold };
            lblNimetus.SetBinding(Label.TextProperty, "Nimi");

            Label lblTootja = new Label { TextColor = Colors.Gray };
            lblTootja.SetBinding(Label.TextProperty, "Kategooria");

            Label lblSelgitus = new Label { TextColor = Colors.Gray };
            lblSelgitus.SetBinding(Label.TextProperty, "Selgitus");

            var textLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                Children = { lblNimetus, lblTootja, lblSelgitus }
            };

            // Kogu rea paigutus (Pilt vasakul, tekst paremal)
            var rowLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10),
                Children = { imgPilt, textLayout }
            };

            return new ViewCell { View = rowLayout };
        });

        // Määrame TableView lehe peamiseks sisuks
        Content = new VerticalStackLayout
        {
            Children = {
                new Label
                {
                    Text = "Riigid!",
                    FontSize = 36,
                    FontFamily = "Digital System 400",
                    TextColor = Colors.Black,
                    HorizontalOptions = LayoutOptions.Center
                },
                    //entryNimi,
                    //entryKategooria,
                    //entryPildilink,
                    //btnValiPilt,   // Uus nupp galerii jaoks
                    //lblValitudPilt, // Tagasiside silt
                    //btnLisa,
                    btnKustuta,
                    list

            }
        };
    }
    private async void BtnValiPilt_Clicked(object sender, EventArgs e)
    {
        try
        {
            var photo = await MediaPicker.Default.PickPhotoAsync();

            if (photo != null)
            {
                valitudPildiTee = photo.FullPath; // Jätame asukoha meelde
                lblValitudPilt.Text = $"Valitud: {photo.FileName}";
                lblValitudPilt.TextColor = Colors.Green;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Viga", "Pildi valimine ebaõnnestus: " + ex.Message, "OK");
        }
    }

    private void KustutaTermin(Retsept item)
    {
        if (item != null && Recipes.Contains(item))
        {
            Recipes.Remove(item);
            SalvestaAndmed();
        }
    }
    private async void Kustuta_Clicked(object sender, EventArgs e)
    {
        Retsept item = list.SelectedItem as Retsept;

        if (item != null && Recipes.Contains(item))
        {
            Recipes.Remove(item);
            SalvestaAndmed();
        }
        else
        {
            await DisplayAlert("Viga", "Palun vali nimekirjast Riik, mida soovid kustutada.", "OK");
        }
    }

    private void SalvestaAndmed()
    {
        var json = JsonSerializer.Serialize(Recipes);
        File.WriteAllText(_failiTee, json);
    }

    private void LaeAndmed()
    {
        if (File.Exists(_failiTee))
        {
            var json = File.ReadAllText(_failiTee);
            var laetudTerminid = JsonSerializer.Deserialize<List<Retsept>>(json);

            if (laetudTerminid != null)
            {
                Recipes.Clear();
                foreach (var t in laetudTerminid)
                {
                    t.PropertyChanged += Item_PropertyChanged;
                    Recipes.Add(t);
                }
            }
        }
    }
    private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // Kui õpilane märgib termini "selgeks", salvestatakse fail automaatselt
        SalvestaAndmed();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Retsept valitudRiik = e.Item as Retsept;

        if (valitudRiik != null)
        {
            await DisplayAlert("Info", $"Retsept: {valitudRiik.Nimi}\nKategooria: {valitudRiik.Kategooria}\nSelgitus: {valitudRiik.Selgitus}", "Sulge");
        }
    }
}