namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoSuperiorService<T> : IAlunoService<T>
    {
        public List<T> GetSelectedAlunos(string curso);
        public T FirstStudentByCurso(string curso);
        public List<T> Graduate(string curso1, string curso2);
    }
}
