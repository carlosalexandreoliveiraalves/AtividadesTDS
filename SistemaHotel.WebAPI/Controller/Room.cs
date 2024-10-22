using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaHotel.EFCore.DataContext;
using SistemaHotel.Model;


namespace SistemaHotel.WebAPI.Controller;

[Route("api/rooms")]
[ApiController] 
public class RoomController : ControllerBase {

    private readonly SistemaHotelEFCoreContext context;
    public RoomController(SistemaHotelEFCoreContext context)
    {
            this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var rooms = await context.Rooms.ToListAsync();
        return Ok(rooms);
    }

    [HttpGet("getByID")]
    public async Task<IActionResult> GetByID(int roomID) {
        RoomModel? room = await context.Rooms.FindAsync(roomID);
        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RoomModel room) {
        context.Add(room);
        await context.SaveChangesAsync(); 
        return  Created("", room);   
    }

    [HttpDelete] 
    public async Task<IActionResult> DeleteById(int roomID) {
        RoomModel? room = await context.Rooms.FindAsync(roomID);
        if (room != null) {
            context.Remove(room);
            await context.SaveChangesAsync();
            return Ok();
        }
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(RoomModel room) {
        context.Entry(room).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok(room);
    }
}