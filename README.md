# 📘 Gerenciador de Agenda – Console App (C#)

## 🧠 Sobre o projeto

O **Gerenciador de Agenda** é uma aplicação de console desenvolvida em **C#**, projetada para gerenciar contatos de maneira simples, funcional e eficiente.
O sistema permite **adicionar, listar, editar, remover e buscar contatos**, utilizando **persistência em arquivo JSON** para armazenar os dados localmente.

O projeto foi desenvolvido com o objetivo de praticar conceitos de **Programação Orientada a Objetos (POO)**, **manipulação de arquivos**, **validação de dados** e **boas práticas de código** em aplicações de console.

---

## ⚙️ Funcionalidades

* ➕ **Adicionar Contato** — cadastra um novo contato com nome e telefone.
* 📋 **Listar Contatos** — exibe todos os contatos salvos.
* ✏️ **Editar Contato** — atualiza informações de um contato existente.
* ❌ **Remover Contato** — exclui um contato pelo ID.
* 🔍 **Buscar Contato** — pesquisa por nome ou parte do nome.
* 💾 **Persistência automática** — salva e carrega contatos do arquivo `contatos.json`.

---

## 🧰 Tecnologias utilizadas

* **C# (.NET 8 ou superior)**
* **System.Text.Json** → serialização e desserialização dos contatos
* **System.Text.RegularExpressions (Regex)** → validação de telefone
* **Console Application (CLI)** → interface de linha de comando interativa

---

## 🗂️ Estrutura do projeto

```
GerenciadorAgenda/
│
├── Program.cs           → Menu principal e controle de fluxo
├── Contato.cs           → Modelo de dados do contato
├── GerenciadorAgenda.cs → Lógica de CRUD e persistência
├── contatos.json        → Arquivo gerado automaticamente
└── README.md            → Documentação do projeto
```

---

## 🚀 Como executar

1. **Clone o repositório**

   ```bash
   git clone https://github.com/AlexandreLopes02/gerenciador-de-agenda.git
   ```

2. **Acesse o diretório**

   ```bash
   cd GerenciadorAgenda
   ```

3. **Execute o projeto**

   ```bash
   dotnet run
   ```

---

## 💡 Exemplo de uso

```
========================================
        GERENCIADOR DE AGENDA
========================================
1. Adicionar Contato
2. Listar Contatos
3. Editar Contato
4. Remover Contato
5. Buscar Contato
6. Sair
----------------------------------------
Escolha uma opção: 1
Digite o nome: João Silva
Digite o telefone: 11999999999
Contato adicionado com sucesso!
```

---

## 🧱 Boas práticas aplicadas

* Separação entre **lógica de negócio**, **persistência** e **interface**
* **Validação de entrada** com expressões regulares
* **Persistência de dados** em formato JSON
* Interface limpa com `Console.Clear()` e mensagens padronizadas
* Código **organizado, reutilizável e de fácil manutenção**

---

## 👨‍💻 Autor

**Alexandre Lopes de Lima**
Estudante de **Análise e Desenvolvimento de Sistemas**
**São Paulo – SP**
[GitHub](https://github.com/AlexandreLopes02) • [LinkedIn](www.linkedin.com/in/lopesalexandre02)
