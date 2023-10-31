using API_Exemplo.Interfaces.Services;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace API_Exemplo.Services
{
    //FUNCIONALIDADES DO PROGRAMA QUE ENVOLVE OS ALUNOS
    public class AlunoInfantilService : IAlunoInfantilService
    {
        public AlunoInfantilService() { }

        public List<AlunoInfantil> Get()
        {
            return BancoDeDados.alunosInfantil.OrderBy(a => a.nome).ToList();
        }

        public void Post(AlunoInfantil aluno)
        {
            BancoDeDados.alunosInfantil.Add(aluno);
        }

        public void Delete(string name)
        {
            BancoDeDados.alunosInfantil.Remove(BancoDeDados.alunosInfantil.FirstOrDefault(a => a.nome == name));
        }

        public void Put(AlunoInfantil aluno)
        {
            if (aluno == null)
            {
                throw new Exception("Não existe aluno com esse nome!");
            }

            var put = BancoDeDados.alunosInfantil.Find(a => a.nome == aluno.nome);

            put.turno = aluno.turno;
            put.ano = aluno.ano;
            put.idade = aluno.idade;
        }

        public void Patch(AlunoInfantil aluno, string atributo)
        {
            var patch = BancoDeDados.alunosInfantil.FirstOrDefault(a => a.nome == aluno.nome);
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
        }

        public List<AlunoInfantil> GetSelectedAlunos(int ano)
        {
            return BancoDeDados.alunosInfantil.Where(a => ano == a.ano).OrderBy(a => a.nome).ToList();
        }

        public List<string> Names()
        {
            return BancoDeDados.alunosInfantil.Select(a => a.nome).OrderBy(a => a).ToList();
        }

        public AlunoInfantil FirstStudent(int ano)
        {
            return BancoDeDados.alunosInfantil.FirstOrDefault(a => ano == a.ano);
        }
    }
}