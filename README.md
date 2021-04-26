# Esercizio-Skylabs
Servizio REST con ASP.NET Core

- **POST**  localhost:*{portNumber}*/api/TestWebItems/product

- **GET**   localhost:*{portNumber}*/api/TestWebItems/product?name={nomeprodotto}*

Il body per la POST deve avere la struttura mostrata dal json di esempio

```json
{
 "nome" : "Notebook",
 "prezzo" : 20.00
}
```