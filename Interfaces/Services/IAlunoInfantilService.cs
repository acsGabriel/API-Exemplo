namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoInfantilService<T> : IAlunoService<T>
    {
        //Métodos herdados: Post, Put , Patch , Delete ...
        public T FirstStudentByAno(int ano);
        public List<T> GetSelectedAlunos(int ano);
    }
}
