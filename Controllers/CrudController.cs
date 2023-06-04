using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace crudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudController : ControllerBase
    {
        private static List<Crud> emp = new List<Crud>
        {
            new Crud
            {
                Id = 1,
                firstName = "Harry",
                lastName = "Marguire",
                email= "harry@gmail.com",
                dob = "2023-05-25T17:00:00.000Z",
                gender = "male",
                education = "Graduate",
                company = "MU",
                experience = 3,
                package = 12000000
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Crud>> GetCrud()
        {
            return Ok(emp);
        }

        [HttpPost]
        public ActionResult<Crud> CreateEmp(Crud newEmp)
        {
            // Generate a new unique ID for the new employee
            int newEmpId = emp.Max(e => e.Id) + 1;

            // Set the ID of the new employee
            newEmp.Id = newEmpId;

            // Add the new employee to the list
            emp.Add(newEmp);

            // Return the newly created employee
            return CreatedAtAction(nameof(GetCrud), new { id = newEmpId }, newEmp);
        }


        [HttpPut("{id}")]
        public ActionResult<Crud> UpdateEmp(int id, Crud updatedEmp)
        {
            var existingCrud = emp.FirstOrDefault(t => t.Id == id);
            if (existingCrud == null)
            {
                return NotFound();
            }

            existingCrud.firstName = updatedEmp.firstName;
            existingCrud.lastName = updatedEmp.lastName;
            existingCrud.email = updatedEmp.email;
            existingCrud.dob = updatedEmp.dob;
            existingCrud.gender = updatedEmp.gender;
            existingCrud.education = updatedEmp.education;
            existingCrud.company = updatedEmp.company;
            existingCrud.experience = updatedEmp.experience;
            existingCrud.package = updatedEmp.package;

            return Ok(existingCrud);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmp(int id)
        {
            var existingCrud = emp.FirstOrDefault(t => t.Id == id);
            if (existingCrud == null)
            {
                return NotFound();
            }

            emp.Remove(existingCrud);

            return NoContent();
        }
    }
}
