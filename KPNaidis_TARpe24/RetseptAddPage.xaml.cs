using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;

namespace KPNaidis_TARpe24;

public partial class RetseptAddPage : ContentPage
{
    
    private readonly string _failiTee;
    Entry entryNimi, entrySelgitus, entryPildilink;
    Picker entryKategooria;
    string valitudPildiTee = "";
    Label lblValitudPilt;
    public ICommand LisaCommand { get; }
    public ICommand KustutaCommand { get; }
    public ObservableCollection<Retsept> Recipes { get; set; } = new();
    ListView list;
    public RetseptAddPage()
    {
        this.Title = "Retsepti haldus";

        // 1. SISESTUSVÄLJAD
        entryNimi = new Entry { Placeholder = "Nimi" };
        entryKategooria = new Picker
        {
            Title = "Kategooria",
            ItemsSource = Enum.GetValues(typeof(RetseptKategooria))
                      .Cast<RetseptKategooria>()
                      .ToList(),
            HorizontalOptions = LayoutOptions.Center
        };
        entrySelgitus = new Entry { Placeholder = "Selgitus" };
        entryPildilink = new Entry { Placeholder = "Pildi link" };

        // 2. PILDI VALIMISE KONTROLLID
        Button btnValiPilt = new Button { Text = "📷 Vali pilt galeriist", BackgroundColor = Colors.LightBlue };
        btnValiPilt.Clicked += BtnValiPilt_Clicked;

        lblValitudPilt = new Label { Text = "Pilti pole valitud (kasutatakse vaikimisi pilti)", FontSize = 12, TextColor = Colors.Gray };


        // Määrame turvalise asukoha, kuhu fail salvestatakse
        _failiTee = Path.Combine(FileSystem.AppDataDirectory, "retseptid.json");

        Button btnLisa = new Button { Text = "Lisa retsept", BackgroundColor = Colors.LightGreen };
        btnLisa.Clicked += LisaTermin;

        Button btnKustuta = new Button { Text = "Kustuta valitud riik", BackgroundColor = Colors.LightPink };
        btnKustuta.Clicked += Kustuta_Clicked;

        /*LisaCommand = new Command(LisaTermin);
        KustutaCommand = new Command<Retsept>(KustutaTermin);*/

        LaeAndmed();

        // Määrame TableView lehe peamiseks sisuks
        Content = new VerticalStackLayout
        {
            Children = {
                new Label
                {
                    Text = "Retseptid!",
                    FontSize = 36,
                    FontFamily = "Digital System 400",
                    TextColor = Colors.Black,
                    HorizontalOptions = LayoutOptions.Center
                },
                    entryNimi,
                    entryKategooria,
                    entrySelgitus,
                    entryPildilink,
                    btnValiPilt,   // Uus nupp galerii jaoks
                    lblValitudPilt, // Tagasiside silt
                    btnLisa,

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

    private async void LisaTermin(object sender, EventArgs e)
    {
        // Kontrollime, et väljad poleks tühjad
        if (string.IsNullOrWhiteSpace(entryNimi.Text) || entryKategooria.SelectedItem == null)
            return;

        if (valitudPildiTee != "")
        {
            var uusItem = new Retsept
            {
                Nimi = entryNimi.Text,
                Selgitus = entrySelgitus.Text,
                Kategooria = entryKategooria.SelectedItem.ToString(),
                Pildilink = valitudPildiTee
            };
            Recipes.Add(uusItem);
        }
        else if (string.IsNullOrWhiteSpace(entryPildilink.Text))
        {
            var uusItem = new Retsept
            {
                Nimi = entryNimi.Text,
                Selgitus = entrySelgitus.Text,
                Kategooria = entryKategooria.SelectedItem.ToString(),
                Pildilink = valitudPildiTee
            };
            Recipes.Add(uusItem);
        }


        // Paneme programmi kuulama, kui selle termini märkeruutu vajutatakse



        // Tühjendame tekstikastid
        entryNimi.Text = string.Empty;
        entryKategooria.SelectedItem = null;
        entryPildilink.Text = string.Empty;
        valitudPildiTee = string.Empty;

        SalvestaAndmed();
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
}