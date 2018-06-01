using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OstraKlepka
{   [Serializable]
    public class Turniej_Siatkowka : Turniej
    {
        public List<Siatkowka> listaMeczowSiatkowki = new List<Siatkowka>();
        private List<Sedzia_Pomocniczy> listaSedziowPom = new List<Sedzia_Pomocniczy>();
        private int[] randomTab = new int[2];  // tablica potrzebna do losowania sędziów pomocniczych
        public Turniej_Siatkowka (List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow, List<Sedzia_Pomocniczy> _listaSedziowPom):base(_listaDruzyn, _listaSedziow)
        {
            listaSedziowPom = new List<Sedzia_Pomocniczy>(_listaSedziowPom);
        }

        public void SetSedziowiePom(List<Sedzia_Pomocniczy> _listaSedziowPom)
        {
            listaSedziowPom = new List<Sedzia_Pomocniczy>(_listaSedziowPom);
        }
        public List<Sedzia_Pomocniczy> GetSedziowiePom()
        {
            return listaSedziowPom;
        }

        private void losowaniePomocniczych()
        {
            randomTab[0] = random.Next(listaSedziowPom.Count);
            randomTab[1] = random.Next(listaSedziowPom.Count);

            while (randomTab[0] == randomTab[1])
            {
                randomTab[1] = random.Next(listaSedziowPom.Count);
            }
        }

        public override void GenerujMeczeGrupowe()
        {
            for (int i = 0; i < listaDruzyn.Count - 1 ; i++)
            {
                for(int j = i + 1; j < listaDruzyn.Count; j++)
                {
                    losowaniePomocniczych();
                    listaMeczowSiatkowki.Add(new Siatkowka(listaDruzyn[i], listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)],
                                                           listaSedziowPom[randomTab[0]], listaSedziowPom[randomTab[1]], "grupowy"));
                }
            }          
        }

        override public void GenerujMeczePolFinal()
        {
            for (int i = 0; i < zwyciezcyGrup.Count - 1; i++)
            {
                for (int j = i + 1; j < zwyciezcyGrup.Count; j++)
                {
                    losowaniePomocniczych();
                    listaMeczowSiatkowki.Add(new Siatkowka(zwyciezcyGrup[i], zwyciezcyGrup[j], listaSedziow[random.Next(listaSedziow.Count)],
                                                           listaSedziowPom[randomTab[0]], listaSedziowPom[randomTab[1]], "półfinałowy"));
                }
            }
        }
        override public void GenerujMeczeFinal()
        {
            losowaniePomocniczych();
            listaMeczowSiatkowki.Add(new Siatkowka(zwyciezcyPolFinal[0], zwyciezcyPolFinal[1], listaSedziow[random.Next(listaSedziow.Count)],
                                                   listaSedziowPom[randomTab[0]], listaSedziowPom[randomTab[1]], "finałowy"));
        }

        public List<Siatkowka> GetListaMeczowSiatkowki()
        {
            return listaMeczowSiatkowki;
        }
        public void ZapiszDoPliku<Turniej_Siatkowka>(string sciezka, Turniej_Siatkowka ObiektDoZapisania)
        {
            string nazwaTurnieju;
            nazwaTurnieju = Console.ReadLine();

            using (Stream stream = File.Open(sciezka + nazwaTurnieju + ".sia", FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, ObiektDoZapisania);
            }
        }
        public Turniej_Siatkowka OdczytajZPliku<Turniej_Siatkowka>(string sciezka)

            {

            using (Stream stream = File.Open(sciezka, FileMode.Open))
            {

                var binaryFormatter =  new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                return (Turniej_Siatkowka)binaryFormatter.Deserialize(stream);

            }

            }

    
        }




    }

