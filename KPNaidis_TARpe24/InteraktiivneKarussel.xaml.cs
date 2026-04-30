using KPNaidis_TARpe24.Resources.Localization;
using KPNaidis_TARpe24.Services;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace KPNaidis_TARpe24;

public partial class InteraktiivneKarussel : ContentPage
{
    public string Lasagne => AppResources.Lasagne;
    public string LasagneLongDesc => AppResources.LasagneLongDesc;
    public string Pasta => AppResources.Pasta;
    public string PastaLongDesc => AppResources.PastaLongDesc;
    public string Pizza => AppResources.Pizza;
    public string PizzaLongDesc => AppResources.PizzaLongDesc;
    public string Parmigiano => AppResources.Parmigiano;
    public string ParmigianoLongDesc => AppResources.ParmigianoLongDesc;
    public string Tiramisu => AppResources.Tiramisu;
    public string TiramisuLongDesc => AppResources.TiramisuLongDesc;
    public string Risotto => AppResources.Risotto;
    public string RisottoLongDesc => AppResources.RisottoLongDesc;

    public class CarouselItem

    {

        public string Title { get; set; }

        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string LongDesc { get; set; }

    }

    private CarouselView carouselView;

    // List asendati ObservableCollectioniga

    private ObservableCollection<CarouselItem> items;

    private int position = 0;

    public InteraktiivneKarussel()

