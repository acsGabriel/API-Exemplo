using Swashbuckle.AspNetCore.SwaggerGen;

namespace API_Exemplo.Services
{
    //FUNCIONALIDADES DO PROGRAMA QUE ENVOLVE OS ALUNOS
    public class AlunoService
    {
        public AlunoService() { }

        //LINQ IMPLEMENTADO - Logica por tras da atualização dos dados de um Aluno
        public void putAluno(Aluno aluno)
        {
            //Query que seleciona o aluno que eu desejo atualizar e altera seus atributos
            BancoDeDados.alunos = BancoDeDados.alunos.Select(a=> { if(a.nome == aluno.nome) { a.curso = aluno.curso; a.periodo = aluno.periodo; } return a; }).ToList();

            //Usar find 
        }

        //LINQ IMPLEMENTADO - Logica por tras da remoção de um Aluno 
        public void deleteAluno(string name)
        {
            //Query que cria uma nova Lista com todos os elementos menos aquele a ser removido
            BancoDeDados.alunos = BancoDeDados.alunos.Where(aluno => aluno.nome != name).ToList();
            
            //Delete nao precisa de LINQ
        }

        //LINQ IMPLEMENTADO - Logica por tras da atualização parcial de um Aluno
        public void patchAluno(Aluno aluno)
        {
            //Query seleciona o aluno a ser atualizado, encontra o atributo que esta diferente e altera no Aluno original
            BancoDeDados.alunos = BancoDeDados.alunos.Select(a => { if(a.nome == aluno.nome) { if(a.curso != aluno.curso) { a.curso = aluno.curso; return a; } else { a.periodo = aluno.periodo; return a; }} return a; }).ToList();

            //Usar find
        }

        //LINQ IMPLEMENTADO - Ordenação dos Alunos por meio do nome
        public List<Aluno> sortByName() 
        {
            //Query que usa o comando OrderBy para ordenar a lista de acordo com o nome
            return BancoDeDados.alunos.OrderBy(aluno => aluno.nome).ToList(); 
        }

        //LINQ IMPLEMENTADO - Logica por tras de selecionar todos os Alunos de um mesmo curso
        public List<Aluno> GetSelectedAlunos(string curso)
        {
            //Retorna a lista filtrada com os Alunos que cursam o curso passado no parâmetro
            //ToLower() utilizado para comparar as strings tratando possiveis erros de digitação
            return BancoDeDados.alunos.Where(aluno => aluno.curso.ToLower() == curso.ToLower()).ToList();
        }

        //LINQ IMPLEMENTADO - Lógica por tras de mostrar todos os alunos prestes a formar de dois cursos diferentes
        public List<Aluno> graduate(string curso1 , string curso2)
        {
            //Query para selecionar os alunos formandos do curso 1
            List<Aluno> grad1 = BancoDeDados.alunos.Where(aluno => aluno.curso == curso1).Where(aluno => aluno.periodo > 7).ToList();
            //Query para selecionar os formandos do curso 2, concatenar com os formandos do curso 1 e ordenar por nome.
            return BancoDeDados.alunos.Where(aluno => aluno.curso == curso2).Where(aluno => aluno.periodo > 9).Concat(grad1).OrderBy(aluno => aluno.nome).ToList();

            //Where aceita mais de uma condição
        }

        //Criar método pro first or default e método pro default


        
    }
}
