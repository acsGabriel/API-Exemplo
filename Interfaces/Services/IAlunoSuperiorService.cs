namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoSuperiorService : IAlunoService
    {
        public List<AlunoSuperior> Get();
        public void Post(AlunoSuperior aluno);
        public void Delete(string name);
        public void Put(AlunoSuperior aluno);
        public void Patch(AlunoSuperior aluno, string atributo);
        public List<AlunoSuperior> GetSelectedAlunos(string curso);
        public List<string> Names();
        public AlunoSuperior FirstStudent(string curso);
        public List<AlunoSuperior> Graduate(string curso1, string curso2);
    }
}
