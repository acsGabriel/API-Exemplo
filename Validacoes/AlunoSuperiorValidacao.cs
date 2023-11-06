using FluentValidation;

namespace API_Exemplo.Validacoes
{
    public class AlunoSuperiorValidacao : AbstractValidator<AlunoSuperior>
    {
        public AlunoSuperiorValidacao()
        {
            RuleFor(a => a.nome).Must(ValidarNome).WithMessage("Inserir nome completo!");
            RuleFor(a => a.idade).Must(ValidarIdade).WithMessage("Inserir uma idade válida para aluno superior!");
            RuleFor(a => a.ano).Must(ValidarAno).WithMessage("Inserir uma série valida para aluno superior!");
            RuleFor(a => a.turno).Must(ValidarTurno).WithMessage("Inserir um turno válido!");
            RuleFor(a => a.curso).Must(ValidarCurso).WithMessage("Inserir um curso válido!");
        }

        public AlunoSuperiorValidacao(List<AlunoSuperior> alunosSuperior)
        {
            RuleFor(a => a).Must(a => validaPut(alunosSuperior, a)).WithMessage("Aluno inválido!");
            RuleFor(a => a.nome).Must(ValidarNome).WithMessage("Inserir nome completo!");
            RuleFor(a => a.idade).Must(ValidarIdade).WithMessage("Inserir uma idade válida para aluno superior!");
            RuleFor(a => a.ano).Must(ValidarAno).WithMessage("Inserir uma série valida para aluno superior!");
            RuleFor(a => a.turno).Must(ValidarTurno).WithMessage("Inserir um turno válido!");
            RuleFor(a => a.curso).Must(ValidarCurso).WithMessage("Inserir um curso válido!");
        }

        public AlunoSuperiorValidacao(List<AlunoSuperior> alunosSuperior, string atributo)
        {
            RuleFor(a => a).Must(a => validaPatch(alunosSuperior, a, atributo)).WithMessage("Aluno inválido!");
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
            if (idade == 0 || idade < 18)
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
            if (ano == 0 || ano > 4 || ano < 1)
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
            if (turno == "MANHA" || turno == "TARDE" || turno == "NOITE")
            {
                return true;
            }
            return false;
        }

        bool ValidarCurso(string curso)
        {
            if (curso == null || curso == "string")
            {
                return false;
            }
            return true;
        }

        bool validaPut(List<AlunoSuperior> alunosSuperior, Aluno aluno)
        {
            if (aluno == null || alunosSuperior.Find(a => a.nome == aluno.nome) == null)
            {
                return false;
            }
            return true;
        }

        bool validaPatch(List<AlunoSuperior> alunosSuperior, AlunoSuperior aluno, string atributo)
        {
            if (aluno == null || alunosSuperior.Find(a => a.nome == aluno.nome) == null)
            {
                return false;
            }
            else if (atributo != "ano" && atributo != "turno" && atributo != "idade" && atributo != "curso")
            {
                return false;
            }
            return true;
        }

    }
}
