using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaHotel.EFCore.DataContext;
using SistemaHotel.Model;

namespace SistemaHotel.WebAPI.Controller;


[Route("api/user")]
[ApiController] 
public class UserController : ControllerBase {

    private readonly SistemaHotelEFCoreContext context;
    public UserController(SistemaHotelEFCoreContext context)
    {
            this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var users = await context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("getByID")]
    public async Task<IActionResult> GetByID(int userID) {
        UserModel? user = await context.Users.FindAsync(userID);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserModel user) {
        context.Add(user);
        await context.SaveChangesAsync(); 
        return  Created("", user);   
    }

    [HttpDelete] 
    public async Task<IActionResult> DeleteById(int userID) {
        UserModel? user = await context.Users.FindAsync(userID);
        if (user != null) {
            context.Remove(user);
            await context.SaveChangesAsync();
            return Ok();
        }
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UserModel user) {
        context.Entry(user).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok(user);
    }
}