using Npgsql;
public static class FilmeRepository {
    public static async Task<Filme> Create(Filme filme){

        await using (var conn = new NpgsqlConnection(Conn.GetConnString()))
        {
            await conn.OpenAsync();
            var cmd = new NpgsqlCommand(Query.INSERT_FILMES, conn);
            cmd.Parameters.AddWithValue("nome", filme.nome);
            cmd.Parameters.AddWithValue("lancamento", filme.lancamento);
            cmd.Parameters.AddWithValue("duracao", filme.duracao);
            try{
                await cmd.ExecuteNonQueryAsync();
                await conn.CloseAsync();
            }catch(PostgresException e){    
                Console.WriteLine(e);
                await conn.CloseAsync();
                return new Filme("", DateTime.Now, 0);
            }
        }
        return filme;
    }
}