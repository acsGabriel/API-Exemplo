using API_Exemplo.Interfaces.Services;
using API_Exemplo.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Exemplo.Controllers
{
    [ApiController]
    [Route("[Controller]")] //FAZ A CONEXÃO COM O SERVIDOR WEB
    public class AlunoSuperiorController : ControllerBase
    {
        private readonly ILogger<AlunoSuperiorController> _logger;

        private readonly IAlunoSuperiorService _alunoSuperiorService;

        public AlunoSuperiorController(ILogger<AlunoSuperiorController> logger, IAlunoSuperiorService alunoSuperiorService)
        {
            _logger = logger;
            _alunoSuperiorService = alunoSuperiorService;

        }

        [HttpGet(Name = "GetAlunosSuperior")] //FAZ A REQUISIÇÃO HTTP PARA MOSTRAR OS ALUNOS
        public List<AlunoSuperior> Get()
        {

            return _alunoSuperiorService.Get(); //Mostra a lista estatica com as strings que foram criadas a partir dos atributos de um objeto
        }

        [HttpPost(Name = "PostAlunosSuperior")] //ADICIONA UM NOVO ALUNO
        public bool Post([FromBody] AlunoSuperior aluno)
        {
            //Colocar no serviço
            _alunoSuperiorService.Post(aluno); //Adiciona o aluno à lista de alunos
            return true;
        }


        [HttpPut(Name = "PutAlunosSuperior")] //ATUALIZA TODOS OS DADOS DE UM ALUNO 
        public bool Put([FromBody] AlunoSuperior aluno)
        {
            _alunoSuperiorService.Put(aluno);
            return true;
        }

        [HttpDelete(Name = "DeleteAlunosSuperior")] //REMOVE UM ALUNO
        public bool Delete([FromBody] string nome)
        {
            _alunoSuperiorService.Delete(nome);
            return true;
        }


        [HttpPatch(Name = "PatchAlunosSuperior")] //ATUALIZA UM DADO DO ALUNO
        public bool Patch([FromBody] AlunoSuperior aluno, string atributo)
        {
            _alunoSuperiorService.Patch(aluno, atributo);
            return true;
        }


        [HttpGet] //MOSTRA ALUNOS DE UM CURSO ESPECIFICO
        [Route("GetSelectedAlunosSuperior")]
        public List<AlunoSuperior> GetSelectedAlunos(string curso)
        {
            return _alunoSuperiorService.GetSelectedAlunos(curso);
        }

        [HttpGet]
        [Route("Graduation")] //MOSTRA OS ALUNOS QUE ESTAO PARA SE GRADUAR DE 2 CURSOS SIMULTANEAMENTE
        public List<AlunoSuperior> GetGraduatingStudents(string curso1, string curso2)
        {
            return _alunoSuperiorService.Graduate(curso1, curso2);
        }

        [HttpGet]
        [Route("Names")] //MOSTRA O NOME DE TODOS OS ALUNOS
        public List<string> StudentNames()
        {
            return _alunoSuperiorService.Names();
        }

        [HttpGet]
        [Route("FirstOfClass")] //MOSTRA O PRIMEIRO ALUNO DO CURSO PASSADO COMO PARÂMETRO
        public AlunoSuperior MostFullGraduation(string course)
        {
            return _alunoSuperiorService.FirstStudent(course);
        }


    }
}