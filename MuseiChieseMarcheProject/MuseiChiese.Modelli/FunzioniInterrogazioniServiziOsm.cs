using MuseiChiese.Modelli.Modelli;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MuseiChiese.Modelli
{
    public static class FunzioniInterrogazioniServiziOsm
    {
        public static async Task<ElementoOsm[]> DaiServizi()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "Assets", "museiChiese.json");
            if (!File.Exists(filePath))
                throw new FileNotFoundException("JSON non trovato: " + filePath);

            string json = await File.ReadAllTextAsync(filePath);

            var raw = JsonConvert.DeserializeObject<OverpassResult>(json);

            var elenco = raw.elements
                .Where(el => el.tags != null && el.tags.ContainsKey("name"))
                .Select(el => new ElementoOsm
                {
                    Id = el.id,
                    Tipo = el.type,
                    Latitudine = el.lat,
                    Longitudine = el.lon,
                    Nome = el.tags["name"],
                    Tags = el.tags 
                })
                .ToArray();

            return elenco;
        }

        public static async Task<ElementoOsm[]> RicercaStrutture(string nome = "", string comune = "")
        {
            var tutti = await DaiServizi();

            var risultati = tutti.Where(s =>
                (string.IsNullOrEmpty(nome) || s.Nome.ToLower().Contains(nome.ToLower())) &&
                (string.IsNullOrEmpty(comune) || (s.Comune ?? "")
                    .ToLower().Contains(comune.ToLower()))
            ).ToArray();

            return risultati;
        }

        private class OverpassResult
        {
            public ElementoGrezzo[] elements { get; set; }
        }

        private class ElementoGrezzo
        {
            public long id { get; set; }
            public string type { get; set; }
            public double lat { get; set; }
            public double lon { get; set; }
            public Dictionary<string, string> tags { get; set; }
        }
    }
}
