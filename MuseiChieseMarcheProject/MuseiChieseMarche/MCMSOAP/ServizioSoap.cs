using MuseiChiese.Modelli;
using MuseiChiese.Modelli.Modelli;
using System.ServiceModel;


namespace MuseiChieseMarche.MCMSOAP
{

    [ServiceContract]
    public interface IComuneMarche
    {
        [OperationContract]
        string ContaPerComune(string comune);
    }

    public class MuseiChieseMarcheCount : IComuneMarche
    {
        public string ContaPerComune(string comune)
        {
            var lista = FunzioniInterrogazioniServiziOsm.DaiServizi().Result;

            var filtrati = lista.Where(e =>
                !string.IsNullOrWhiteSpace(e.Comune) &&
                e.Comune.ToLower().Contains(comune.ToLower())
            );

            int musei = filtrati.Count(e => e.TipoElemento == "museum");
            int chiese = filtrati.Count(e => e.TipoElemento == "place_of_worship");

            return $"Nel comune di {comune} ci sono {musei} musei e {chiese} chiese.";
        }


    }
}


