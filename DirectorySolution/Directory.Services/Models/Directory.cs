using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directory.Services.Models
{
    public class Directory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OfficeNumber { get; set; }

        public string MobileNumber { get; set; }

        public string EmailId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }


    public class StaffDirectory : Directory
    {
        //Using Nullable Foreign Key to avoid Circular relationship error.
        public int? StaffDirectoryId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public StaffRole Role { get; set; }

        public int Apprecitations { get; set; }

        //Only get attribute as this was not used to set the data.
        public virtual List<StaffDirectory> ReporteeList { get; set; }

        //Self relation to Directory as the reporter is also Staff.
        public virtual StaffDirectory Reporter { get; set; }
    }


    public enum StaffRole
    {
        Manager,
        SoftwareArchitect,
        QualityAnalyst,
        Developer
    }
}
