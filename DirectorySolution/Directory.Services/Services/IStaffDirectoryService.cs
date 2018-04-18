using Directory.Services.Models;
using System.Collections.Generic;

namespace Directory.Services.Services
{
    public interface IStaffDirectoryService
    {
        IEnumerable<StaffDirectory> GetAllStaffData();

        StaffDirectory GetStaffById(int Id);

        StaffDirectory GetStaffByName(string Name);

        bool CreateStaffRecord(StaffDirectory Item);

        bool UpdateStaffRecord(StaffDirectory Item);

        bool DeleteStaffRecord(int Id);
    }
}
