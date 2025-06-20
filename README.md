# Musei Chiese Marche Project
MuseiChieseMarcheProject è un'applicazione ASP.NET Core MVC che consente di visualizzare musei e chiese nella regione Marche, a partire da dati ottenuti via OpenStreetMap (tramite Overpass API) e salvati in un file JSON locale.
L'interfaccia utente consente di cercare e filtrare le strutture. È inoltre stato realizzato un servizio SOAP accessibile all’endpoint /Soap/Comune.asmx, che restituisce il numero di musei e chiese presenti in un dato comune.

L’intera applicazione è stata containerizzata con Docker per garantirne la portabilità e l’esecuzione su qualsiasi ambiente compatibile con container (cloud o locale).

🧩 <b>Funzionalità principali</b>  
✅ Visualizzazione di musei e chiese nelle Marche, tramite interfaccia web  
🔍 Ricerca per nome e filtro per comune  
📡 Esposizione di un servizio SOAP per il conteggio delle strutture per comune  
🐳 Containerizzazione con Docker  

⚙️ <b>Come eseguire l'applicazione</b>  
Clona la repository: 
<pre lang="markdown"> git clone https://github.com/sofiacuccu00/MuseiChieseMarcheProject.git </pre>  
cd MuseiChieseMarcheProject  

🐳 <b>Docker</b>  
🔨 <b>Crea l'immagine:</b>  
<pre lang="markdown"> docker build -t museichiese-app -f Dockerfile .. </pre>  
▶️ <b>Avvia il container:</b>  
<pre lang="markdown"> docker run -d -p 8080:80 --name museichiese-container museichiese-app   </pre>  
🌐 <b>Accedi all’app:</b>  
Apri il browser all'indirizzo:  
http://localhost:8080  

📡 <b>Accesso al servizio SOAP:</b>  
L'endpoint WSDL è disponibile a:  
http://localhost:8080/Soap/Comune.asmx?wsdl  

🛑 <b>Comandi utili</b>  
<pre lang="markdown"> docker stop museichiese-container  # Ferma il container</pre>   
<pre lang="markdown"> docker rm museichiese-container  # Rimuove il container</pre>  

