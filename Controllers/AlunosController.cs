using API_Exemplo.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Exemplo.Controllers
{
    [ApiController]
    [Route("[Controller]")] //FAZ A CONEXÃO COM O SERVIDOR WEB
    public class AlunosController : ControllerBase
    {
        AlunoService alunoService = new AlunoService(); //CRIAÇÃO DE INSTÂNCIA PARA CLASSE DOS SERVIÇOS

        private readonly ILogger<AlunosController> _logger;

        public AlunosController(ILogger<AlunosController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAlunos")] //FAZ A REQUISIÇÃO HTTP PARA MOSTRAR OS ALUNOS
        public List<Aluno> Get()
        {
            return alunoService.SortByName(); //Mostra a lista estatica com as strings que foram criadas a partir dos atributos de um objeto
        }

        [HttpPost(Name = "PostAlunos")] //ADICIONA UM NOVO ALUNO
        public bool Post([FromBody] Aluno aluno)
        {
            BancoDeDados.alunos.Add(aluno); //Adiciona o aluno à lista de alunos
            return true;
        }


        [HttpPut(Name = "PutAlunos")] //ATUALIZA TODOS OS DADOS DE UM ALUNO 
        public bool Put([FromBody] Aluno aluno)
        {
            alunoService.PutAluno(aluno);
            return true;
        }

        [HttpDelete(Name = "DeleteAlunos")] //REMOVE UM ALUNO
        public bool Delete([FromBody] string nome)
        {
            alunoService.DeleteAluno(nome);
            return true;
        }


        [HttpPatch(Name = "PatchAlunos")] //ATUALIZA UM DADO DO ALUNO
        public bool Patch([FromBody] Aluno aluno , string atributo)
        {
            alunoService.PatchAluno(aluno , atributo);
            return true;
        }

        
        [HttpGet] //MOSTRA ALUNOS DE UM CURSO ESPECIFICO
        [Route("GetSelectedAlunos")] 
        public List<Aluno> GetSelectedAlunos(string curso)
        {
            return alunoService.GetSelectedAlunos(curso);
        }

        [HttpGet]
        [Route("Graduation")] //MOSTRA OS ALUNOS QUE ESTAO PARA SE GRADUAR DE 2 CURSOS SIMULTANEAMENTE
        public List<Aluno> GetGraduatingStudents(string curso1 , string curso2)
        {
            return alunoService.Graduate(curso1,curso2);
        }

        [HttpGet]
        [Route("StudentNames")] //MOSTRA O NOME DE TODOS OS ALUNOS
        public List<string> StudentNames()
        {
            return alunoService.Names();
        }

        [HttpGet]
        [Route("FirstOfClass")] //MOSTRA O PRIMEIRO ALUNO DO CURSO PASSADO COMO PARÂMETRO
        public Aluno MostFullGraduation(string course)
        {
            return alunoService.FirstStudent(course);
        }


    }
}