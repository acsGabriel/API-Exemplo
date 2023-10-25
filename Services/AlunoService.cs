using Swashbuckle.AspNetCore.SwaggerGen;

namespace API_Exemplo.Services
{
    //FUNCIONALIDADES DO PROGRAMA QUE ENVOLVE OS ALUNOS
    public class AlunoService
    {
        public AlunoService() { }

        //LINQ IMPLEMENTADO - Logica por tras da atualização dos dados de um Aluno
        public void PutAluno(Aluno aluno)
        {
            //Query que seleciona o aluno que eu desejo atualizar e altera seus atributos
            var alunoAtual = BancoDeDados.alunos.Find(a => a.nome == aluno.nome);

            if(alunoAtual is null )
            {
                return;
            }

            alunoAtual.periodo = aluno.periodo;
            alunoAtual.curso = aluno.curso;
        }

        //LINQ IMPLEMENTADO - Logica por tras da remoção de um Aluno (Corrigido)
        public void DeleteAluno(string name)
        {
            for (int i = 0; i < BancoDeDados.alunos.Count; i++) 
            {
                if (BancoDeDados.alunos[i].nome == name) 
                {
                    BancoDeDados.alunos.Remove(BancoDeDados.alunos[i]);
                }
            }
        }

        //LINQ IMPLEMENTADO - Logica por tras da atualização parcial de um Aluno
        public void PatchAluno(Aluno aluno , string atributo)
        {
            var alunoPatch = BancoDeDados.alunos.Find(a => aluno.nome == a.nome);
            if (atributo == "Curso" && alunoPatch != null)
            {
                alunoPatch.curso = aluno.curso;
            }
            else if(atributo == "Periodo" && alunoPatch != null)
            {
                alunoPatch.periodo = aluno.periodo;
            }
        }

        //LINQ IMPLEMENTADO - Ordenação dos Alunos por meio do nome
        public List<Aluno> SortByName() 
        {
            //Query que usa o comando OrderBy para ordenar a lista de acordo com o nome
            return BancoDeDados.alunos.OrderBy(aluno => aluno.nome).ToList(); 
        }

        //LINQ IMPLEMENTADO - Logica por tras de selecionar todos os Alunos de um mesmo curso
        public List<Aluno> GetSelectedAlunos(string curso)
        {
            //Retorna a lista filtrada com os Alunos que cursam o curso passado no parâmetro
            //ToLower() utilizado para comparar as strings tratando possiveis erros de digitação
            return BancoDeDados.alunos.Where(aluno => aluno.curso.ToLower() == curso.ToLower()).OrderBy(a => a.nome).ToList();
        }

        //LINQ IMPLEMENTADO - Lógica por tras de mostrar todos os alunos prestes a formar de dois cursos diferentes
        public List<Aluno> Graduate(string curso1 , string curso2)
        {
            //Query para selecionar os alunos formandos do curso 1
            List<Aluno> grad1 = BancoDeDados.alunos.Where(aluno => aluno.curso == curso1 && aluno.periodo > 7).ToList();
            //Query para selecionar os formandos do curso 2, concatenar com os formandos do curso 1 e ordenar por nome.
            return BancoDeDados.alunos.Where(aluno => aluno.curso == curso2 && aluno.periodo > 7).Concat(grad1).OrderBy(aluno => aluno.nome).ToList();
        }

        public List<string> Names()
        {
            return BancoDeDados.alunos.Select(a => a.nome).OrderBy(a => a).ToList();
        }

        public Aluno FirstStudent(string course)
        {
            var aluno = BancoDeDados.alunos.FirstOrDefault(a => a.curso == course);
            if(aluno == null)
            {
                return new Aluno();
            }

            return aluno;
        }

    }
}
