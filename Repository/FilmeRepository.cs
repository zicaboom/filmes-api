using Npgsql;
public static class FilmeRepository {
    public static async Task<Filme> Create(Filme filme){

        await using (var conn = new NpgsqlConnection(Conn.GetConnString()))
        await using (var cmd = new NpgsqlCommand(Query.INSERT_FILME, conn))
        {
            await conn.OpenAsync();
            cmd.Parameters.AddWithValue("nome", filme.nome);
            cmd.Parameters.AddWithValue("lancamento", filme.lancamento);
            cmd.Parameters.AddWithValue("duracao", filme.duracao);
            Filme returns = new Filme("", DateTime.Now, 0);
            try{
                var reader = await cmd.ExecuteReaderAsync();                
                while (await reader.ReadAsync()){
                    returns.nome = reader.GetString(0);
                    returns.lancamento = reader.GetDateTime(1);
                    returns.duracao = reader.GetInt32(2);
                }
                return returns;
            }catch(PostgresException e){    
                Console.WriteLine(e);
                await conn.CloseAsync();
                return returns;
            }
        }
    }

    public static async Task<string> Delete(string nome){

        await using (var conn = new NpgsqlConnection(Conn.GetConnString()))
        await using (var cmd = new NpgsqlCommand(Query.DELETE_FILME, conn))
        {
            await conn.OpenAsync();
            cmd.Parameters.AddWithValue("nome", nome);
            string returns = "";
            try{
                var reader = await cmd.ExecuteReaderAsync();                
                while (await reader.ReadAsync()){
                    returns = reader.GetString(0);
                }
                return returns;
            }catch(PostgresException e){    
                Console.WriteLine(e);
                await conn.CloseAsync();
                return returns;
            }
        }
    }

    public static async Task<List<Filme>> FindAll(){

        await using (var conn = new NpgsqlConnection(Conn.GetConnString()))
        await using (var cmd = new NpgsqlCommand(Query.FIND_ALL_FILMES, conn))
        {
            await conn.OpenAsync();
            List<Filme> returns = new List<Filme>();
            try{
                var reader = await cmd.ExecuteReaderAsync();                
                while (await reader.ReadAsync()){
                    Filme filme = new Filme(
                        reader.GetString(0),
                        reader.GetDateTime(1),
                        reader.GetInt32(2)
                    );
                    returns.Add(filme);
                }
                return returns;
            }catch(PostgresException e){    
                Console.WriteLine(e);
                await conn.CloseAsync();
                return returns;
            }
        }
    }
}