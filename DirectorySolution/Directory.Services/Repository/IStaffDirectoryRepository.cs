using Directory.Services.Models;

namespace Directory.Services.Repository
{
    public interface IStaffDirectoryRepository : IBaseRepository<StaffDirectory>
    {
        StaffDirectory GetFullStaffRecord(int Id);
    }
}
