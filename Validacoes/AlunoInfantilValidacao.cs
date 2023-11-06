using FluentValidation;
using System.Security.Cryptography;

namespace API_Exemplo.Validacoes
{
    public class AlunoInfantilValidacao : AbstractValidator<AlunoInfantil>
    {
        public AlunoInfantilValidacao() 
        {
            RuleFor(a => a.nome).Must(ValidarNome).WithMessage("Inserir nome completo!");
            RuleFor(a => a.idade).Must(ValidarIdade).WithMessage("Inserir uma idade válida para aluno infantil!"); 
            RuleFor(a => a.ano).Must(ValidarAno).WithMessage("Inserir uma série valida para aluno infantil!");
            RuleFor(a => a.turno).Must(ValidarTurno).WithMessage("Inserir um turno válido!");
        }

        public AlunoInfantilValidacao(List<AlunoInfantil> alunosInfantil)
        {
            RuleFor(a => a).Must(a => validaPut(alunosInfantil , a)).WithMessage("Aluno inválido!");
            RuleFor(a => a.nome).Must(ValidarNome).WithMessage("Inserir nome completo!");
            RuleFor(a => a.idade).Must(ValidarIdade).WithMessage("Inserir uma idade válida para aluno infantil!");
            RuleFor(a => a.ano).Must(ValidarAno).WithMessage("Inserir uma série valida para aluno infantil!");
            RuleFor(a => a.turno).Must(ValidarTurno).WithMessage("Inserir um turno válido!");
        }

        public AlunoInfantilValidacao(List<AlunoInfantil> alunosInfantil , string atributo)
        {
            RuleFor(a => a).Must(a => validaPatch(alunosInfantil, a, atributo)).WithMessage("Aluno inválido!");
        }

        bool ValidarNome(string nome)
        {
            char[] name = nome.ToArray();
            int cont = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                {
                    cont++;
                }
            }

            if (cont >= 1 && nome != null && nome != "string")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool ValidarIdade(int idade) 
        {
            if(idade == 0 || idade > 11 || idade < 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        bool ValidarAno(int ano)
        {
            if (ano == 0 || ano > 5 || ano < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        bool ValidarTurno(string turno)
        {
            if (turno == "MANHA" || turno == "TARDE")
            {
                return true;
            }
            return false;
        }

        bool validaPut(List <AlunoInfantil> alunosInfantil , Aluno aluno)
        {
            if(aluno == null || alunosInfantil.Find(a => a.nome == aluno.nome) == null)
            {
                return false;
            }
            return true;
        }

        bool validaPatch(List <AlunoInfantil> alunosInfantil , AlunoInfantil aluno , string atributo)
        {
            if (aluno == null || alunosInfantil.Find(a => a.nome == aluno.nome) == null)
            {
                return false;
            }
            else if(atributo != "ano" && atributo != "turno" && atributo != "idade")
            {
                return false;
            }
            return true;
        }

    }
}
