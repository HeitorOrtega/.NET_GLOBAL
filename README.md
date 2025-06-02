Tema: Monitoramento Inteligente e Prevenção de Riscos (enchentes, furacões)

Tecnologias:

- .NET 9 / C# 12

- ASP.NET Core (Controllers + Razor Pages)

- Entity Framework Core (Oracle.ManagedDataAccess)

- Swagger (Swashbuckle) para documentação e testes interativos

- jQuery + jQuery Validate + jQuery Unobtrusive Validation para validações no front-end Razor

Arquitetura:

- Camada de API (Controllers e DTOs)

- Camada de Dados (Entity Framework Core e AppDbContext)

- Camada de Front-end (Razor Pages + TagHelpers + Bootstrap)

- Relacionamentos principais no banco:

- Usuário (Usuario) – 1:N – Lembrete (Lembrete)

- Localização (Localizacao) – 1:N – Usuário (Usuario)

---

## 📐 Diagrama de Classes

![image](https://github.com/user-attachments/assets/cae3b5a6-3161-4add-ad6b-c5ca71bcdfd1)



---

## 🛠️ Desenvolvimento

1.  **Clone o repositório** :
   ```bash
   git clone https://github.com/HeitorOrtega/.NET_GLOBAL.git
   ```

  **Abra o terminal do projeto e:**

2.  **Crie e aplique as migrations**:

    ```bash
      dotnet ef migrations add InitialCreate
      dotnet ef database update
    ```

3.  **Instale dependências de front-end (jQuery, validação)**:

    ```bash
    cd GS.NET
    libman restore

    ```

4.  **Rode a aplicação**:

    ```bash
    dotnet run 
    ```

5.  Acesse `https://localhost:5030/swagger` para documentação interativa.

6. **URL :**
   ```bash
       https://localhost:5030)
    ```

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
POST /v1/Usuarios 
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

**Exemplo de `POST /Lembretes`**

```http

POST /v1/Lembretes 
Content-Type: application/json



{
  "mensagem": "Reunião com equipe",
  "dataHora": "2025-06-01T14:00:00",
  "usuarioId": 1 "    (obs chamar um ID existente no projeto para criar um lembrete)"
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


**Exemplo de `POST /Localizacoes`**


```http
POST /v1/Localizacoes
Content-Type: application/json
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

✅ Testes
Via Swagger UI

Execute dotnet run e abra no navegador:

```bash
https://localhost:5030/swagger
```

- Clique em cada rota (/v1/Usuarios, /v1/Localizacoes, /v1/Lembretes) e use a seção “Try it out” para testar POST, PUT, GET e DELETE.

---

📂 Front-end Razor + jQuery
Dentro da pasta GS.NET/Pages/Usuarios, existem as seguintes páginas:

Index.cshtml

Lista todos os usuários e exibe colunas de Dados Pessoais e Endereço completo (Rua, Número, Bairro, Cidade, Estado).

Ações: [Ver] [Editar] [Excluir].

Create.cshtml

Formulário para criar um novo usuário + endereço associado.

Campos: Nome, Email, Senha, CPF, CEP, Logradouro, Número, Complemento (opcional), Bairro, Cidade.

Validações client-side via:

<input asp-for="Cep" class="form-control @(ViewData.ModelState["Cep"]?.Errors.Count > 0 ? "is-invalid" : "")" />
```http
<div class="invalid-feedback">
  <span asp-validation-for="Cep"></span>
</div>

<script src="~/lib/jquery/dist/jquery.min.js"></script>
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js"></script>

```

Edit.cshtml

Formulário semelhante ao Create, porém pré-preenchido com os dados do usuário e endereço atual.

Usa um Partial chamado _UsuarioForm.cshtml para reaproveitar markup de campos (deve estar em /Pages/Shared/_UsuarioForm.cshtml ou /Pages/Usuarios/_UsuarioForm.cshtml).

Delete.cshtml 

Página de confirmação de exclusão.

---


### 🧾 Licença
MIT © Heitor Ortega

## Integrantes
- Heitor Ortega - 557825
- Pedro Saraiva - 555160
- Marcos Lourenço - 556496
