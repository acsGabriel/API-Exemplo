namespace API_Exemplo
{
    public class Aluno
    {
        public static List<Aluno> alunos = new List<Aluno>();
        public static List<string> mostrar = new List<string>(); 

        public string nome { get; set; }
        public string curso { get; set; }
        public int periodo { get; set; }
        public static int matricula = 0;

        //Constructor
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
