using API_Exemplo.Exceções;
using API_Exemplo.Interfaces.Services;
using API_Exemplo.Validacoes;
using FluentValidation;

namespace API_Exemplo.Services
{
    public class AlunoFundamentalService<T> : IAlunoFundamentalService<T>
        where T : AlunoFundamental
    {
        //public IValidator<AlunoFundamental> _alunoFundamentalValidator;
        public AlunoFundamentalService() 
        {
            //_alunoFundamentalValidator = validator;
        }

        public List<T> Get() 
        {
            return BancoDeDados.alunosFundamental.OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public bool Post(T novoAluno) 
        {
            var validacao = new AlunoFundamentalValidacao();
            var erro = new TratamentoExcessao();

            var validation = validacao.Validate(novoAluno);

            if (validation.IsValid)
            {
                BancoDeDados.alunosFundamental.Add(novoAluno);
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }

            return true;
        }

        public void Delete(string nome)
        {
            BancoDeDados.alunosFundamental.Remove(BancoDeDados.alunosFundamental.FirstOrDefault(a => a.nome == nome));
        }

        public void Put(T alunoAtualizado) 
        {
            TratamentoExcessao erro = new TratamentoExcessao();

            var validation = new AlunoFundamentalValidacao(BancoDeDados.alunosFundamental).Validate(alunoAtualizado);

            if (validation.IsValid)
            {
                AlunoFundamental aluno = alunoAtualizado;

                var put = BancoDeDados.alunosFundamental.Find(a => a.nome == aluno.nome);

                put.ano = aluno.ano;
                put.turno = aluno.turno;
                put.idade = aluno.idade;
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }
        }

        public void Patch(T tipoAluno, string atributo)
        {
            TratamentoExcessao erro = new TratamentoExcessao();

            var validation = new AlunoFundamentalValidacao(BancoDeDados.alunosFundamental, atributo).Validate(tipoAluno);

            if (validation.IsValid)
            {
                var patch = BancoDeDados.alunosFundamental.FirstOrDefault(a => a.nome == tipoAluno.nome);

                switch (atributo)
                {
                    case "ano":
                        patch.ano = tipoAluno.ano;
                        break;
                    case "turno":
                        patch.turno = tipoAluno.turno;
                        break;
                    case "idade":
                        patch.idade = tipoAluno.idade;
                        break;
                }
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
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
