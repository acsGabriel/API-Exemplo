namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoInfantilService : IAlunoService
    {
        public List<AlunoInfantil> Get();
        public void Post(AlunoInfantil aluno);
        public void Delete(string name);
        public void Put(AlunoInfantil aluno);
        public void Patch(AlunoInfantil aluno, string atributo);
        public List<AlunoInfantil> GetSelectedAlunos(int ano);
        public List<string> Names();
        public AlunoInfantil FirstStudent(int ano);
    }
}
