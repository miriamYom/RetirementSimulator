using BL;
using BL.Auth;
using BL.BLImplements;
using BL.DTO;
using BL.Pension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class RentiermentSimulatorController : ControllerBase
{
    IUserServiceBL userServiceBL;

    IPensionFactory pensionFactory;
    private readonly IJWTManagerRepository jWTManager;

    public RentiermentSimulatorController(IUserServiceBL us, IPensionFactory pf, IJWTManagerRepository jWTManager)
    {
        userServiceBL = us;
        pensionFactory = pf;
        this.jWTManager = jWTManager;
    }

    [HttpGet("GetAll")]
    public List<UserDTO> GetAll()
    {
        return userServiceBL.GetAllAsync().Result;
    }

    [HttpPost("GetDetails")]
    public UserDTO GetDetails(UserDTO user)
    {
        return userServiceBL.GetAsync(user).Result;
    }

    [HttpPost("CreateUser")]
    public bool CreateUser([FromBody] UserDTO user)
    {
        try { 
        return userServiceBL.CreateAsync(user).Result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpDelete("DeleteUser")]
    public bool DeleteUser(UserDTO user)
    {
        return userServiceBL.DeleteAsync(user).Result;
    }

    [HttpPut("Update")]
    public bool UpdateUser(params UserDTO[] user)
    {
        return userServiceBL.UpdateAsync(user[0], user[1]).Result;
    }

    [HttpPost("Login")]
    public UserDTO Login(string email, [FromBody] string pass)
    {
        return userServiceBL.Login(email, pass);

    }
    [HttpPost("GetPensionCalculates")]
    public object CreatePensionService(string pensionType, [FromBody] object employee)
    {
        try
        {
            var o = employee;
           return pensionFactory.Create(pensionType, employee);
        }
        catch (InvalidParameterException ex)
        {
            throw ex;
        }
    }
    [AllowAnonymous]
    [HttpPost]
    [Route("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(UserDTO usersdata)
    {
        var validUser = jWTManager.UserAuthenticate(usersdata.Email,usersdata.Password);

        if (validUser == null)
        {
            return Unauthorized("Incorrect username or password!");
        }

        var token = jWTManager.Authenticate(validUser);

        if (token == null)
        {
            return Unauthorized("Invalid Attempt!");
        }

        //// saving refresh token to the db
        //UserRefreshTokenDTO obj = new UserRefreshTokenDTO
        //{
        //    RefreshToken = token.RefreshToken,
        //    UserId = validUser.Id,
        //    Email = usersdata.Email,
        //};

        //await tokenActions.AddUserRefreshTokens(obj);
        return Ok(new { user = validUser, token = token });
    }

}

