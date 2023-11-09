using API_Exemplo.Interfaces.Bancos;

namespace API_Exemplo
{
    //CLASSE SIMULAÇÃO DE UM BANCO DE DADOS
    public class BancoDeDados : IBancoDeDados
    {
        private static List<AlunoSuperior> alunosSuperior = new List<AlunoSuperior>();
        private static List<AlunoFundamental> alunosFundamental = new List<AlunoFundamental>();
        private static List<AlunoInfantil> alunosInfantil = new List<AlunoInfantil>();

        //ALUNO INFANTIL
        #region 
        public List<AlunoInfantil> GetAlunoInfantil()
        {
            return alunosInfantil;
        }

        public void AddAlunoInfantil(AlunoInfantil aluno)
        {
            alunosInfantil.Add(aluno);
        }

        public void DeleteAlunoInfantil(AlunoInfantil aluno)
        {
            alunosInfantil.Remove(aluno);
        }

        public void PutAlunoInfantil(AlunoInfantil aluno)
        {
            var put = alunosInfantil.Find(a => a.nome == aluno.nome);

            put.ano = aluno.ano;
            put.turno = aluno.turno;
            put.idade = aluno.idade;
        }

        public void PatchAlunoInfantil(AlunoInfantil aluno , string atributo)
        {
            var patch = alunosInfantil.FirstOrDefault(a => a.nome == aluno.nome);

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
        #endregion

        //ALUNO FUNDAMENTAL
        #region
        public List<AlunoFundamental> GetAlunoFundamental()
        {
            return alunosFundamental;
        }
        
        public void AddAlunoFundamental(AlunoFundamental aluno)
        {
            alunosFundamental.Add(aluno);
        }

        public void DeleteAlunoFundamental(AlunoFundamental aluno)
        {
            alunosFundamental.Remove(aluno);
        }

        public void PutAlunoFundamental(AlunoFundamental aluno)
        {
            var put = alunosFundamental.Find(a => a.nome == aluno.nome);

            put.ano = aluno.ano;
            put.turno = aluno.turno;
            put.idade = aluno.idade;
        }

        public void PatchAlunoFundamental(AlunoFundamental aluno , string atributo)
        {
            var patch = alunosFundamental.FirstOrDefault(a => a.nome == aluno.nome);

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
        #endregion

        //ALUNO SUPERIOR
        #region
        public List<AlunoSuperior> GetAlunoSuperior()
        {
            return alunosSuperior;
        }

        public void AddAlunoSuperior(AlunoSuperior aluno) 
        {
            alunosSuperior.Add(aluno);
        }

        public void DeleteAlunoSuperior(AlunoSuperior aluno)
        {
            alunosSuperior.Remove(aluno);
        }

        public void PutAlunoSuperior(AlunoSuperior aluno)
        {
            var put = alunosSuperior.Find(a => a.nome == aluno.nome);

            put.turno = aluno.turno;
            put.ano = aluno.ano;
            put.idade = aluno.idade;
            put.curso = aluno.curso;
        }

        public void PatchAlunoSuperior(AlunoSuperior aluno , string atributo)
        {
            var patch = alunosSuperior.FirstOrDefault(a => a.nome == aluno.nome);
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
        #endregion
    }
}
