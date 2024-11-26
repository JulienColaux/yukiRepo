using System;
using System.Collections.Generic;
using System.Linq;
using GestionRapports.API.DTOs;
using GestionRapports.API.Forms;
using GestionRapports.API.Mappers;
using GestionRapports.BLL.Exceptions;
using GestionRapports.BLL.Interfaces;
using GestionRapports.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionRapports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        
        [Authorize]
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
        
        
        
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateUser([FromBody] CreateUserForm user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Conversion directe du formulaire en modèle métier
                User userModel = user.ToModel();

                // Appel du service pour la création
                User createdUser = service.CreateUser(userModel);

                // Conversion du modèle créé en DTO pour la réponse
                UserDTO userDTO = createdUser.ToDTO();

                // Retourne un status 201 avec l'objet créé
                return CreatedAtAction(nameof(GetUserById), new { id = userDTO.User_Id }, userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        

        [Authorize]
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
        
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult Login([FromBody] UserLoginForm user)
        {
            try
            {
                var loginResult = service.Login(user.ToModel());
                
                // returns a login result containing the user details and a JWT token (User's Email, Expiration date)
                return Ok(new
                {
                    token = loginResult.Token,
                    userId = loginResult.User.User_Id,
                    email = loginResult.User.Email,
                });
            }
            catch (CredentialException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("editProfil")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult editProfil([FromBody] editRoleForm profil)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                User user = service.GetUserById(profil.UserId);
                if (user == null)
                {
                    return NotFound($"Utilisateur avec l'ID {profil.UserId} non trouvé.");
                }
                
                if (!Enum.IsDefined(typeof(Profil), profil.Profil))
                {
                    return BadRequest($"Le rôle '{profil.Profil}' n'est pas valide.");
                }
                
                service.editRole(profil.UserId, profil.Profil.ToString());
       

                return Ok("Profil mis à jour avec succès.");
            }
            catch (Exception e)
            {
                return BadRequest($"Une erreur est survenue : {e.Message}");
            }
        }
        
        [HttpGet("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = service.GetAllUsers();

                if (users == null || !users.Any())
                {
                    return Ok("No users found."); 
                }

                return Ok(users); 
            }
            catch (Exception e)
            {
                return BadRequest($"An error occurred while retrieving users: {e.Message}");
            }
        }

    }
}