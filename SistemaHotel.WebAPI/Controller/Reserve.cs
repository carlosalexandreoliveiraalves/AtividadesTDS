
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaHotel.EFCore.DataContext;
using SistemaHotel.Model;

namespace SistemaHotel.WebAPI.Controller;


[Route("api/reserves")]
[ApiController] 

public class ReserveController : ControllerBase {

    private readonly SistemaHotelEFCoreContext context;
    public ReserveController(SistemaHotelEFCoreContext context)
    {
            this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var reserves = await context.Reserves.ToListAsync();
        return Ok(reserves);
    }

    [HttpGet("getByID")]
    public async Task<IActionResult> GetByID(int reserveID) {
        ReserveModel? reserve = await context.Reserves.FindAsync(reserveID);
        return Ok(reserve);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReserveModel reserve) {
        context.Add(reserve);
        await context.SaveChangesAsync(); 
        return  Created("", reserve);   
    }

    [HttpDelete] 
    public async Task<IActionResult> DeleteById(int reserveID) {
        ReserveModel? reserve = await context.Reserves.FindAsync(reserveID);
        if (reserve != null) {
            context.Remove(reserve);
            await context.SaveChangesAsync();
            return Ok();
        }
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(ReserveModel reserve) {
        context.Entry(reserve).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok(reserve);
    }
}