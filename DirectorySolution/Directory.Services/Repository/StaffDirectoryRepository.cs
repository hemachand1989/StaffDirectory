using System;
using System.Linq;
using Directory.Services.Data;
using Directory.Services.Models;
using Microsoft.Extensions.Logging;

namespace Directory.Services.Repository
{
    public class StaffDirectoryRepository : BaseRepository<StaffDirectory>, IStaffDirectoryRepository
    {
        private readonly ILogger _logger;
        public StaffDirectoryRepository(DirectoryDBContext dbContext,ILogger<StaffDirectoryRepository> logger) : base(dbContext,logger)
        {
            _logger = logger;
        }
        public override bool Insert(StaffDirectory newItem)
        {
            newItem.CreatedDate = DateTime.Now;
            newItem.UpdatedDate = DateTime.Now;
            return base.Insert(newItem);
        }

        public override bool Update(StaffDirectory Item)
        {
            Item.UpdatedDate = DateTime.Now;
            return base.Update(Item);
        }

        public StaffDirectory GetFullStaffRecord(int Id)
        {
            var staffRecord = base.SingleOrDefault(Id);
            staffRecord.ReporteeList = base.GetAll().ToList().FindAll(i => i.StaffDirectoryId == Id).ToList();
            return staffRecord;
        }

        
    }
}
