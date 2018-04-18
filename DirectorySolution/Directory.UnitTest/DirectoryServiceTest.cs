using Directory.Services.Models;
using Directory.Services.Repository;
using Directory.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Directory.UnitTest
{
   
    public class DirectoryServiceTest
    {
        public DirectoryServiceTest()
        {

        }

        [Fact]
        public void ReturnFalseGivenEmptyDirectoryModelForPost()
        {
            var directoryRepo = new Mock<IStaffDirectoryRepository>();
            directoryRepo.Setup(x => x.Insert(new Services.Models.StaffDirectory())).Returns(false);
            var _staffService = new StaffDirectoryService(directoryRepo.Object);
            var result = _staffService.CreateStaffRecord(new Services.Models.StaffDirectory());
            Assert.False(result, "Directory Model Should not be Empty");
        }

        [Fact]
        public void ReturnTrueGivenValidDirectoryModelForPost()
        {
            var directoryRepo = new Mock<IStaffDirectoryRepository>();
            var model = new Services.Models.StaffDirectory()
            {
               Name = "hem",
               OfficeNumber = "1412313123",
               EmailId = "asdfa@m.com"
            };
            directoryRepo.Setup(x => x.Insert(model)).Returns(true);
            var _StaffService = new StaffDirectoryService(directoryRepo.Object);
            var result = _StaffService.CreateStaffRecord(model);
            Assert.True(result, "Directory Model Is Valid");
        }

        [Fact]
        public void ReturnEmptyListWhenNoDataForGet()
        {
            var direcotryRepo = new Mock<IStaffDirectoryRepository>();
            direcotryRepo.Setup(x => x.GetAll()).Returns((IEnumerable<StaffDirectory>)null);
            var _directoryService = new StaffDirectoryService(direcotryRepo.Object);
            var result = _directoryService.GetAllStaffData();
            Assert.True(result == null, "Direcotry Model Is Valid");
        }
       
    }
}
