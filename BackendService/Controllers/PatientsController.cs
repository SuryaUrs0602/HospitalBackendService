using BackendService.Helpers;
using BackendService.Models;
using BackendService.Models.DTO;
using BackendService.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PatientDTO patientdto)
        {
            var patient = new Patient
            {
                FullName = patientdto.FullName,
                PhoneNumber = patientdto.PhoneNumber,
                Email = patientdto.Email,
                Location = patientdto.Location
            };

            await _patientService.AddData(patient);
            return Created();
        }

        [HttpPut("PatientID")]
        public async Task<IActionResult> Update(int PatientID, UpdatePatientDTO patientdto)
        {
            var patient = new Patient
            {
                PhoneNumber = patientdto.PhoneNumber,
                Email = patientdto.Email,
                Location = patientdto.Location
            };

            await _patientService.EditData(PatientID, patient);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int PatientID)
        {
            await _patientService.DeleteData(PatientID);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datas = await _patientService.GetAllData();

            if (datas == null)
                throw new DomainBadRequest("Could not get the datas due to some problem");

            return Ok(datas);
        }

        [HttpGet("PatientID")]
        public async Task<IActionResult> GetByID(int PatientID)
        {
            var data = await _patientService.GetData(PatientID);

            if (data == null)
                throw new DomainNotFoundException("The data your are searching is not found");

            return Ok(data);
        }

        [HttpGet("Location")]
        public async Task<IActionResult> LocationMethod(string Location)
        {
            var datas = await _patientService.GetPatientsByLoaction(Location);

            if (datas == null)
                throw new DomainBadRequest("Could not get the datas due to some problem");

            return Ok(datas);
        }

        [HttpGet("sort/asc")]
        public async Task<IActionResult> SortAscending()
        {
            var datas = await _patientService.SortByNameAsc();

            if (datas == null)
                throw new DomainBadRequest("Could not get the datas due to some problem");

            return Ok(datas);
        }

        [HttpGet("sort/desc")]
        public async Task<IActionResult> SortDescending()
        {
            var datas = await _patientService.SortByNameDesc();

            if (datas == null)
                throw new DomainBadRequest("Could not get the datas due to some problem");

            return Ok(datas);
        }

        [HttpGet("groupby/Location")]
        public async Task<IActionResult> GroupByMethod()
        {
            var datas = await _patientService.GroupByLocation();

            if (datas == null)
                throw new DomainBadRequest("Could not get the datas due to some problem");

            return Ok(datas);
        }
    }
}
