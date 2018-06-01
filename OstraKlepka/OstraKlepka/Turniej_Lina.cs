using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OstraKlepka
{
    [Serializable]
    class Turniej_Lina : Turniej
    {
        public List<Przeciaganie_Liny> listaPrzeciaganieLiny = new List<Przeciaganie_Liny>();
        public  Turniej_Lina(List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow):base(_listaDruzyn, _listaSedziow)
        {

        }
        public Turniej_Lina():base()
        {

        }
        public override void GenerujMeczeGrupowe()
        {
            for (int i = 0; i < listaDruzyn.Count - 1; i++)
            {
                for (int j = i + 1; j < listaDruzyn.Count; j++)
                {
                    listaPrzeciaganieLiny.Add(new Przeciaganie_Liny(listaDruzyn[i], listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)], "grupowy"));
                }
            }
        }

        override public void GenerujMeczePolFinal()
        {
            for (int i = 0; i < zwyciezcyGrup.Count - 1; i++)
            {
                for (int j = i + 1; j < zwyciezcyGrup.Count; j++)
                {
                    listaPrzeciaganieLiny.Add(new Przeciaganie_Liny(zwyciezcyGrup[i], zwyciezcyGrup[j], listaSedziow[random.Next(listaSedziow.Count)], "półfinałowy"));
                }
            }
        }
        override public void GenerujMeczeFinal()
        {
            listaPrzeciaganieLiny.Add(new Przeciaganie_Liny(zwyciezcyPolFinal[0], zwyciezcyPolFinal[1], listaSedziow[random.Next(listaSedziow.Count)], "finałowy"));
        }


        public void ZapiszDoPliku<Turniej_Lina>(string sciezka, Turniej_Lina ObiektDoZapisania)
        {
            string nazwaTurnieju;
            nazwaTurnieju = Console.ReadLine();

            using (Stream stream = File.Open(sciezka + nazwaTurnieju + ".lin", FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, ObiektDoZapisania);
            }
        }
        public Turniej_Lina OdczytajZPliku<Turniej_Lina>(string sciezka)

        {

            using (Stream stream = File.Open(sciezka, FileMode.Open))
            {

                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                return (Turniej_Lina)binaryFormatter.Deserialize(stream);

            }

        }
      
    }
}
