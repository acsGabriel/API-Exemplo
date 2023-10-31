using API_Exemplo.Interfaces.Services;


namespace API_Exemplo.Services
{
    public class AlunoFundamentalService<T> : IAlunoFundamentalService<T>
        where T : AlunoFundamental
    {
        public AlunoFundamentalService() { }

        public List<T> Get() 
        {
            return BancoDeDados.alunosFundamental.OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public void Post(T tipoAluno) 
        {
            BancoDeDados.alunosFundamental.Add(tipoAluno);
        }

        public void Delete(string name)
        {
            BancoDeDados.alunosFundamental.Remove(BancoDeDados.alunosFundamental.FirstOrDefault(a => a.nome == name));
        }

        public void Put(T objeto) 
        {
            if(objeto == null)
            {
                throw new Exception("O tipo não pode ser nulo!");
            }

            AlunoFundamental aluno = objeto;

            var put = BancoDeDados.alunosFundamental.Find(a => a.nome == aluno.nome);

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
            var patch = BancoDeDados.alunosFundamental.FirstOrDefault(a => a.nome == tipoAluno.nome);
            if (atributo == "ano")
            {
                patch.ano = tipoAluno.ano;
            }
            else if (atributo == "turno")
            {
                patch.turno = tipoAluno.turno;
            }
        }

        public List<T> GetSelectedAlunos(int ano)
        {
            return BancoDeDados.alunosFundamental.Where(a => ano.Equals(a.ano)).OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public List<string> Names()
        {
            return BancoDeDados.alunosFundamental.Select(a => a.nome).OrderBy(a => a).ToList();
        }

        public T FirstStudentByAno(int ano)
        {
            var alunoEncontrado = BancoDeDados.alunosFundamental.FirstOrDefault(a => ano.Equals(a.ano));

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
