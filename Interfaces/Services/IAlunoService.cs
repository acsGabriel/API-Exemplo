namespace API_Exemplo.Interfaces.Services
{
    public interface IAlunoService<T>
    {
        //METODOS 
        public List<T> Get();
        public bool Post(T aluno);
        public void Delete(string nome);
        public bool Put(T aluno); 
        public bool Patch(T aluno, string atributo);
        public List<string> Names();
        

    }
}
