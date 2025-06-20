#Musei Chiese Marche Project
MuseiChieseMarcheProject è un'applicazione ASP.NET Core MVC che consente di visualizzare musei e chiese nella regione Marche, a partire da dati ottenuti via OpenStreetMap (tramite Overpass API) e salvati in un file JSON locale.
L'interfaccia utente consente di cercare e filtrare le strutture. È inoltre stato realizzato un servizio SOAP accessibile all’endpoint /Soap/Comune.asmx, che restituisce il numero di musei e chiese presenti in un dato comune.

L’intera applicazione è stata containerizzata con Docker per garantirne la portabilità e l’esecuzione su qualsiasi ambiente compatibile con container (cloud o locale).

🧩 #Funzionalità principali
✅ Visualizzazione di musei e chiese nelle Marche, tramite interfaccia web
🔍 Ricerca per nome e filtro per comune
📡 Esposizione di un servizio SOAP per il conteggio delle strutture per comune
🐳 Containerizzazione con Docker

⚙️ #Come eseguire l'applicazione
Clona la repository:
git clone https://github.com/sofiacuccu00/MuseiChieseMarcheProject.git
cd MuseiChieseMarcheProject

🐳 Docker
🔨 #Crea l'immagine:
docker build -t museichiese-app -f Dockerfile ..
▶️ #Avvia il container:
docker run -d -p 8080:80 --name museichiese-container museichiese-app
🌐 #Accedi all’app:
Apri il browser all'indirizzo:
http://localhost:8080

📡 #Accesso al servizio SOAP:
L'endpoint WSDL è disponibile a:
http://localhost:8080/Soap/Comune.asmx?wsdl

🛑 Comandi utili
docker stop museichiese-container         # Ferma il container
docker rm museichiese-container           # Rimuove il container

