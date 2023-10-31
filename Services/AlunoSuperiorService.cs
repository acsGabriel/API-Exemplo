using API_Exemplo.Interfaces.Services;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace API_Exemplo.Services
{
    //FUNCIONALIDADES DO PROGRAMA QUE ENVOLVE OS ALUNOS
    public class AlunoSuperiorService : IAlunoSuperiorService
    {
        public AlunoSuperiorService() { }


        public List<AlunoSuperior> Get()
        {
            return BancoDeDados.alunosSuperior.OrderBy(a => a.nome).ToList();
        }

        public void Post(AlunoSuperior aluno) 
        {
            BancoDeDados.alunosSuperior.Add(aluno);
        }

        public void Delete(string name) 
        {
            BancoDeDados.alunosSuperior.Remove(BancoDeDados.alunosSuperior.FirstOrDefault(a => a.nome == name));
        }

        public void Put(AlunoSuperior aluno) 
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

        public void Patch(AlunoSuperior aluno, string atributo) 
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
            else if(atributo == "curso")
            {
                patch.curso = aluno.curso;
            }
        }

        public List<AlunoSuperior> GetSelectedAlunos(string curso) 
        {
            return BancoDeDados.alunosSuperior.Where(a => curso == a.curso).OrderBy(a => a.nome).ToList();
        }

        public List<AlunoSuperior> Graduate(string curso1, string curso2) 
        {
            List<AlunoSuperior> grad1 = BancoDeDados.alunosSuperior.Where(aluno => aluno.curso == curso1 && aluno.ano > 3).ToList();
            return BancoDeDados.alunosSuperior.Where(aluno => aluno.curso == curso2 && aluno.ano > 3).Concat(grad1).OrderBy(aluno => aluno.nome).ToList();
        }
        public List<string> Names() 
        {
            return BancoDeDados.alunosSuperior.Select(a => a.nome).OrderBy(a => a).ToList();
        }
        public AlunoSuperior FirstStudent(string curso) 
        {
            return BancoDeDados.alunosSuperior.FirstOrDefault(a => curso == a.curso);
        }
    }
}
