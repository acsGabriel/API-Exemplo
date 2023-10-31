namespace API_Exemplo
{
    public class AlunoInfantil : Aluno
    {
        public int ano {  get; set; }
        public string turno { get; set; }

        public AlunoInfantil(string nome, int idade , int ano, string turno)
        {
            this.nome = nome;
            this.idade = idade;
            this.ano = ano;
            this.turno = turno;
            //matricula++;
        }
    }
}
