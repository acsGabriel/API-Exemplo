namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoSuperiorService<T> : IAlunoService<T>
    {
        //Métodos herdados: Get , Post , Put , Patch , Delete...
        public List<T> Graduate(string curso1, string curso2);
        public T FirstStudentByCurso(string curso);
        public List<T> GetSelectedAlunos(string curso);
    }
}
