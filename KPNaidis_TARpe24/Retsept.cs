using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace KPNaidis_TARpe24
{
    public class Retsept
    {
        private string _nimi;
        private string kategooria;
        private string _selgitus;
        private string _pildilink;

        // Unikaalne ID aitab vältida vigu kustutamisel
        public string Id { get; set; } = Guid.NewGuid().ToString();
        

        public string Nimi
        {
            get => _nimi;
            set { _nimi = value; OnPropertyChanged(); }
        }

        public string Kategooria
        {
            get => kategooria;
            set { kategooria = value; OnPropertyChanged(); }
        }

        public string Selgitus
        {
            get => _selgitus;
            set { _selgitus = value; OnPropertyChanged(); }
        }

        public string Pildilink
        {
            get => _pildilink;
            set { _pildilink = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
