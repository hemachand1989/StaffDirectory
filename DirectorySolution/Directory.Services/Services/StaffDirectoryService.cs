using System.Collections.Generic;
using System.Linq;
using Directory.Services.Models;
using Directory.Services.Repository;

namespace Directory.Services.Services
{
    public class StaffDirectoryService : IStaffDirectoryService
    {
        private readonly IStaffDirectoryRepository _staffDirectoryRepository;
        public StaffDirectoryService(IStaffDirectoryRepository staffDirectoryRepository)
        {
            _staffDirectoryRepository = staffDirectoryRepository;
        }

        public bool CreateStaffRecord(StaffDirectory Item)
        {
            return _staffDirectoryRepository.Insert(Item);
        }

        public bool DeleteStaffRecord(int Id)
        {
            return _staffDirectoryRepository.Delete(_staffDirectoryRepository.Single(Id));
        }

        public IEnumerable<StaffDirectory> GetAllStaffData()
        {
            return _staffDirectoryRepository.GetAll();
        }

        public StaffDirectory GetStaffById(int Id)
        {
            return _staffDirectoryRepository.GetFullStaffRecord(Id);
        }

        public StaffDirectory GetStaffByName(string Name)
        {
            return _staffDirectoryRepository.GetAll().FirstOrDefault(i => i.Name.Contains(Name));
        }

        public bool UpdateStaffRecord(StaffDirectory Item)
        {
            return _staffDirectoryRepository.Update(Item);
        }
    }
}
