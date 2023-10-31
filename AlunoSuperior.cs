namespace API_Exemplo
{
    public class AlunoSuperior : Aluno
    {
        public string curso {  get; set; }
        public string turno { get; set; }
        public int periodo {  get; set; }

        public AlunoSuperior(string nome , int idade , string curso ,  string turno , int periodo)
        {
            this.nome = nome;
            this.idade = idade;
            this.curso = curso;
            this.turno = turno;
            this.periodo = periodo;
            //matricula++;
        }
    }
}
