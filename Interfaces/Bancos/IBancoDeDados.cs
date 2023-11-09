namespace API_Exemplo.Interfaces.Bancos
{
    public interface IBancoDeDados
    {
        //METODOS ALUNO INFANTIL
        public List<AlunoInfantil> GetAlunoInfantil();
        public void AddAlunoInfantil(AlunoInfantil aluno);
        public void DeleteAlunoInfantil(AlunoInfantil aluno);
        public void PutAlunoInfantil(AlunoInfantil aluno);
        public void PatchAlunoInfantil(AlunoInfantil aluno, string atributo);

        //METODOS ALUNO FUNDAMENTAL
        public List<AlunoFundamental> GetAlunoFundamental();
        public void AddAlunoFundamental(AlunoFundamental aluno);
        public void DeleteAlunoFundamental(AlunoFundamental aluno);
        public void PutAlunoFundamental(AlunoFundamental aluno);
        public void PatchAlunoFundamental(AlunoFundamental aluno , string atributo);

        //METODOS ALUNO SUPERIOR
        public List<AlunoSuperior> GetAlunoSuperior();
        public void AddAlunoSuperior(AlunoSuperior aluno);
        public void DeleteAlunoSuperior(AlunoSuperior aluno);
        public void PutAlunoSuperior(AlunoSuperior aluno);
        public void PatchAlunoSuperior(AlunoSuperior aluno, string atributo);

    }
}
