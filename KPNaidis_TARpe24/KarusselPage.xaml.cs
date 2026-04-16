namespace KPNaidis_TARpe24;

public class CarouselItem
{
	public string Title { get; set; }
	public string ImageUrl { get; set; }
}

public partial class KarusselPage : ContentView
{
	//Klassitaseme väljad, et hoida carouselview ja selle elemendid ja saaks neid kasutada kogu klassis
	private CarouselView carouselView;
	private List<CarouselItem> items;
	public KarusselPage()
	{
		
	}
}

