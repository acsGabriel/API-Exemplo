using API_Exemplo.Interfaces.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API_Exemplo.Services
{
    //FUNCIONALIDADES DO PROGRAMA QUE ENVOLVE OS ALUNOS
    public class AlunoInfantilService<T> : IAlunoInfantilService<T>
        where T : AlunoInfantil
    {
        public AlunoInfantilService() { }

        public List<T> Get()
        {
            return BancoDeDados.alunosInfantil.OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public void Post(T aluno)
        {
            BancoDeDados.alunosInfantil.Add(aluno);
        }

        public void Delete(string name)
        {
            BancoDeDados.alunosInfantil.Remove(BancoDeDados.alunosInfantil.FirstOrDefault(a => a.nome == name));
        }

        public void Put(T objeto)
        {
            if (objeto == null)
            {
                throw new Exception("O tipo não pode ser nulo!");
            }

            AlunoInfantil aluno = objeto;

            var put = BancoDeDados.alunosInfantil.Find(a => a.nome == aluno.nome);

            if (put == null)
            {
                throw new Exception("Não existe aluno com esse nome!");
            }

            put.ano = aluno.ano;
            put.turno = aluno.turno;
            put.idade = aluno.idade;
        }

        public void Patch(T tipoAluno, string atributo)
        {
            var patch = BancoDeDados.alunosInfantil.FirstOrDefault(a => a.nome == tipoAluno.nome);
            if (atributo == "ano")
            {
                patch.ano = tipoAluno.ano;
            }
            else if (atributo == "turno")
            {
                patch.turno = tipoAluno.turno;
            }
            else if (atributo == "idade")
            {
                patch.idade = tipoAluno.idade;
            }
        }

        public List<T> GetSelectedAlunos(int ano)
        {
            return BancoDeDados.alunosInfantil.Where(a => ano.Equals(a.ano)).OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public List<string> Names()
        {
            return BancoDeDados.alunosInfantil.Select(a => a.nome).OrderBy(a => a).ToList();
        }

        public T FirstStudentByAno(int ano)
        {
            var alunoEncontrado = BancoDeDados.alunosInfantil.FirstOrDefault(a => ano.Equals(a.ano));

            if (alunoEncontrado is T alunoConvertido)
            {
                return alunoConvertido;
            }
            else
            {
                throw new Exception("Não existem alunos nesse ano!");
            }
        }
    }
}