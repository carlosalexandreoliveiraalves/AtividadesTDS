
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaHotel.EFCore.DataContext;
using SistemaHotel.Model;

namespace SistemaHotel.WebAPI.Controller;

[Route("api/reports")]
[ApiController] 
public class ReportController : ControllerBase {

    private readonly SistemaHotelEFCoreContext context;
    public ReportController(SistemaHotelEFCoreContext context)
    {
            this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var reports = await context.Reports.ToListAsync();
        return Ok(reports);
    }

    [HttpGet("getByID")]
    public async Task<IActionResult> GetByID(int reportID) {
        ReportModel? report = await context.Reports.FindAsync(reportID);
        return Ok(report);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReportModel report) {
        context.Add(report);
        await context.SaveChangesAsync(); 
        return  Created("", report);   
    }

    [HttpDelete] 
    public async Task<IActionResult> DeleteById(int reportID) {
        ReportModel? report = await context.Reports.FindAsync(reportID);
        if (report != null) {
            context.Remove(report);
            await context.SaveChangesAsync();
            return Ok();
        }
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(ReportModel report) {
        context.Entry(report).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok(report);
    }
}