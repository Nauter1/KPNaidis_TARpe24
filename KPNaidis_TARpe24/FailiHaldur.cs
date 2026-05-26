using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Collections.Generic;
namespace KPNaidis_TARpe24;

public static class FailiHaldur
{
    // Leiame telefoni süsteemis turvalise koha faili hoidmiseks
    static string failiPesa = Path.Combine(FileSystem.AppDataDirectory, "retseptid.txt");

    public static void Salvesta(string nimi, string kategooria, string pildilink)
    {
        // Salvestame kujul: "Nimi;Maakond" uuele reale
        string rida = $"{nimi};{kategooria};{pildilink}\n";
        File.AppendAllText(failiPesa, rida);
    }

    public static List<Retsept> LoeRetseptid()
    {
        var nimekiri = new List<Retsept>();
        string failiPesa = Path.Combine(FileSystem.AppDataDirectory, "retseptid.txt");

        if (File.Exists(failiPesa))
        {
            string[] read = File.ReadAllLines(failiPesa);
            foreach (string rida in read)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(rida)) continue; // Ignoreerime tühje ridu

                    string[] osad = rida.Split(';');
                    // Nüüd kontrollime, et meil oleks kindlasti 3 osa (Nimi, Kategooria, Pilt)
                    if (osad.Length >= 4)
                    {
                        nimekiri.Add(new Retsept { Nimi = osad[0], Selgitus = osad[1] , /*Kategooria = osad[2],*/ Pildilink = osad[3] });
                    }
                }
                catch (Exception ex)
                {
                    // Viga ignoreeritakse, programm loeb järgmist rida edasi
                    Console.WriteLine($"Viga: {ex.Message}");
                }
            }
        }
        return nimekiri;
    }
}