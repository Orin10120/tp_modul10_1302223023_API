
using Microsoft.AspNetCore.Mvc;

namespace tp_modul10.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa> { 
            new Mahasiswa("Rindang Bani Isyan", "1302223023"),
            new Mahasiswa("Kevin Albany Junaid", "1302223027"),
            new Mahasiswa("Muhammad Farhan Ismali Fentarto", "1302220046"),
            new Mahasiswa("Adrian Fahren Setiawan", "1302220018"),
            new Mahasiswa("Adib Faizulhaq Armadhani", "1302223110")
        };

       
        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
        {
            return mahasiswaList;
        }


        [HttpGet("{id}")]
        public Mahasiswa Get(int id)
        {
            return mahasiswaList[id];
        }

        [HttpPost]
        public ActionResult Post([FromBody] Mahasiswa mahasiswa)
        {
            mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new{id = mahasiswaList.IndexOf(mahasiswa)} , mahasiswa);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            mahasiswaList.RemoveAt(id);
            return NoContent();
        }
    }
}
