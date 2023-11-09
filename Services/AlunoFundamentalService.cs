using API_Exemplo.Exceções;
using API_Exemplo.Interfaces.Bancos;
using API_Exemplo.Interfaces.Services;
using API_Exemplo.Validacoes;
using FluentValidation;

namespace API_Exemplo.Services
{
    public class AlunoFundamentalService<T> : IAlunoFundamentalService<T>
        where T : AlunoFundamental
    {
        //INJEÇÃO DE DEPENDÊNCIAS
        public IBancoDeDados _bancoDeDados;
        public AlunoFundamentalService(IBancoDeDados bancodedados)
        {
            _bancoDeDados = bancodedados;
        }

        //METODOS
        public List<T> Get() 
        {
            return _bancoDeDados.GetAlunoFundamental().OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public bool Post(T novoAluno) //Adiciona um novo aluno
        {
            var erro = new TratamentoExcessao();
            var validation = new AlunoFundamentalValidacao().Validate(novoAluno);

            if (validation.IsValid)
            {
                _bancoDeDados.AddAlunoFundamental(novoAluno);
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }
            return true;
        }

        public void Delete(string nome) //Remove um aluno
        {
            _bancoDeDados.DeleteAlunoFundamental(_bancoDeDados.GetAlunoFundamental().FirstOrDefault(a => a.nome == nome));
        }

        public bool Put(T alunoAtualizado) //Atualiza todos os dados de um aluno
        {
            TratamentoExcessao erro = new TratamentoExcessao();
            var validation = new AlunoFundamentalValidacao(_bancoDeDados.GetAlunoFundamental()).Validate(alunoAtualizado);

            if (validation.IsValid)
            {
                _bancoDeDados.PutAlunoFundamental((AlunoFundamental)alunoAtualizado);
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }
            return true;
        }

        public bool Patch(T alunoAlterado, string atributo) //Altera um ou mais dados do aluno
        {
            TratamentoExcessao erro = new TratamentoExcessao();
            var validation = new AlunoFundamentalValidacao(_bancoDeDados.GetAlunoFundamental() , atributo).Validate(alunoAlterado);

            if (validation.IsValid)
            {
                _bancoDeDados.PatchAlunoFundamental((AlunoFundamental)alunoAlterado , atributo);
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }
            return true;
        }

        public List<T> GetSelectedAlunos(int ano) //Mostra todos os alunos do mesmo ano
        {
            return _bancoDeDados.GetAlunoFundamental().Where(a => ano.Equals(a.ano)).OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public List<string> Names() //Mostra o nome de todos os alunos
        {
            return _bancoDeDados.GetAlunoFundamental().Select(a => a.nome).OrderBy(a => a).ToList();
        }

        public T FirstStudentByAno(int ano) //Mostra o primeiro aluno do ano
        {
            var alunoEncontrado = _bancoDeDados.GetAlunoFundamental().FirstOrDefault(a => ano.Equals(a.ano));

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
