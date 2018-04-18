using System;
using System.Collections.Generic;
using System.IO;
using Directory.Services.Models;
using Directory.Services.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Directory.Services.Controllers
{
    [Produces("application/json")]
    [Route("api/Staff")]
    [EnableCors("AllowAllHeaders")]
    public class StaffDirectoryController : Controller
    {
        private readonly IStaffDirectoryService _staffDirectoryService;
        private readonly ILogger _logger;

        public StaffDirectoryController(IStaffDirectoryService staffDirectoryService, ILogger<StaffDirectoryController> logger)
        {
            _staffDirectoryService = staffDirectoryService;
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<StaffDirectory> Get()
        {
            _logger.Log(LogLevel.Information, "Request recieved to fetch data for all the records", null);
            return _staffDirectoryService.GetAllStaffData();
        }

       
        [HttpGet("{id:int}")]
        public StaffDirectory Get(int id)
        {
            _logger.Log(LogLevel.Information, "Request recieved to fetch data for Record " + id, null);
            return _staffDirectoryService.GetStaffById(id);
        }

        [HttpGet("{name}", Name = "Get")]
        public StaffDirectory Get(string name)
        {
            _logger.Log(LogLevel.Information, "Request recieved to fetch data for Record " + name, null);
            return _staffDirectoryService.GetStaffByName(name);
        }

        [HttpPost]
        public void Post([FromBody]StaffDirectory staffDirectoryRecord)
        {
            _logger.Log(LogLevel.Information, "Request recieved to create a new Staff Record", null);

            var record = JsonConvert.SerializeObject(staffDirectoryRecord);
            System.IO.File.WriteAllText(Path.Combine(Path.GetTempPath(), "log_" + Guid.NewGuid() + ".txt"), record);

            var Id = _staffDirectoryService.CreateStaffRecord(staffDirectoryRecord);
            _logger.Log(LogLevel.Information, "Creation of new Staff Record is completed", null);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]StaffDirectory staffDirectoryRecord)
        {
            _logger.Log(LogLevel.Information, "Request Recieved to update" + id.ToString(), null);
            var staffInfo = _staffDirectoryService.GetStaffById(id);

            _staffDirectoryService.UpdateStaffRecord(staffDirectoryRecord);
            _logger.Log(LogLevel.Information, "Updation of  Staff Record is completed", null);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.Log(LogLevel.Information, "Request recieved to delete " + id.ToString(), null);
            _staffDirectoryService.DeleteStaffRecord(id);
            _logger.Log(LogLevel.Information, "Deletion of  Staff Record is completed", null);
        }
    }
}