    {

        Title = "Karussell - Dünaamiline lisamine";

        var lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        if (lang == "et")
        {
            BackgroundColor = Colors.Green;
        }
        else if (lang == "en")
        {
            BackgroundColor = Colors.Blue;
        }
        else if (lang == "ru")
        {
            BackgroundColor = Colors.Red;
        }
        else
        {
            BackgroundColor = Colors.SteelBlue;
        }

        // Initsialiseerime ObservableCollectioni

        items = new ObservableCollection<CarouselItem>

        {

            new CarouselItem { Title = "Pasta Carbonara", ImageUrl = "https://assets.tmecosys.com/image/upload/t_web_rdp_recipe_584x480_1_5x/img/recipe/ras/Assets/0346a29a89ef229b1a0ff9697184f944/Derivates/cb5051204f4a4525c8b013c16418ae2904e737b7.jpg", Description = Pasta, LongDesc = PastaLongDesc },
            new CarouselItem { Title = "Pizza Margherita", ImageUrl = "https://content.jwplatform.com/v2/media/Bt9tKjiM/poster.jpg?width=720", Description = Pizza, LongDesc = PizzaLongDesc },
            new CarouselItem { Title = "Tiramisu", ImageUrl = "https://www.bunsenburnerbakery.com/wp-content/uploads/2016/06/easy-tiramisu-square-29-735x735.jpg", Description = Tiramisu, LongDesc = TiramisuLongDesc },
            new CarouselItem { Title = "Risotto alla Milanese", ImageUrl = "https://safrescobaldistatic.blob.core.windows.net/media/2022/11/RISOTTO-ALLA-MILANESE.jpg", Description = Risotto, LongDesc = RisottoLongDesc },
            new CarouselItem { Title = "Lasagne", ImageUrl = "https://www.safefood.net/getmedia/acad61f4-bd51-4880-8005-cd46a718e8b5/lasagne.jpg?width=1200&height=800&ext=.jpg",Description = Lasagne, LongDesc = LasagneLongDesc },
            /*            
            new CarouselItem { Title = "Pasta Carbonara", ImageUrl = "https://assets.tmecosys.com/image/upload/t_web_rdp_recipe_584x480_1_5x/img/recipe/ras/Assets/0346a29a89ef229b1a0ff9697184f944/Derivates/cb5051204f4a4525c8b013c16418ae2904e737b7.jpg", Description = Pasta.Text, LongDesc = PastaLongDesc.Text },
            new CarouselItem { Title = "Pizza Margherita", ImageUrl = "https://content.jwplatform.com/v2/media/Bt9tKjiM/poster.jpg?width=720", Description = Pizza.Text, LongDesc = PizzaLongDesc.Text },
            new CarouselItem { Title = "Tiramisu", ImageUrl = "https://www.bunsenburnerbakery.com/wp-content/uploads/2016/06/easy-tiramisu-square-29-735x735.jpg", Description = Tiramisu.Text, LongDesc = TiramisuLongDesc.Text },
            new CarouselItem { Title = "Risotto alla Milanese", ImageUrl = "https://safrescobaldistatic.blob.core.windows.net/media/2022/11/RISOTTO-ALLA-MILANESE.jpg", Description = Risotto.Text, LongDesc = RisottoLongDesc.Text },
            new CarouselItem { Title = "Lasagne", ImageUrl = "https://www.safefood.net/getmedia/acad61f4-bd51-4880-8005-cd46a718e8b5/lasagne.jpg?width=1200&height=800&ext=.jpg",Description = Lasagne.Text, LongDesc = LasagneLongDesc.Text },*/
        };


        // Karusselli loomine (kood on sama, mis eelmises versioonis)

        carouselView = new CarouselView

        {

            ItemsSource = items,

            HeightRequest = 350,

            PeekAreaInsets = new Thickness(40, 0, 40, 0),


            ItemTemplate = new DataTemplate(() =>

            {

                var frame = new Frame

                {

                    CornerRadius = 15,

                    HasShadow = true,

                    Padding = 0,

                    Margin = new Thickness(5),

                    BackgroundColor = Colors.Black

                };

                var tapGesture = new TapGestureRecognizer();

                // Pass the whole bound object (CarouselItem)
                tapGesture.SetBinding(TapGestureRecognizer.CommandParameterProperty, ".");

                tapGesture.Tapped += async (sender, e) =>
                {
                    var tappedItem = e.Parameter as CarouselItem;

                    if (tappedItem != null)
                    {
                        await DisplayAlert(
                            tappedItem.Title,
                            $"{tappedItem.Description}\n\n{tappedItem.LongDesc}",
                            "Sulge"
                        );
                    }
                };

                frame.GestureRecognizers.Add(tapGesture);


                var grid = new Grid();

                var image = new Image { Aspect = Aspect.AspectFill };

                image.SetBinding(Image.SourceProperty, "ImageUrl");
                


                var gradient = new BoxView

                {

                    Background = new LinearGradientBrush

                    {

                        StartPoint = new Point(0, 1),

                        EndPoint = new Point(0, 0),

                        GradientStops = new GradientStopCollection

                        {

                            new GradientStop(Colors.Black.WithAlpha(0.7f), 0),

                            new GradientStop(Colors.Transparent, 1)

                        }

                    }

                };


                var label = new Label

                {

                    TextColor = Colors.White,

                    FontSize = 20,

                    FontAttributes = FontAttributes.Bold,

                    Margin = new Thickness(15),

                    VerticalOptions = LayoutOptions.End

                };

                label.SetBinding(Label.TextProperty, "Title");

                var sublabel = new Label

                {

                    TextColor = Colors.Grey,

                    FontSize = 12,

                    FontAttributes = FontAttributes.Bold,

                    Margin = new Thickness(7),

                    VerticalOptions = LayoutOptions.End

                };

                sublabel.SetBinding(Label.TextProperty, "Description");


                grid.Children.Add(image);

                grid.Children.Add(gradient);

                grid.Children.Add(label);
                grid.Children.Add(sublabel);
                

                frame.Content = grid;

                return frame;

            })

        };

        var indicatorView = new IndicatorView

        {

            IndicatorColor = Colors.LightGray,

            SelectedIndicatorColor = Colors.DarkSlateBlue,

            HorizontalOptions = LayoutOptions.Center,

            Margin = new Thickness(0, 10)

        };

        carouselView.IndicatorView = indicatorView;


        // Nupp elemendi lisamiseks

        var lisaNupp = new Button

        {

            Text = "Lisa uus pilt",

            BackgroundColor = Colors.DarkSlateBlue,

            TextColor = Colors.White,

            CornerRadius = 10,

            Margin = new Thickness(0, 20, 0, 0)

        };


        // Nupu vajutamise sündmus

        lisaNupp.Clicked += (sender, e) =>

        {

            // Lisame kollektsiooni uue elemendi

            items.Add(new CarouselItem

            {

                Title = "Parmigiano Reggiano",

                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Parmigiano_Reggiano%2C_Italien%2C_Europ%C3%A4ische_Union.jpg/250px-Parmigiano_Reggiano%2C_Italien%2C_Europ%C3%A4ische_Union.jpg",
                Description = Parmigiano,
                LongDesc = ParmigianoLongDesc
            });


            // Soovi korral saame karusselli kohe uuele pildile kerida

            carouselView.Position = items.Count - 1;

        }; 




        // Automaatne kerimine

        Device.StartTimer(TimeSpan.FromSeconds(4), () =>

        {

            if (items == null || items.Count == 0) return false;


            position = (position + 1) % items.Count;

            carouselView.Position = position;

            return true;

        });




        Content = new ScrollView

        {

            Content = new VerticalStackLayout

            {

                Padding = 20,

                Spacing = 20, // Jätab elementide vahele ilusa tühimiku

                Children =

                {

                    carouselView,

                    indicatorView,

                    lisaNupp,

                }

            }

        };

    }
}