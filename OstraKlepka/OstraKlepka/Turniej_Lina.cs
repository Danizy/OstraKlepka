using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OstraKlepka
{
    [Serializable]
    public class Turniej_Lina : Turniej
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

        override public void GenerujlTabliceWynikow()
        {

        public void ZapiszDoPliku(string sciezka)
        {

            using (Stream stream = File.Open(sciezka + ".lin", FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, this);
            }
        }
        public void OdczytajZPliku(string sciezka)

        {

            using (Stream stream = File.Open(_sciezka, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Turniej_Lina turniej = (Turniej_Lina)binaryFormatter.Deserialize(stream);

                if(turniej.listaDruzyn != null)
                    this.listaDruzyn = new List<Druzyna>(turniej.listaDruzyn);
                if (turniej.listaSedziow != null)
                    this.listaSedziow = new List<Sedzia>(turniej.listaSedziow);
                if (turniej.listaPrzeciaganieLiny != null)
                    this.listaPrzeciaganieLiny = new List<Przeciaganie_Liny>(turniej.listaPrzeciaganieLiny);
                if (turniej.zwyciezcyFinal != null)
                    this.zwyciezcyFinal = new List<Druzyna>(turniej.zwyciezcyFinal);
                if (turniej.zwyciezcyGrup != null)
                    this.zwyciezcyGrup = new List<Druzyna>(turniej.zwyciezcyGrup);
                if (turniej.zwyciezcyPolFinal != null)
                    this.zwyciezcyPolFinal = new List<Druzyna>(turniej.zwyciezcyPolFinal);
            }

        }
      
    }
}
