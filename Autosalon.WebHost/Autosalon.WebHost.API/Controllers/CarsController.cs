using Autosalon.WebHost.Core.Repositories;
using Autosalon.WebHost.Infrastrucure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autosalon.WebHost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AutosalonContext _context;
        private readonly CarRepository carRepository;

        public CarsController(AutosalonContext context)
        {
            _context = context;
            carRepository = new CarRepository(context);
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            //return await _context.Car.ToListAsync();
            return await Task.Run(() => carRepository.GetItems().ToList());
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await Task.Run(() => carRepository.GetItem(id)); //_context.Car.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            if (!this.IsCarExists(id))
            {
                return NotFound();
            }

            carRepository.UpdateItem(car);

            try
            {
                await Task.Run(() => carRepository.SaveChanges());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsCarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            carRepository.CreateItem(car);
            //_context.Car.Add(car);

            await Task.Run(() => carRepository.SaveChanges()); ;
            //await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            if (!this.IsCarExists(id))
            {
                return NotFound();
            }

            await Task.Run(() => carRepository.DeleteItem(id));

            //_context.Car.Remove(car);
            //await Task.Run(() => carRepository.SaveChanges()); // _context.SaveChangesAsync();

            return Ok();
        }

        private bool IsCarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}
