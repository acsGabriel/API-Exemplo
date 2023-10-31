namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoFundamentalService : IAlunoService
    {
        public List<AlunoFundamental> Get();
        public void Post(AlunoFundamental aluno);
        public void Delete(string name);
        public void Put(AlunoFundamental aluno); 
        public void Patch(AlunoFundamental aluno, string atributo);
        public List<AlunoFundamental> GetSelectedAlunos(int ano);
        public List<string> Names();
        public AlunoFundamental FirstStudent(int ano);
    }
}
