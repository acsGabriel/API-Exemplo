using API_Exemplo.Exceções;
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
        public IValidator<AlunoSuperior> _alunoSuperiorValidator;
        public AlunoSuperiorService(IValidator<AlunoSuperior> validator)
        {
            _alunoSuperiorValidator = validator;
        }

        public List<T> Get()
        {
            return BancoDeDados.alunosSuperior.OrderBy(a => a.nome).Cast<T>().ToList();
        }

        public bool Post(T aluno)
        {
            TratamentoExcessao erro = new TratamentoExcessao();

            var validation = _alunoSuperiorValidator.Validate(aluno);

            if (validation.IsValid)
            {
                BancoDeDados.alunosSuperior.Add(aluno);
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }
            return true;
        }

        public void Put(T aluno)
        {
            TratamentoExcessao erro = new TratamentoExcessao();

            var validation = new AlunoSuperiorValidacao(BancoDeDados.alunosSuperior).Validate(aluno);

            if (validation.IsValid)
            {
                var put = BancoDeDados.alunosSuperior.Find(a => a.nome == aluno.nome);

                put.turno = aluno.turno;
                put.ano = aluno.ano;
                put.idade = aluno.idade;
                put.curso = aluno.curso;
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
            }
        }

        public void Delete(string name)
        {
            BancoDeDados.alunosSuperior.Remove(BancoDeDados.alunosSuperior.FirstOrDefault(a => a.nome == name));
        }

        public void Patch(T aluno, string atributo)
        {
            TratamentoExcessao erro = new TratamentoExcessao();

            var validation = new AlunoSuperiorValidacao(BancoDeDados.alunosSuperior, atributo).Validate(aluno);
            if (validation.IsValid)
            {
                var patch = BancoDeDados.alunosSuperior.FirstOrDefault(a => a.nome == aluno.nome);
                switch (atributo)
                {
                    case "ano":
                        patch.ano = aluno.ano;
                        break;
                    case "turno":
                        patch.turno = aluno.turno;
                        break;
                    case "idade":
                        patch.idade = aluno.idade;
                        break;
                }
            }
            else
            {
                var erros = validation.Errors.Select(e => e.ErrorMessage);
                erro.MakeErrorString(erros);
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
