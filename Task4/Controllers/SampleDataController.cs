namespace Task4.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using Task3.DAL.Entities;
    using Task3.DAL.Interfaces;

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IUnitOfWork _uow;

        public SampleDataController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("search/{searchStr}")]
        public IEnumerable<BusinessEntity1> SampleData(string searchStr)
        {
            return _uow.BusinessEntities1Repo.GetAll().Where(x => x.Name.Contains(searchStr));
        }

        [HttpPost("save")]
        public IActionResult Save([FromBody] BusinessEntity1 item)
        {
            // emulation db-save
            _uow.BusinessEntities1Repo.Update(item);
            return Ok();
        }
    }
}