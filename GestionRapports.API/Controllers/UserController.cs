using GestionRapports.API.DTOs;
using GestionRapports.API.Mappers;
using GestionRapports.BLL.Exceptions;
using GestionRapports.BLL.Interfaces;
using GestionRapports.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionRapports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        /// <summary>
        /// Retrieves a user from the database by ID.
        /// </summary>
        /// <param name="id">ID to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public IActionResult GetUserById(int id)
        {
            try
            {
                // Vérify errors
                if (id <= 0) throw new NegativeNumberException("ID doit être positif");
                if (!service.CheckUserExistance(id)) throw new NotFoundException("L'utilisateur n'a pas été trouvé");

                UserDTO result = service.GetUserById(id).ToDTO();
                return Ok(result);
            }
            catch (NegativeNumberException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a user from the database by Email.
        /// </summary>
        /// <param name="id">Email to retrieve.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        [HttpGet("email")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                // Vérify errors
                if (!service.CheckUserExistance(email)) throw new NotFoundException("L'utilisateur n'a pas été trouvé");

                UserDTO result = service.GetUserByEmail(email).ToDTO();
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}