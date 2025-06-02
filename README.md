# Global Solution API

Este projeto é uma **API REST** para gestão de **usuários**, **localizações** e **lembretes**, construída em **.NET 9** com **ASP.NET Core** e **Entity Framework Core (Oracle)**.

---

## 👁️ Visão Geral

* **Tecnologias**: .NET 9, ASP.NET Core, Entity Framework Core, Oracle, Swashbuckle (Swagger UI), Razor Pages (UI)
* **Arquitetura**: API em camadas com Controllers, DTOs, Services e Repositórios (EF Core).
* **Relacionamentos**: `1:N` entre `Usuario` e `Lembrete`, `1:N` entre `Localizacao` e `Usuario`.

---

## 📐 Diagrama de Classes

(User) 1 --- \* (Lembrete)
(Localizacao) 1 --- \* (Usuario)
(Substitua pelo diagrama UML gerado ou adicione uma imagem aqui.)

---

## 🛠️ Desenvolvimento

1.  **Clone o repositório**:

    ```bash
    git clone https://github.com/HeitorOrtega/.NET_GLOBAL.git
    cd GlobalSolution
    ```

2.  **Configure sua string de conexão Oracle em `appsettings.json`**:

    ```json
    {
      "ConnectionStrings": {
        "OracleConnection": "User Id=RM557825;Password=fiap25;Data Source=//host:1521/ORCL"
      }
    }
    ```

3.  **Crie e aplique as migrations**:

    ```bash
    dotnet ef migrations add Initial
    dotnet ef database update
    ```

4.  **Instale dependências de front-end (jQuery, validação)**:

    ```bash
    cd gs.net
    libman restore
    ```

5.  **Rode a aplicação**:

    ```bash
    dotnet run --project GS.NET
    ```

6.  Acesse `https://localhost:5030/swagger` para documentação interativa.

---

## 🚀 Endpoints da API

**Base URL**: `https://localhost:5030/v1`

### Usuários

| Método   | Rota             | Descrição                 |
| :------- | :--------------- | :------------------------ |
| `GET`    | `/Usuarios`      | Lista todos os usuários   |
| `GET`    | `/Usuarios/{id}` | Obtem usuário por ID      |
| `POST`   | `/Usuarios`      | Cria novo usuário         |
| `PUT`    | `/Usuarios/{id}` | Atualiza usuário          |
| `DELETE` | `/Usuarios/{id}` | Remove usuário            |

**Exemplo de `POST /Usuarios`**

```http
POST /v1/Usuarios HTTP/1.1
Content-Type: application/json

{
  "nome": "João Silva",
  "senha": "senha123",
  "email": "joao@example.com",
  "cpf": "12345678901"
}
```

### Lembretes

| Método   | Rota              | Descrição                 |
| :------- | :---------------- | :------------------------ |
| `GET`    | `/Lembretes`      | Lista todos os lembretes  |
| `GET`    | `/Lembretes/{id}` | Obtem lembrete por ID     |
| `POST`   | `/Lembretes`      | Cria novo lembrete        |
| `PUT`    | `/Lembretes/{id}` | Atualiza lembrete         |
| `DELETE` | `/Lembretes/{id}` | Remove lembrete           |

```http

POST /v1/Lembretes HTTP/1.1
Content-Type: application/json

{
  "mensagem": "Reunião com equipe",
  "dataHora": "2025-06-01T14:00:00",
  "usuarioId": 1
}
```

### Localizações

| Método   | Rota                 | Descrição                   |
| :------- | :------------------- | :-------------------------- |
| `GET`    | `/Localizacoes`      | Lista todas as localizações |
| `GET`    | `/Localizacoes/{id}` | Obtem localização por ID    |
| `POST`   | `/Localizacoes`      | Cria nova localização       |
| `PUT`    | `/Localizacoes/{id}` | Atualiza localização        |
| `DELETE` | `/Localizacoes/{id}` | Remove localização          |


**POST /v1/Localizacoes HTTP/1.1**
Content-Type: application/json

```http
{
  "logradouro": "Av. Paulista",
  "numero": "1000",
  "complemento": "Apto 101",
  "bairro": "Bela Vista",
  "cidade": "Sao Paulo",
  "cep": "01310200"
}
```

---

### ✅ Testes

- Utilize o Swagger UI (/swagger) para testar interativamente.
- Exemplos de requisições estão disponíveis nas seções acima.
- Você pode usar Insomnia ou Postman, importando o collection JSON.

---

### 📂 Pasta de Front‑end (Razor + jQuery)
- As Pages Razor para CRUD de usuários estão localizadas em GS.NET/Pages/Usuarios/*.cshtml.
- As validações são realizadas via jQuery Validate e unobtrusive validation.

### 🧾 Licença
MIT © Heitor Ortega

## Integrantes
- Pedro Saraiva - 555160
- Marcos Lourenço - 556496
