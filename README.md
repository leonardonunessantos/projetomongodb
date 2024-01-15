# To Do List

## Descrição
Este é um aplicativo de lista de tarefas simples que utiliza c# .NET, LINQ e MongoDB para armazenar as notas. Você pode criar, alterar, deletar e visualizar notas diretamente do terminal.

## Como Baixar e Rodar o Projeto

### Pré-requisitos
MongoDB instalado na máquina.

### Passos
1. Clone o repositório.
2. Navegue até o diretório do projeto.
3. Abra o arquivo `Program.cs` e ajuste a string de conexão MongoDB (`connectionString`) conforme necessário.
4. Execute o projeto.
5. Siga as instruções no terminal para criar, alterar, deletar ou visualizar notas.

Lembre-se de ter o MongoDB em execução antes de rodar o projeto.

---

**Observação:** Lembre de configurar corretamente a string de conexão do MongoDB no arquivo `Program.cs`. Nome do banco de dados e a coleção que você deseja utilizar. 
Exemplo:
string connectionString = "mongodb://localhost:27017";
string databaseName = "ToDoListDatabase";
