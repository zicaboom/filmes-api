public static class Query{
    public static string INSERT_FILME = "SELECT * FROM infos.insert_filme(@nome, @lancamento, @duracao);";
    public static string DELETE_FILME = "SELECT infos.delete_filme(@nome);";

    public static string FIND_FILME = "SELECT * FROM infos.filmes WHERE nome = @nome;";

    public static string FIND_ALL_FILMES = "SELECT * FROM infos.filmes";

}