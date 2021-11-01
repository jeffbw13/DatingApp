using API.Data;
using API.Entities;
using API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupesController : ControllerBase
    {
        static HttpClient client = new HttpClient();
        private readonly DataContext _context;
        public SupesController(DataContext context)
        {
            _context = context;

            if (client.BaseAddress == null) {
            client.BaseAddress = new Uri("https://o3m5qixdng.execute-api.us-east-1.amazonaws.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<Supervisor>>> GetSupes()
        {
        //List<Supervisor> supes = null;

        var supes = await client.GetFromJsonAsync<List<Supervisor>>("api/managers");
        //Console.WriteLine("Supes: ", supes[0].id.get());
        //HttpResponseMessage response = await client.GetAsync("api/managers");
        //if (response.IsSuccessStatusCode)
        //{
            //var jsonString = await response.Content.ReadAsStringAsync();
            //supes = JsonSerializer.Deserialize<List<Supervisor>(jsonString);
            // supes = JsonConvert.DeserializeObject<List<Supervisor>(jsonString);
        //}
        return supes;

            //return await _context.Users.ToListAsync();

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}