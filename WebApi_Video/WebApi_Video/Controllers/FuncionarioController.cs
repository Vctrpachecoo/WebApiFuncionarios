using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Video.Models;
using WebApi_Video.Services.FuncionarioService;

namespace WebApi_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // O controlador para gerenciar as operações relacionadas aos funcionários.
    public class FuncionarioController : ControllerBase
    {
        // Interface para a camada de serviços que lida com a lógica de negócios dos funcionários.
        private readonly IFuncionarioInterface _funcionarioInterface;

        // Construtor que injeta a dependência da interface do serviço de funcionários.
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            // Inicializa a interface de funcionários com a instância fornecida.
            _funcionarioInterface = funcionarioInterface;
        }

        // Endpoint para obter a lista de funcionários.
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            // Chama o método da interface para obter a lista de funcionários e retorna o resultado com status 200 (OK).
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }


        // Endpoint para obter um funcionário específico com base no ID fornecido.
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {
            // Chama o método da interface de serviços para obter o funcionário pelo ID fornecido.
            // O método GetFuncionarioById é assíncrono e retorna uma instância de ServiceResponse<FuncionarioModel>.
            ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.GetFuncionarioById(id);

            // Retorna a resposta do serviço com o status HTTP 200 (OK) e o conteúdo da resposta.
            // O conteúdo inclui o funcionário encontrado (ou nulo) e informações sobre o sucesso da operação.
            return Ok(serviceResponse);
        }


        // Endpoint para criar um novo funcionário.
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            // Chama o método da interface para criar um novo funcionário e retorna o resultado com status 200 (OK).
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }


        // Endpoint para atualizar um funcionário existente.
        // O método HTTP PUT é usado para modificar um recurso existente.
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            // Chama o método da interface de serviços para atualizar o funcionário fornecido.
            // O método UpdateFuncionario é assíncrono e retorna uma instância de ServiceResponse<List<FuncionarioModel>>.
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(editadoFuncionario);

            // Retorna a resposta do serviço com o status HTTP 200 (OK) e o conteúdo da resposta.
            // O conteúdo inclui a lista atualizada de funcionários e informações sobre o sucesso da operação.
            return Ok(serviceResponse);
        }



        // Endpoint para desativar um funcionário com base no ID fornecido.
        // O método HTTP PUT é usado para atualizar o recurso existente.
        [HttpPut("InativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int Id)
        {
            // Chama o método da interface de serviços para desativar o funcionário pelo ID fornecido.
            // O método InativaFuncionario é assíncrono e retorna uma instância de ServiceResponse<List<FuncionarioModel>>.
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InativaFuncionario(Id);

            // Retorna a resposta do serviço com o status HTTP 200 (OK) e o conteúdo da resposta.
            // O conteúdo inclui a lista atualizada de funcionários e informações sobre o sucesso da operação.
            return Ok(serviceResponse);
        }

        // Endpoint para excluir um funcionário existente.
        // O método HTTP DELETE é usado para remover um recurso existente identificado pelo ID fornecido.
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int Id)
        {
            // Chama o método da interface de serviços para excluir o funcionário com o ID fornecido.
            // O método DeleteFuncionario é assíncrono e retorna uma instância de ServiceResponse<List<FuncionarioModel>>.
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.DeleteFuncionario(Id);

            // Retorna a resposta do serviço com o status HTTP 200 (OK) e o conteúdo da resposta.
            // O conteúdo inclui a lista de funcionários atualizada e informações sobre o sucesso da operação.
            return Ok(serviceResponse);
        }




    }
}
