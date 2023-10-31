using API_Exemplo.Interfaces.Services;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace API_Exemplo.Services
{
    //FUNCIONALIDADES DO PROGRAMA QUE ENVOLVE OS ALUNOS
    public class AlunoSuperiorService<T> : IAlunoSuperiorService<T>
        where T : AlunoSuperior
    {
        public AlunoSuperiorService() { }


        public List<T> Get()
        {
            return BancoDeDados.alunosSuperior.OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public void Post(T aluno) 
        {
            BancoDeDados.alunosSuperior.Add(aluno);
        }

        public void Put(T aluno) 
        {
            if (aluno == null)
            {
                throw new Exception("Não existe aluno com esse nome!");
            }

            var put = BancoDeDados.alunosSuperior.Find(a => a.nome == aluno.nome);

            put.turno = aluno.turno;
            put.ano = aluno.ano;
            put.idade = aluno.idade;
            put.curso = aluno.curso;
        }

        public void Delete(string name) 
        {
            BancoDeDados.alunosSuperior.Remove(BancoDeDados.alunosSuperior.FirstOrDefault(a => a.nome == name));
        }

        public void Patch(T aluno, string atributo) 
        {
            var patch = BancoDeDados.alunosSuperior.FirstOrDefault(a => a.nome == aluno.nome);
            if (patch == null)
            {
                throw new Exception("Não existe aluno com esse nome!");
            }

            else if (atributo == "ano")
            {
                patch.ano = aluno.ano;
            }
            else if (atributo == "turno")
            {
                patch.turno = aluno.turno;
            }
            else if (atributo == "curso")
            {
                patch.curso = aluno.curso;
            }
        }

        public List<T> GetSelectedAlunos(string curso) 
        {
            return BancoDeDados.alunosSuperior.Where(a => curso == a.curso).OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public List<T> Graduate(string curso1, string curso2) 
        {
            List<AlunoSuperior> grad1 = BancoDeDados.alunosSuperior.Where(aluno => aluno.curso == curso1 && aluno.ano > 3).ToList();
            return BancoDeDados.alunosSuperior.Where(aluno => aluno.curso == curso2 && aluno.ano > 3).Concat(grad1).OrderBy(aluno => aluno.nome).Cast<T>().ToList();
        }
        public List<string> Names() 
        {
            return BancoDeDados.alunosSuperior.Select(a => a.nome).OrderBy(a => a).ToList();
        }
        public T FirstStudentByCurso(string curso) 
        {
            var alunoEncontrado = BancoDeDados.alunosSuperior.FirstOrDefault(a => curso.Equals(a.curso));

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
