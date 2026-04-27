using KPNaidis_TARpe24.Services;
using System.Collections.ObjectModel;

namespace KPNaidis_TARpe24;

public partial class InteraktiivneKarussel : ContentPage
{
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
        BackgroundColor = Colors.SteelBlue;

        // Initsialiseerime ObservableCollectioni

        items = new ObservableCollection<CarouselItem>

        {

            new CarouselItem { Title = "Pasta Carbonara", ImageUrl = "https://assets.tmecosys.com/image/upload/t_web_rdp_recipe_584x480_1_5x/img/recipe/ras/Assets/0346a29a89ef229b1a0ff9697184f944/Derivates/cb5051204f4a4525c8b013c16418ae2904e737b7.jpg", Description = "Classic Roman pasta dish", LongDesc = "Carbonara (Italian: [karboˈnaːra]) is a pasta dish made with cured pork, hard cheese, eggs, salt, and black pepper. It is typical of the Lazio region of Italy. The dish took its modern form and name in the middle of the 20th century." },
            new CarouselItem { Title = "Pizza Margherita", ImageUrl = "https://content.jwplatform.com/v2/media/Bt9tKjiM/poster.jpg?width=720", Description = "Simple and delicious", LongDesc = "Pizza Margherita, also known as Margherita pizza, is, together with the pizza marinara, the typical Neapolitan pizza. It is roundish in shape with a raised edge (the cornicione) and seasoned with hand-crushed peeled tomatoes, mozzarella (buffalo mozzarella or fior di latte), fresh basil leaves, and extra virgin olive oil. The dough is made by mixing water, salt, and yeast (either sourdough, or fresh or dry baker's yeast) with flour (00 or 0)." },
            new CarouselItem { Title = "Tiramisu", ImageUrl = "https://www.bunsenburnerbakery.com/wp-content/uploads/2016/06/easy-tiramisu-square-29-735x735.jpg", Description = "Popular coffee-flavored dessert", LongDesc = "Tiramisu is an Italian dessert made with coffee-soaked ladyfingers (savoiardi) covered with a cream of egg yolks, sugar, mascarpone, and cocoa powder. It originated in northeastern Italy, and modern versions were popularized in restaurants from the late 1960s. Tiramisu has become one of the most internationally recognised Italian desserts and has inspired many variations in home and professional cooking. The name comes from the Italian tirami su, meaning \"pick me up\" or \"cheer me up\"." },
            new CarouselItem { Title = "Risotto alla Milanese", ImageUrl = "https://safrescobaldistatic.blob.core.windows.net/media/2022/11/RISOTTO-ALLA-MILANESE.jpg", Description = "Creamy saffron rice", LongDesc = "There are various versions of risotto alla milanese. According to Elizabeth David in her Italian Food, \"The classic one is made simply with chicken broth and flavoured with saffron; butter and grated Parmesan cheese are stirred in at the end of the cooking, and more cheese and butter served with it. The second version is made with beef marrow and white wine; a third with Marsala. In each case saffron is used as a flavouring.\"" },
            new CarouselItem { Title = "Lasagne", ImageUrl = "https://www.safefood.net/getmedia/acad61f4-bd51-4880-8005-cd46a718e8b5/lasagne.jpg?width=1200&height=800&ext=.jpg", Description = "Layers of pasta, meat, and cheese", LongDesc = "Lasagna, also known by the plural form lasagne, is a type of pasta made in wide, flat sheets. It originates in Italian cuisine, where it is served in a number of ways, including in broth (lasagne in brodo), but is best known for its use in a baked dish made by stacking layers of pasta, alternating with fillings such as ragù (ground meats and tomato sauce), béchamel sauce, vegetables, cheeses (which may include ricotta, mozzarella, and Parmesan), and seasonings and spices. Typically, cooked pasta is assembled with the other ingredients, topped with grated cheese, and then baked in an oven (al forno): regional variations of this dish are found across Italy." },

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
                Description = "Hard and granular.",
                LongDesc = "Parmesan (Italian: Parmigiano Reggiano, pronounced [parmiˈdʒaːno redˈdʒaːno]) is an Italian hard, granular cheese produced from cow's milk and aged at least 12 months. It is a grana-type cheese, along with Grana Padano, the historic Granone Lodigiano [it], and others. "

            });


            // Soovi korral saame karusselli kohe uuele pildile kerida

            carouselView.Position = items.Count - 1;

        };

        var langNupp = new Button

        {

            Text = "Vaheta keel",

            BackgroundColor = Colors.DarkSlateBlue,

            TextColor = Colors.White,

            CornerRadius = 10,

            Margin = new Thickness(0, 20, 0, 0)

        };


        // Nupu vajutamise sündmus

        langNupp.Clicked += (sender, e) =>

        {


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

                    lisaNupp

                }

            }

        };

    }
}