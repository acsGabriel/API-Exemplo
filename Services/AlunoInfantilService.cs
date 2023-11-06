using API_Exemplo.Exceções;
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
        public IValidator<AlunoInfantil> _alunoInfantilValidator;
        public AlunoInfantilService(IValidator<AlunoInfantil> alunoInfantilValidator) 
        {
            _alunoInfantilValidator = alunoInfantilValidator;
        }

        public List<T> Get()
        {
            return BancoDeDados.alunosInfantil.OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public bool Post(T aluno) 
        {
            TratamentoExcessao erro = new TratamentoExcessao();
            var validation = _alunoInfantilValidator.Validate(aluno);

            if(validation.IsValid) 
            {
                BancoDeDados.alunosInfantil.Add(aluno);
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }
            return true;
        }

        public void Delete(string name)
        {
            BancoDeDados.alunosInfantil.Remove(BancoDeDados.alunosInfantil.FirstOrDefault(a => a.nome == name));
        }

        public void Put(T objeto)
        {
            TratamentoExcessao erro = new TratamentoExcessao();

            var validation = new AlunoInfantilValidacao(BancoDeDados.alunosInfantil).Validate(objeto);

            if (validation.IsValid)
            {
                AlunoInfantil aluno = objeto;

                var put = BancoDeDados.alunosInfantil.Find(a => a.nome == aluno.nome);

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

            var validation = new AlunoInfantilValidacao(BancoDeDados.alunosInfantil , atributo).Validate(tipoAluno);
            if (validation.IsValid)
            {
                var patch = BancoDeDados.alunosInfantil.FirstOrDefault(a => a.nome == tipoAluno.nome);

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