# MuseiChieseMarcheProject
Il progetto Musei Chiese Marche è un progetto ASP.NET Core MVC che consente di visualizzare musei e chiese nella regione Marche, partendo da un dataset ottenuto tramite servizi OpenStreetMap (Overpass API) e salvato localmente in formato JSON. È stato implementato un servizio SOAP, esposto all'endpoint /Soap/Comune.asmx, che consente di contare musei e chiese presenti in un determinato comune. 
L’intera applicazione è stata containerizzata con Docker per garantire portabilità e deploy in ambiente cloud-ready.
