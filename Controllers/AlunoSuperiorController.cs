using API_Exemplo.Interfaces.Services;
using API_Exemplo.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Exemplo.Controllers
{
    [ApiController]
    [Route("[Controller]")] //FAZ A CONEXÃO COM O SERVIDOR WEB
    public class AlunoSuperiorController : ControllerBase
    {
        //INJEÇÃO DE DEPENDÊNCIAS
        private readonly ILogger<AlunoSuperiorController> _logger;

        private readonly IAlunoSuperiorService<AlunoSuperior> _alunoSuperiorService;

        public AlunoSuperiorController(ILogger<AlunoSuperiorController> logger, IAlunoSuperiorService<AlunoSuperior> alunoService)
        {
            _logger = logger;
            _alunoSuperiorService = alunoService;

        }

        //METODOS
        [HttpGet(Name = "GetAlunosSuperior")] 
        public List<AlunoSuperior> Get()
        {
            return _alunoSuperiorService.Get(); 
        }

        [HttpPost(Name = "PostAlunosSuperior")] 
        public void Post(AlunoSuperior aluno)
        {
            _alunoSuperiorService.Post(aluno); 
        }

        [HttpDelete(Name = "DeleteAlunosSuperior")]
        public void Delete(string nome)
        {
            _alunoSuperiorService.Delete(nome);
        }

        [HttpPut(Name = "PutAlunosSuperior")]  
        public void Put(AlunoSuperior aluno)
        {
            _alunoSuperiorService.Put(aluno);
        }

        [HttpPatch(Name = "PatchAlunosSuperior")] 
        public void Patch(AlunoSuperior aluno, string atributo)
        {
            _alunoSuperiorService.Patch(aluno, atributo);
        }

        [HttpGet] 
        [Route("GetSelectedAlunosSuperior")]
        public List<AlunoSuperior> GetSelectedAlunos(string curso)
        {
            return _alunoSuperiorService.GetSelectedAlunos(curso);
        }

        [HttpGet]
        [Route("Names")] 
        public List<string> Names()
        {
            return _alunoSuperiorService.Names();
        }

        [HttpGet]
        [Route("FirstOfClass")] 
        public AlunoSuperior FirstStudent(string curso)
        {
            return _alunoSuperiorService.FirstStudentByCurso(curso);
        }

        [HttpGet]
        [Route("Graduation")] 
        public List<AlunoSuperior> Graduation(string curso1, string curso2)
        {
            return _alunoSuperiorService.Graduate(curso1, curso2);
        }
    }
}