using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyOfficeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyOfficeACPDController : ControllerBase
    {
        private readonly MyOfficeDbContext _context;

        public MyOfficeACPDController(MyOfficeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetACPDs()
        {
            var jsonResult = await _context.Database.ExecuteSqlRawAsync("EXEC usp_GetMyOfficeACPD");
            return Ok(jsonResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateACPD([FromBody] MyOfficeACPD acpd)
        {
            if (acpd == null)
            {
                return BadRequest("Invalid data.");
            }

            string jsonInput = JsonSerializer.Serialize(acpd);

            var param = new SqlParameter("@JsonData", jsonInput);
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_CreateMyOfficeACPD @JsonData", param);

            return CreatedAtAction(nameof(GetACPDs), new { id = acpd.ACPD_SID }, acpd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateACPD(string id, [FromBody] MyOfficeACPD acpd)
        {
            if (id != acpd.ACPD_SID)
            {
                return BadRequest("ID mismatch");
            }

            string jsonInput = JsonSerializer.Serialize(acpd);

            var param = new SqlParameter("@JsonData", jsonInput);
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_UpdateMyOfficeACPD @JsonData", param);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteACPD(string id)
        {
            var param = new SqlParameter("@ACPD_SID", id);
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_DeleteMyOfficeACPD @ACPD_SID", param);

            return NoContent();
        }
    }
}
