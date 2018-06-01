using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class RegisterCarrierViewModel
    {
        public string UserName { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string CarrierName { get; set; }
        public int CarrierType { get; set; }
        public string ContactName { get; set; }
        public string ContactMobileTelephoneNumber { get; set; }
        public string CountrySubdivisionCode { get; set; }
        public string RegisteredAddress { get; set; }
        public string PermitNumber { get; set; }
        public string UnifiedSocialCreditldentifier { get; set; }
        public string BusinessScope { get; set; }
        public decimal RegisteredCapital { get; set; }
        public string VehicleClassificationCode { get; set; }
        public string LicenseplateTypeCode { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleLicensePlateColor { get; set; }
        public string RoadTransportCertificateNumber { get; set; }
        public decimal VehicleLadenWeight { get; set; }
        public decimal VehicleTonnage { get; set; }
        public decimal? VehicleLength { get; set; }
        public decimal? VehicleWidth { get; set; }
        public decimal? VehicleHeight { get; set; }
        public string DriverName { get; set; }
        public int DriverGender { get; set; }
        public string IdentityDocumentNumber { get; set; }
        public string MobileTelephoneNumber { get; set; }
        public string QualificationCertificateNumber { get; set; }
    }


    public class RegisterShipperViewModel {
        public string UserName { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string ShipperName { get; set; }
        public string ShipperType { get; set; }
        public string ContactName { get; set; }
        public string ContactMobileTelephoneNumber { get; set; }
        public string CountrySubdivisionCode { get; set; }
        public string RegisteredAddress { get; set; }
        public decimal RegisteredCapital { get; set; }
        public string UnifiedSocialCreditldentifier { get; set; }

    }
}