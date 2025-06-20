namespace MuseiChiese.Modelli.Modelli
{
    public class ElementoOsm
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
        public double Latitudine { get; set; }
        public double Longitudine { get; set; }
        public string Nome { get; set; }

        public Dictionary<string, string> Tags { get; set; }

        public string Comune => Tags != null && Tags.ContainsKey("addr:city") ? Tags["addr:city"] : "";

        public string TipoElemento =>
            Tags != null && Tags.ContainsKey("amenity") && Tags["amenity"] == "place_of_worship" ? "place_of_worship" :
            Tags != null && Tags.ContainsKey("tourism") && Tags["tourism"] == "museum" ? "museum" :
            "";
    }

}
