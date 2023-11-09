namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoInfantilService<T> : IAlunoService<T>
    {
        public List<T> GetSelectedAlunos(int ano);
        public T FirstStudentByAno(int ano);
    }
}
