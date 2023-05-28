using Application;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EFCoreDemoController : ControllerBase
    {
        private readonly ILogger<EFCoreDemoController> _logger;
        private readonly IEmployeeRepository _repo;

        public EFCoreDemoController(ILogger<EFCoreDemoController> logger, IEmployeeRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<EmployeeViewModel> Get(Guid id)
        {
            var entity = _repo.Get(id);
            return Ok(entity);
        }

        [HttpGet]
        public ActionResult<EmployeeViewModel> GetFull(Guid id)
        {
            var entity = _repo.GetFull(id);
            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<EmployeeViewModel> Insert(EmployeeModel model)
        {
            return Ok(_repo.Insert(model));
        }

        [HttpPost]
        public ActionResult<EmployeeViewModel> AddDepartments(Guid employeeId, List<Guid> departmentIds)
        {
            return Ok(_repo.AddDepartments(employeeId, departmentIds));
        }

        [HttpPut]
        public ActionResult<EmployeeViewModel> Update(EmployeeModel model)
        {
            return Ok(_repo.Update(model));
        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            return Ok(_repo.Delete(id));
        }

        [HttpDelete]
        public ActionResult RemoveDepartments(Guid employeeId, List<Guid> departmentIds)
        {
            return Ok(_repo.RemoveDepartments(employeeId, departmentIds));
        }
    }
}