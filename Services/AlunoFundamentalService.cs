using API_Exemplo.Interfaces.Services;


namespace API_Exemplo.Services
{
    public class AlunoFundamentalService : IAlunoFundamentalService
    {
        public AlunoFundamentalService() { }

        public List<AlunoFundamental> Get() 
        {
            return BancoDeDados.alunosFundamental.OrderBy(a => a.nome).ToList();
        }

        public void Post(AlunoFundamental aluno) 
        {
            BancoDeDados.alunosFundamental.Add(aluno);
        }

        public void Delete(string name)
        {
            BancoDeDados.alunosFundamental.Remove(BancoDeDados.alunosFundamental.FirstOrDefault(a => a.nome == name));
        }

        public void Put(AlunoFundamental aluno) 
        {
            if(aluno == null)
            {
                throw new Exception("Não existe aluno com esse nome!");
            }

            var put = BancoDeDados.alunosFundamental.Find(a => a.nome == aluno.nome);

            put.turno = aluno.turno;
            put.ano = aluno.ano;
            put.idade = aluno.idade;
        }

        public void Patch(AlunoFundamental aluno, string atributo)
        {
            var patch = BancoDeDados.alunosFundamental.FirstOrDefault(a => a.nome == aluno.nome);
            if(patch == null)
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

        public List<AlunoFundamental> GetSelectedAlunos(int ano)
        {
            return BancoDeDados.alunosFundamental.Where(a => ano == a.ano).OrderBy(a => a.nome).ToList();
        }

        public List<string> Names()
        {
            return BancoDeDados.alunosFundamental.Select(a => a.nome).OrderBy(a => a).ToList();
        }

        public AlunoFundamental FirstStudent(int ano)
        {
            return BancoDeDados.alunosFundamental.FirstOrDefault(a => ano == a.ano);
        }

    }
}
