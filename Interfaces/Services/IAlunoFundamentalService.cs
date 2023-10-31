namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoFundamentalService<T> : IAlunoService<T>
    {
        public T FirstStudentByAno(int ano);
        public List<T> GetSelectedAlunos(int ano);
    }
}
