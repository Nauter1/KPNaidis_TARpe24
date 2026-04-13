using System.Collections.ObjectModel;

namespace KPNaidis_TARpe24;

public partial class RiikValik : ContentPage
{
    public class Riik
    {
        public string Nimi { get; set; }
        public string Pealinn { get; set; }
        public int Rahvaarv { get; set; }
        public string Lipp { get; set; } // Hoiab pildi nime või seadme failiteed
    }
    ObservableCollection<Riik> riik;
    ListView list;
    Entry entryNimi, entryPealinn, entryRahva;
    // Muutujad pildi valimise jaoks
    string valitudPildiTee = "";
    Label lblValitudPilt;
    public RiikValik()
	{
        riik = new ObservableCollection<Riik>
            {
                new Riik { Nimi="Eesti", Pealinn="Tallinn", Rahvaarv=1372000, Lipp="eesti.png" },
                new Riik { Nimi="Soome", Pealinn="Helsingi", Rahvaarv=5652000, Lipp="finland.png" },
                new Riik { Nimi="Saksamaa", Pealinn="Berliin", Rahvaarv=83497000, Lipp="saksamaa.png" },
                new Riik { Nimi="Holland", Pealinn="Amsterdam", Rahvaarv=18044000, Lipp="holland.png" },

           };

        this.Title = "Riikide haldus";

        // 1. SISESTUSVÄLJAD
        entryNimi = new Entry { Placeholder = "Riigi nimi" };
        entryPealinn = new Entry { Placeholder = "Pealinn" };
        entryRahva = new Entry { Placeholder = "Rahvaarv (täisarv)", Keyboard = Keyboard.Numeric };

        // 2. PILDI VALIMISE KONTROLLID
        Button btnValiPilt = new Button { Text = "📷 Vali pilt galeriist", BackgroundColor = Colors.LightBlue };
        btnValiPilt.Clicked += BtnValiPilt_Clicked;

        lblValitudPilt = new Label { Text = "Pilti pole valitud (kasutatakse vaikimisi pilti)", FontSize = 12, TextColor = Colors.Gray };

        // 3. LISAMISE JA KUSTUTAMISE NUPUD
        Button btnLisa = new Button { Text = "Lisa riik", BackgroundColor = Colors.LightGreen };
        btnLisa.Clicked += Lisa_Clicked;

        Button btnKustuta = new Button { Text = "Kustuta valitud riik", BackgroundColor = Colors.LightPink };
        btnKustuta.Clicked += Kustuta_Clicked;

        // 4. LISTVIEW JA SELLE KUJUNDUS
        list = new ListView
        {
            HasUnevenRows = true,
            ItemsSource = riik,
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
            imgPilt.SetBinding(Image.SourceProperty, "Lipp");

            // Tekstide elemendid
            Label lblNimetus = new Label { FontSize = 18, FontAttributes = FontAttributes.Bold };
            lblNimetus.SetBinding(Label.TextProperty, "Nimi");

            Label lblTootja = new Label { TextColor = Colors.Gray };
            lblTootja.SetBinding(Label.TextProperty, "Pealinn");

            Label lblHind = new Label { TextColor = Colors.DarkBlue, FontAttributes = FontAttributes.Bold };
            lblHind.SetBinding(Label.TextProperty, new Binding("Rahvaarv"  /*stringFormat: "{0} €"*/));

            var textLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                Children = { lblNimetus, lblTootja, lblHind }
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
                    entryNimi,
                    entryPealinn,
                    entryRahva,
                    btnValiPilt,   // Uus nupp galerii jaoks
                    lblValitudPilt, // Tagasiside silt
                    btnLisa,
                    btnKustuta,
                    list

            }
        };
    }

    // --- SÜNDMUSTE TÖÖTLEJAD (Event Handlers) ---

    // Pildi valimine galeriist
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

    // Uue telefoni lisamine
    private void Lisa_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(entryNimi.Text) && !string.IsNullOrWhiteSpace(entryPealinn.Text))
        {
            int hind = 0;
            int.TryParse(entryRahva.Text, out hind);

            // Kui pilti ei valitud, kasutame vaikimisi faili
            string pildiNimi = string.IsNullOrWhiteSpace(valitudPildiTee) ? "default_phone.png" : valitudPildiTee;

            riik.Add(new Riik
            {
                Nimi = entryNimi.Text,
                Pealinn = entryPealinn.Text,
                Rahvaarv = hind,
                Lipp = pildiNimi
            });

            // Puhastame väljad uue sisestuse jaoks
            entryNimi.Text = "";
            entryPealinn.Text = "";
            entryRahva.Text = "";

            // Lähtestame pildi valiku oleku
            valitudPildiTee = "";
            lblValitudPilt.Text = "Pilti pole valitud (kasutatakse vaikimisi pilti)";
            lblValitudPilt.TextColor = Colors.Gray;
        }
        else
        {
            DisplayAlert("Viga", "Palun täida vähemalt Nimi ja Pealinn väljad!", "OK");
        }
    }

    // Telefoni kustutamine
    private async void Kustuta_Clicked(object sender, EventArgs e)
    {
        Riik valitudRiik = list.SelectedItem as Riik;

        if (valitudRiik != null)
        {
            bool vastus = await DisplayAlert("Kinnitus", $"Kas oled kindel, et soovid mudeli {valitudRiik.Nimi} kustutada?", "Jah", "Ei");

            if (vastus == true)
            {
                riik.Remove(valitudRiik);
                list.SelectedItem = null;
            }
        }
        else
        {
            await DisplayAlert("Viga", "Palun vali nimekirjast Riik, mida soovid kustutada.", "OK");
        }
    }

    // Loendis reale vajutamine
    private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Riik valitudRiik = e.Item as Riik;

        if (valitudRiik != null)
        {
            await DisplayAlert("Riigi info", $"Riik: {valitudRiik.Nimi}\nPealinn: {valitudRiik.Pealinn}\nRahvaarv: {valitudRiik.Rahvaarv} €", "Sulge");
        }
    }
}