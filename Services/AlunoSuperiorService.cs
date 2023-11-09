using API_Exemplo.Exceções;
using API_Exemplo.Interfaces.Bancos;
using API_Exemplo.Interfaces.Services;
using API_Exemplo.Validacoes;
using FluentValidation;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;


namespace API_Exemplo.Services
{
    //FUNCIONALIDADES DO PROGRAMA QUE ENVOLVE OS ALUNOS
    public class AlunoSuperiorService<T> : IAlunoSuperiorService<T>
        where T : AlunoSuperior
    {
        //INJEÇÃO DE DEPENDÊNCIAS
        public IBancoDeDados _bancoDeDados;
        public AlunoSuperiorService(IBancoDeDados bancodedados)
        {
            _bancoDeDados = bancodedados;
        }

        //METODOS
        public List<T> Get() //Retorna todos os alunos
        {
            return _bancoDeDados.GetAlunoSuperior().OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public bool Post(T novoAluno) //Adiciona novo aluno
        {
            TratamentoExcessao erro = new TratamentoExcessao();
            var validation = new AlunoSuperiorValidacao().Validate(novoAluno);

            if (validation.IsValid)
            {
                _bancoDeDados.AddAlunoSuperior(novoAluno);
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
            _bancoDeDados.DeleteAlunoSuperior(_bancoDeDados.GetAlunoSuperior().FirstOrDefault(a => a.nome == nome));
        }

        public bool Put(T alunoAtualizado) //Atualiza todos os dados de um aluno
        {
            TratamentoExcessao erro = new TratamentoExcessao();
            var validation = new AlunoSuperiorValidacao(_bancoDeDados.GetAlunoSuperior()).Validate(alunoAtualizado);

            if (validation.IsValid)
            {
                _bancoDeDados.PutAlunoSuperior((AlunoSuperior)alunoAtualizado);
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }
            return true;
        }

        public bool Patch(T alunoAlterado , string atributo) //Altera um atributo do aluno
        {
            TratamentoExcessao erro = new TratamentoExcessao();
            var validation = new AlunoSuperiorValidacao(_bancoDeDados.GetAlunoSuperior() , atributo).Validate(alunoAlterado);
            
            if (validation.IsValid)
            {
                _bancoDeDados.PatchAlunoSuperior((AlunoSuperior)alunoAlterado , atributo);
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }
            return true;
        }

        public List<T> GetSelectedAlunos(string curso) //Mostra todos os alunos do mesmo curso
        {
            return _bancoDeDados.GetAlunoSuperior().Where(a => curso == a.curso).OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public List<string> Names() //Mostra o nome de todos os alunos
        {
            return _bancoDeDados.GetAlunoSuperior().Select(a => a.nome).OrderBy(a => a).ToList();
        }

        public T FirstStudentByCurso(string curso) //Mostra o primeiro aluno do curso
        {
            var alunoEncontrado = _bancoDeDados.GetAlunoSuperior().FirstOrDefault(a => curso.Equals(a.curso));

            if (alunoEncontrado is T alunoConvertido)
            {
                return alunoConvertido;
            }
            else
            {
                throw new Exception("Não existem alunos nesse ano!");
            }
        }

        public List<T> Graduate(string curso1, string curso2) //Mostra os alunos que estao formando entre dois cursos
        {
            List<AlunoSuperior> grad1 = _bancoDeDados.GetAlunoSuperior().Where(aluno => aluno.curso == curso1 && aluno.ano > 3).ToList();
            return _bancoDeDados.GetAlunoSuperior().Where(aluno => aluno.curso == curso2 && aluno.ano > 3).Concat(grad1).OrderBy(aluno => aluno.nome).Cast<T>().ToList();
        }

    }
}
