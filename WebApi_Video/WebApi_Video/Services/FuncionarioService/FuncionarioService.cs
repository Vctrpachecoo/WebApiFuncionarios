using Microsoft.EntityFrameworkCore;
using WebApi_Video.Context;
using WebApi_Video.Models;

namespace WebApi_Video.Services.FuncionarioService
{
    // Aonde fica toda a lógica dos métodos 

    // Implementando as interfaces criadas em IFuncionarioInterface
    public class FuncionarioService : IFuncionarioInterface
    {

        // Realizando a injeção de dependência na classe para acesso com o banco de dados. 
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            // Cria uma nova instância da classe ServiceResponse para armazenar a resposta da requisição.
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                // Verifica se o objeto novoFuncionario é nulo.
                if (novoFuncionario == null)
                {
                    // Se o novoFuncionario for nulo, define os dados como nulos, a mensagem de erro e marca a operação como não bem-sucedida.
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse; // Retorna a resposta com erro.
                }

                // Adiciona o novo funcionário ao contexto de dados.
                _context.Add(novoFuncionario);
                // Salva as alterações no banco de dados de forma assíncrona.
                await _context.SaveChangesAsync();

                // Atualiza a propriedade Dados da resposta com a lista atualizada de funcionários.
                serviceResponse.Dados = await _context.Funcionarios.ToListAsync();
                // Define a mensagem como nula e marca a operação como bem-sucedida.
                serviceResponse.Mensagem = "Funcionário criado com sucesso!";
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                // Se ocorrer uma exceção, define a mensagem de erro e marca a operação como não bem-sucedida.
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta do serviço contendo a lista de funcionários e o status da operação.
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            // Cria uma nova instância da classe ServiceResponse para armazenar a resposta da requisição.
            // Esta resposta incluirá a lista atualizada de funcionários, uma mensagem e o status da operação.
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                // Busca o funcionário no contexto de dados com base no ID fornecido.
                // Usa FirstOrDefault para retornar o primeiro funcionário que corresponde ao ID ou null se não encontrar nenhum.
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                // Verifica se o funcionário foi encontrado.
                if (funcionario == null)
                {
                    // Se o funcionário não for encontrado, define os dados como nulos, a mensagem de erro e marca a operação como não bem-sucedida.
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    // Retorna a resposta com a mensagem de erro e status de falha.
                    return serviceResponse;
                }

                // Remove o funcionário encontrado do contexto de dados.
                _context.Funcionarios.Remove(funcionario);

                // Salva as alterações no banco de dados de forma assíncrona.
                // Isso persiste a remoção do funcionário no banco de dados.
                await _context.SaveChangesAsync();

