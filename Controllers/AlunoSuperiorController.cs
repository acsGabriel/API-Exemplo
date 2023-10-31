//using API_Exemplo.Interfaces.Services;
//using API_Exemplo.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace API_Exemplo.Controllers
//{
//    [ApiController]
//    [Route("[Controller]")] //FAZ A CONEXÃO COM O SERVIDOR WEB
//    public class AlunoSuperiorController : ControllerBase
//    {
//        private readonly ILogger<AlunoSuperiorController> _logger;

//        private readonly IAlunoSuperiorService _alunoSuperiorService;

//        public AlunoSuperiorController(ILogger<AlunoSuperiorController> logger , IAlunoSuperiorService alunoService)
//        {
//            _logger = logger;
//            _alunoSuperiorService = alunoService;
           
//        }

//        [HttpGet(Name = "GetAlunos")] //FAZ A REQUISIÇÃO HTTP PARA MOSTRAR OS ALUNOS
//        public List<AlunoSuperior> Get()
//        {
            
//            return _alunoService.SortByName(); //Mostra a lista estatica com as strings que foram criadas a partir dos atributos de um objeto
//        }

//        [HttpPost(Name = "PostAlunos")] //ADICIONA UM NOVO ALUNO
//        public bool Post([FromBody] AlunoSuperior aluno)
//        {
//            //Colocar no serviço
//            BancoDeDados.alunos.Add(aluno); //Adiciona o aluno à lista de alunos
//            return true;
//        }


//        [HttpPut(Name = "PutAlunos")] //ATUALIZA TODOS OS DADOS DE UM ALUNO 
//        public bool Put([FromBody] AlunoSuperior aluno)
//        {
//            _alunoService.PutAluno(aluno);
//            return true;
//        }

//        [HttpDelete(Name = "DeleteAlunos")] //REMOVE UM ALUNO
//        public bool Delete([FromBody] string nome)
//        {
//            _alunoService.DeleteAluno(nome);
//            return true;
//        }


//        [HttpPatch(Name = "PatchAlunos")] //ATUALIZA UM DADO DO ALUNO
//        public bool Patch([FromBody] AlunoSuperior aluno , string atributo)
//        {
//            _alunoService.PatchAluno(aluno , atributo);
//            return true;
//        }

        
//        [HttpGet] //MOSTRA ALUNOS DE UM CURSO ESPECIFICO
//        [Route("GetSelectedAlunos")] 
//        public List<AlunoSuperior> GetSelectedAlunos(string curso)
//        {
//            return _alunoService.GetSelectedAlunos(curso);
//        }

//        [HttpGet]
//        [Route("Graduation")] //MOSTRA OS ALUNOS QUE ESTAO PARA SE GRADUAR DE 2 CURSOS SIMULTANEAMENTE
//        public List<AlunoSuperior> GetGraduatingStudents(string curso1 , string curso2)
//        {
//            return _alunoService.Graduate(curso1,curso2);
//        }

//        [HttpGet]
//        [Route("StudentNames")] //MOSTRA O NOME DE TODOS OS ALUNOS
//        public List<string> StudentNames()
//        {
//            return _alunoService.Names();
//        }

//        [HttpGet]
//        [Route("FirstOfClass")] //MOSTRA O PRIMEIRO ALUNO DO CURSO PASSADO COMO PARÂMETRO
//        public AlunoSuperior MostFullGraduation(string course)
//        {
//            return _alunoService.FirstStudent(course);
//        }


//    }
//}