using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quitr2.Models.User
{
    public class UserModel
    {
        public UserModel()
        {

            UserCounters = new List<UserDeletedCountersModel>();
            Deviations = new List<DeviationsModel>();
            ProductContents = new List<ProductContentsModel>();
            Substitute = new List<SubstituteModel>();

        }

        public DateTime stopDate { get; set; }
        public int? units { get; set; }
        public int? cost { get; set; }
        public int? addictionType { get; set; }
        public int? addictionProductType { get; set; }
        public int userprefId { get; set; }
        public bool? counterDeleted { get; set; }
        public bool? sharing { get; set; }
        public int? currentMood { get; set; }
        public bool isUsingSubstitute { get; set; }
        public string substituteMood { get; set; }
        public int? substituteDayAmount { get; set; }
        public int? substituteId { get; set; }
        public string userId { get; set; }
        public string addictionTypeName { get; set; }
        public bool? substituteUser { get; set; }
        public int Substituteamount { get; set; }

        public List<DeviationsModel> Deviations { get; set; }
        public List<ProductContentsModel> ProductContents { get; set; }
        public List<UserDeletedCountersModel> UserCounters { get; set; }
        public List<SubstituteModel> Substitute { get; set; }
    }

    public class SubstituteModel
    {
        public int SubstituteId { get; set; }
    }


    public class UserDeletedCountersModel
    {
        public DateTime stopDate { get; set; }
        public int? units { get; set; }
        public int? cost { get; set; }
        public int addictionType { get; set; }
        public int? addictionProductType { get; set; }
        public int userprefId { get; set; }
        public bool counterDeleted { get; set; }
        public DateTime? deletedDate { get; set; }

    }

    public class DeviationsModel
    {
        public DateTime Dev_start { get; set; }
        public DateTime Dev_stop { get; set; }
    }

    public class ProductContentsModel
    {
        public string Unit { get; set; }
        public decimal Amount { get; set; }
        public string ContentName { get; set; }
    }

    public class SetupModel
    {
        public SetupModel()
        {
            AddicitionTypes = new List<AddictionTypesModel>();
            ProductListing = new List<ProductListingModel>();

        }

        public List<AddictionTypesModel> AddicitionTypes { get; set; }
        public List<ProductListingModel> ProductListing { get; set; }
        public int AddictionType { get; set; }
        public string UserId { get; set; }
        public int Nmbrperday { get; set; }
        public int Costperday { get; set; }
        public int ProductPost { get; set; }
        public bool UsingSubstitute {get; set;}
        public int Substituteamount { get; set; }
    }


    public class AddictionTypesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductListingModel
    {
        public int Id { get; set; }
        public int? ProductType { get; set; }
        public string Name { get; set; }
    }

    public class MoodModel
    {
        public DateTime timestamp { get; set; }
        [Required]
        public int userprefid { get; set; }
        [Required]
        public int mood { get; set; }
    }


}


