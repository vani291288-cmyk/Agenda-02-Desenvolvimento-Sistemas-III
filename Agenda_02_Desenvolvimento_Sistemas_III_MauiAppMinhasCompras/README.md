# Agenda 02 – Desenvolvimento de Sistemas III
## Projeto: Minhas Compras – Persistência de Dados com SQLite

Projeto em .NET MAUI com SQLite-net-pcl.

### Funcionalidades demonstradas
- Criação automática da tabela `Produto`.
- Inserção de produtos.
- Leitura/listagem dos produtos cadastrados.
- Busca por descrição.
- Métodos de atualização e exclusão no `SQLiteDatabaseHelper`.

### Como executar
1. Abra a pasta no Visual Studio 2022 com a carga de trabalho **Desenvolvimento de aplicativos móveis com .NET** instalada.
2. Restaure os pacotes NuGet.
3. Selecione um dispositivo Android/emulador ou Windows.
4. Execute o projeto.

### Observação sobre a apostila
A apostila apresenta o helper com os métodos CRUD e a busca SQL. Neste projeto foram corrigidos dois pontos para que a implementação funcione de forma consistente:
- `Update` retorna `Task<int>` e usa `UpdateAsync`.
- A busca é feita por `Table<Produto>().Where(...)`, evitando a consulta SQL com a palavra `FROM` ausente no exemplo da apostila.

A atividade deve ser acompanhada de capturas de tela ou vídeo mostrando a criação/edição dos códigos e o funcionamento do aplicativo.
