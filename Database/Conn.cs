using Npgsql;
public static class Conn {
    public static string GetConnString(){
        string connString = "Host=localhost:5432;Username=postgres;Password=1234;Database=filmesApi";
        return connString;
    }
}