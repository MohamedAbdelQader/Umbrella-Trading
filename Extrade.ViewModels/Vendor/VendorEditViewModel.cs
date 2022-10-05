using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UmbrellaTrading.Models;

namespace UmbrellaTrading.ViewModels
{


    public static partial class VendorExtension
    {

        public static Vendor ToModel(this VendorEditViewModel model)
        {


            return new Vendor()
            {
                BrandName = model.BrandName,
                VendorImage = model.VendorImage.Select(p => new VendorImage() {
                    Image = p
                }).ToList(),
               VendorStatus=model.VendorStatus,
                UserID = model.UserId,
                Balance = model.Balance,

            };


        }

    }
    public class VendorEditViewModel
    {
        public float Balance { get; set; }
        public string? BrandName { get; set; }
        public string? UserId { get; set; }
        public List<string>? VendorImage { get; set; }
        public VendorStatus VendorStatus { get; set; }
        public IFormFileCollection? ImageFile { get; set; }
        public bool IsDeleted { get; set; }


    }
}
