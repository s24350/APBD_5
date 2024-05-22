using Microsoft.AspNetCore.Mvc;
using Zadanie7.Interfaces;

namespace Zadanie7.Controllers
{
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int idClient) {
            try
            {
                await _clientRepository.DeleteClientAsync(idClient);
                return Ok($"Client with id {idClient} was deleted successfully :)");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message );
            }
        }
    }
}
