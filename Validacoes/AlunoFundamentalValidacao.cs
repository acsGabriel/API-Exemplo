using FluentValidation;

namespace API_Exemplo.Validacoes
{
    public class AlunoFundamentalValidacao : AbstractValidator<AlunoFundamental>
    {
        public AlunoFundamentalValidacao() 
        {
            RuleFor(a => a.nome).Must(ValidarNome).WithMessage("Inserir nome completo!");
            RuleFor(a => a.idade).Must(ValidarIdade).WithMessage("Inserir uma idade válida para aluno fundamental!");
            RuleFor(a => a.ano).Must(ValidarAno).WithMessage("Inserir uma série valida para aluno fundamental!");
            RuleFor(a => a.turno).Must(ValidarTurno).WithMessage("Inserir um turno válido!");
        }

        public AlunoFundamentalValidacao(List<AlunoFundamental> alunosFundamental)
        {
            RuleFor(a => a).Must(a => validaPut(alunosFundamental, a)).WithMessage("Aluno inválido!");
            RuleFor(a => a.nome).Must(ValidarNome).WithMessage("Inserir nome completo!");
            RuleFor(a => a.idade).Must(ValidarIdade).WithMessage("Inserir uma idade válida para aluno fundamental!");
            RuleFor(a => a.ano).Must(ValidarAno).WithMessage("Inserir uma série valida para aluno fundamental!");
            RuleFor(a => a.turno).Must(ValidarTurno).WithMessage("Inserir um turno válido!");
        }

        public AlunoFundamentalValidacao(List<AlunoFundamental> alunosFundamental, string atributo)
        {
            RuleFor(a => a).Must(a => validaPatch(alunosFundamental, a, atributo)).WithMessage("Aluno inválido!");
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
            if (idade == 0 || idade > 15 || idade < 12)
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
            if (ano == 0 || ano > 9 || ano < 6)
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

        bool validaPut(List<AlunoFundamental> alunosFundamental, Aluno aluno)
        {
            if (aluno == null || alunosFundamental.Find(a => a.nome == aluno.nome) == null)
            {
                return false;
            }
            return true;
        }

        bool validaPatch(List<AlunoFundamental> alunosFundamental, AlunoFundamental aluno, string atributo)
        {
            if (aluno == null || alunosFundamental.Find(a => a.nome == aluno.nome) == null)
            {
                return false;
            }
            else if (atributo != "ano" && atributo != "turno" && atributo != "idade")
            {
                return false;
            }
            return true;
        }
    }
}
