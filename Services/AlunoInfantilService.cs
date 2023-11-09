using API_Exemplo.Exceções;
using API_Exemplo.Interfaces.Bancos;
using API_Exemplo.Interfaces.Services;
using API_Exemplo.Validacoes;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace API_Exemplo.Services
{
    //FUNCIONALIDADES DO PROGRAMA QUE ENVOLVE OS ALUNOS
    public class AlunoInfantilService<T> : IAlunoInfantilService<T>
        where T : AlunoInfantil
    {
        //INJEÇÃO DE DEPENDÊNCIAS
        public IBancoDeDados _bancoDeDados;
        public AlunoInfantilService(IBancoDeDados bancodedados) 
        {
            _bancoDeDados = bancodedados;
        }

        //METODOS 
        public List<T> Get() //Mostra todos os alunos
        {
            return _bancoDeDados.GetAlunoInfantil().OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public bool Post(T novoAluno) //Adiciona novo aluno
        {
            TratamentoExcessao erro = new TratamentoExcessao(); //Instância para tratamento de excessões
            var validation = new AlunoInfantilValidacao().Validate(novoAluno); //Validação do objeto

            if(validation.IsValid) 
            {
                _bancoDeDados.AddAlunoInfantil(novoAluno);
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
            _bancoDeDados.DeleteAlunoInfantil(_bancoDeDados.GetAlunoInfantil().FirstOrDefault(a => a.nome == nome));
        }

        public bool Put(T alunoAtualizado) //Atualiza todos os dados de um aluno
        {
            TratamentoExcessao erro = new TratamentoExcessao();
            var validation = new AlunoInfantilValidacao(_bancoDeDados.GetAlunoInfantil()).Validate(alunoAtualizado);

            if (validation.IsValid)
            {
                _bancoDeDados.PutAlunoInfantil((AlunoInfantil)alunoAtualizado);
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
            var validation = new AlunoInfantilValidacao(_bancoDeDados.GetAlunoInfantil() , atributo).Validate(alunoAlterado);

            if (validation.IsValid)
            {
                _bancoDeDados.PatchAlunoInfantil((AlunoInfantil)alunoAlterado , atributo);
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }
            return true;
        }

        public List<T> GetSelectedAlunos(int ano) //Mostra os alunos do mesmo ano
        {
            return _bancoDeDados.GetAlunoInfantil().Where(a => ano.Equals(a.ano)).OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public List<string> Names() //Mostra o nome de todos os alunos
        {
            return _bancoDeDados.GetAlunoInfantil().Select(a => a.nome).OrderBy(a => a).ToList();
        }

        public T FirstStudentByAno(int ano) //Mostra o primeiro aluno do ano
        {
            var alunoEncontrado = _bancoDeDados.GetAlunoInfantil().FirstOrDefault(a => ano.Equals(a.ano));

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