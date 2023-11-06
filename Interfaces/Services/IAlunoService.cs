namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoService<T>
    {
        public List<T> Get();
        public bool Post(T tipoAluno);
        public void Delete(string name);
        public void Put(T tipoAluno); //Generico
        public void Patch(T tipoAluno, string atributo);
        public List<string> Names();
        

    }
}
