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
    public RiikValik()
	{
        riik = new ObservableCollection<Riik>
            {
                new Riik { Nimi="Eesti", Pealinn="Tallinn", Rahvaarv=1372000, Lipp="Galaxy.png" },
            };
    }
}