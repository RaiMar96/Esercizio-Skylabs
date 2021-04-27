# Esercizio-Skylabs
Servizio REST con ASP.NET Core

- **POST**  localhost:*{portNumber}*/api/TestWebItems/product

- **GET**   localhost:*{portNumber}*/api/TestWebItems/product?name={nomeprodotto}*

- **GET**   localhost:*{portNumber}*/api/TestWebItems/ping?test=test*

- **GET**   localhost:*{portNumber}*/api/TestWebItems/ping*

Il body per la POST deve avere la struttura mostrata dal json di esempio

```json
{
 "nome" : "Notebook",
 "prezzo" : 20.00
}
```