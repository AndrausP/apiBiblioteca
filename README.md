# 📚 Biblioteca API

> Uma API RESTful feita com 🧠 **ASP.NET Core** + 💾 **Entity Framework Core** (ou 🔥 SqlSugar), criada para gerenciar uma coleção de livros como um verdadeiro arquiteto da informação!  
> Este projeto foi desenvolvido por **Andraus**, o mestre da organização digital. ⚔️

---

## 🚀 Tecnologias Utilizadas

- 🌐 [.NET 7+ / 8+](https://dotnet.microsoft.com/)
- 🏛️ ASP.NET Core Web API
- 🧠 Entity Framework Core **ou** ⚡ SqlSugar (ORM alternativo)
- 🐬 MySQL
- 🔧 Swagger (via Swashbuckle)
- ☁️ Injeção de dependência (DI)
- 🧪 Testado via Postman e Swagger UI

---

## 🧠 Sobre o Projeto

Essa API permite:

✅ Cadastrar livros  
✅ Consultar todos os livros  
✅ Consultar livro por ID  
✅ Atualizar informações de livros  
✅ Deletar um livro da base

Ideal para estudo de Web API moderna, arquitetura em camadas e boas práticas de desenvolvimento C#!

---

## 🔌 Endpoints

### 📖 `/api/Livro`

| Método | Rota                  | Ação                         |
|--------|-----------------------|------------------------------|
| `GET`  | `/api/Livro`          | 🔍 Obter todos os livros     |
| `GET`  | `/api/Livro/{id}`     | 🔍 Obter livro por ID        |
| `POST` | `/api/Livro/Criar`    | ➕ Adicionar novo livro      |
| `PUT`  | `/api/Livro/{id}`     | ✏️ Atualizar um livro        |
| `DELETE` | `/api/Livro/{id}`   | 🗑️ Remover um livro          |

---

## ⚙️ Como rodar o projeto localmente

1. Clone o repositório:

```bash
git clone https://github.com/SeuUsuario/Biblioteca.git
cd Biblioteca
