namespace API_Exemplo
{
    public class AlunoFundamental : Aluno
    {
        public AlunoFundamental(string nome , int idade ,  int ano , string turno)
        {
            this.nome = nome;
            this.idade = idade;
            this.ano = ano;
            this.turno = turno;
            //matricula++;
        }
    }
}
