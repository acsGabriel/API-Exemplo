using API_Exemplo.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Exemplo.Controllers
{
    [ApiController]
    [Route("[Controller]")] //FAZ A CONEXÃO COM O SERVIDOR WEB
    public class AlunosController : ControllerBase
    {
        AlunoService alunoService = new AlunoService();

        private readonly ILogger<AlunosController> _logger;

        public AlunosController(ILogger<AlunosController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAlunos")] //FAZ A REQUISIÇÃO HTTP PARA MOSTRAR OS ALUNOS
        public List<Aluno> Get()
        {
            return alunoService.sortByName(Aluno.alunos); //Mostra a lista estatica com as strings que foram criadas a partir dos atributos de um objeto
        }

        [HttpPost(Name = "PostAlunos")] //Adiciona um novo aluno 
        public bool Post([FromBody] Aluno aluno)
        {
            Aluno.alunos.Add(aluno); //Adiciona o aluno à lista de alunos
            return true;
        }


        [HttpPut(Name = "PutAlunos")] //Atualiza os dados de um novo aluno
        public bool Put([FromBody] Aluno aluno)
        {
            alunoService.putAluno(aluno);
            return true;
        }

        [HttpDelete(Name = "DeleteAlunos")] //Remove um aluno
        public bool Delete([FromBody] string nome)
        {
            alunoService.deleteAluno(nome);
            return true;
        }


        [HttpPatch(Name = "PatchAlunos")]
        public bool Patch([FromBody] Aluno aluno)
        {
            alunoService.patchAluno(aluno);
            return true;
        }

        
        [HttpGet]
        [Route("GetSelectedAlunos")]
        public List<Aluno> GetSelectedAlunos(string curso)
        {
            return alunoService.getSelectedAlunos(curso);
        }

        [HttpGet]
        [Route("Graduation")]
        public Aluno GetGraduatingStudent()
        {
            return alunoService.graduate(Aluno.alunos);
        }

    }
}