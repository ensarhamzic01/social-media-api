﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Data.Services;
using SocialMediaAPI.Data.ViewModels;

namespace SocialMediaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService userService;
        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterVM request)
        {
            try
            {
                var response = userService.Register(request);
                return Created(nameof(response), response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("confirm-account")]
        public IActionResult ConfirmAccount([FromBody] VerifyAccountVM request)
        {
            try
            {
                var response = userService.ConfirmAccount(request.ConfirmToken);
                return Ok(new {success = response});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginVM request)
        {
            try
            {
                var response = userService.Login(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut, Authorize]
        public IActionResult UpdateUser([FromForm] UserUpdateVM request)
        {
            try
            {
                var response = userService.UpdateUser(request);
                return Ok(response.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException?.Message });
            }
        } 

        [HttpPost("verify"), Authorize]
        public IActionResult VerifyToken()
        {
            try
            {
                var response = userService.GetAuthUserData();
                return Ok(new { user = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/follow"), Authorize]
        public IActionResult FollowOrUnfollowUser(string id)
        {
            try
            {
                var message = userService.FollowOrUnfollowUser(id);
                return Ok(new { success = message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}/follow"), Authorize]
        public IActionResult RemoveFollower(string id)
        {
            try
            {
                var message = userService.RemoveFollower(id);
                return Ok(new { success = message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("followers/{id}"), Authorize]
        public IActionResult AcceptFollower(string id)
        {
            try
            {
                var message = userService.AcceptFollower(id);
                return Ok(new { success = message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}/posts"), Authorize]
        public IActionResult GetUserWithPosts(string id)
        {
            try
            {
                var userWithPosts = userService.GetUserWithPosts(id);
                return Ok(userWithPosts);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword(ForgotPasswordVM request)
        {
            try
            {
                var response = userService.ForgotPassword(request.Email);
                return Ok(new {success = response});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("reset-password")]
        public IActionResult ResetPassword(PasswordResetVM request)
        {
            try
            {
                var response = userService.ResetPassword(request.ResetToken, request.NewPassword);
                return Ok(new { success = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("feed"), Authorize]
        public IActionResult GetUserFeed()
        {
            try
            {
                var userFeed = userService.GetUserFeed();
                return Ok(userFeed);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("search/{searchString}"), Authorize]
        public IActionResult SearchUsers(string searchString)
        {
            try
            {
                var foundUsers = userService.FindUsers(searchString);
                return Ok(foundUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                var response = userService.DeleteUser(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