                // Define a propriedade Dados da resposta com a lista atualizada de funcionários após a exclusão.
                // A lista inclui todos os funcionários restantes no banco de dados.
                serviceResponse.Dados = _context.Funcionarios.ToList();
                // Define a mensagem como nula e marca a operação como bem-sucedida.
                serviceResponse.Mensagem = "Funcionário excluído com sucesso!";
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                // Se ocorrer uma exceção durante a execução, define a mensagem de erro e marca a operação como não bem-sucedida.
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta do serviço contendo a lista de funcionários atualizada e o status da operação.
            return serviceResponse;
        }


        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            // Cria uma nova instância da classe ServiceResponse para armazenar a resposta da requisição.
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                // Busca o funcionário no contexto de dados com base no ID fornecido.
                // Usa FirstOrDefault para retornar o primeiro funcionário que corresponde ao ID ou null se não encontrar nenhum.
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                // Verifica se o funcionário foi encontrado.
                if (funcionario == null)
                {
                    // Se o funcionário não for encontrado, define os dados como nulos, a mensagem de erro e marca a operação como não bem-sucedida.
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    // Se o funcionário for encontrado, define os dados da resposta com o funcionário encontrado.
                    serviceResponse.Dados = funcionario;
                    // Define a mensagem como nula e marca a operação como bem-sucedida.
                    serviceResponse.Mensagem = "Funcionário encontrado com sucesso!";
                    serviceResponse.Sucesso = true;
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer uma exceção durante a execução, define a mensagem de erro e marca a operação como não bem-sucedida.
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta do serviço contendo o funcionário encontrado (ou nulo) e o status da operação.
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            // Cria uma nova instância da classe ServiceResponse para armazenar a resposta da requisição
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                // Tenta recuperar todos os funcionários do banco de dados e atribui à propriedade Dados da resposta
                // O método ToList() executa a consulta e materializa os resultados em uma lista
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                // Captura qualquer exceção que possa ocorrer durante a execução do método
                // Atribui a mensagem da exceção à propriedade Mensagem da resposta
                // Indica que a operação falhou ao definir a propriedade Sucesso como false
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta da requisição, que pode conter os dados dos funcionários ou uma mensagem de erro
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            // Cria uma nova instância da classe ServiceResponse para armazenar a resposta da requisição.
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                // Busca o funcionário no contexto de dados com base no ID fornecido.
                // Usa FirstOrDefault para retornar o primeiro funcionário que corresponde ao ID ou null se não encontrar nenhum.
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                // Verifica se o funcionário foi encontrado.
                if (funcionario == null)
                {
                    // Se o funcionário não for encontrado, define os dados como nulos, a mensagem de erro e marca a operação como não bem-sucedida.
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse; // Retorna a resposta com erro.
                }

                // Define o status do funcionário como inativo.
                funcionario.Ativo = false;
                // Define a data e hora da alteração para o horário local atual.
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                // Atualiza o funcionário no contexto de dados com as novas informações.
                _context.Funcionarios.Update(funcionario);
                // Salva as alterações no banco de dados de forma assíncrona.
                await _context.SaveChangesAsync();

                // Define a propriedade Dados da resposta com a lista atualizada de funcionários.
                serviceResponse.Dados = _context.Funcionarios.ToList();
                // Define a mensagem como nula e marca a operação como bem-sucedida.
                serviceResponse.Mensagem = "Funcionário inativado com sucesso!";
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                // Se ocorrer uma exceção durante a execução, define a mensagem de erro e marca a operação como não bem-sucedida.
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta do serviço contendo a lista de funcionários atualizada e o status da operação.
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            // Cria uma nova instância da classe ServiceResponse para armazenar a resposta da requisição.
            // Esta resposta incluirá a lista atualizada de funcionários, uma mensagem e o status da operação.
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                // Busca o funcionário no contexto de dados com base no ID fornecido no objeto editadoFuncionario.
                // Usa AsNoTracking para garantir que o funcionário retornado pela consulta não seja rastreado pelo contexto.
                // Isso melhora a performance quando a entidade não precisa ser atualizada diretamente.
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);

                // Verifica se o funcionário foi encontrado.
                if (funcionario == null)
                {
                    // Se o funcionário não for encontrado, define os dados como nulos, a mensagem de erro e marca a operação como não bem-sucedida.
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    // Retorna a resposta com a mensagem de erro e status de falha.
                    return serviceResponse;
                }

                // Atualiza a data e hora da alteração para o horário local atual.
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                // Atualiza o funcionário no contexto de dados com as informações do objeto editadoFuncionario.
                // Esse comando marca o funcionário como modificado no contexto.
                _context.Funcionarios.Update(editadoFuncionario);

                // Salva as alterações no banco de dados de forma assíncrona.
                await _context.SaveChangesAsync();

                // Define a propriedade Dados da resposta com a lista atualizada de funcionários.
                // Isso inclui o funcionário que foi atualizado e outros funcionários no banco de dados.
                serviceResponse.Dados = _context.Funcionarios.ToList();
                // Define a mensagem como nula e marca a operação como bem-sucedida.
                serviceResponse.Mensagem = "Funcionário atualizado com sucesso!";
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                // Se ocorrer uma exceção durante a execução, define a mensagem de erro e marca a operação como não bem-sucedida.
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta do serviço contendo a lista de funcionários atualizada e o status da operação.
            return serviceResponse;
        }


    }
}
