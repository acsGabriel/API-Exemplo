namespace API_Exemplo
{
    //CLASSE DOS ALUNOS
    public class Aluno
    {
        //ATRIBUTOS
        public string nome { get; set; }
        public string curso { get; set; }
        public int periodo { get; set; }
        public static int matricula = 0;

        //CONSTRUTOR
        public Aluno(string nome , string curso , int periodo)
        {
            this.nome = nome;
            this.curso = curso;
            this.periodo = periodo;
            matricula = matricula + 1;

            matricula++;
        }

    }
}
