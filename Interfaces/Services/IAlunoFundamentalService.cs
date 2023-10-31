namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoFundamentalService<T> : IAlunoService<T>
    {
        //public void Put(AlunoFundamental aluno);
        public T FirstStudentByAno(int ano);
    }
}
