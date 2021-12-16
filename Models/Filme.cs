public class Filme{
    public string nome{get; set;}
    public DateTime lancamento{get; set;}
    public int duracao{get; set;}

    public Filme(string nome, DateTime lancamento, int duracao){
        this.nome = nome;
        this.lancamento = lancamento;
        this.duracao = duracao;
    }
}
