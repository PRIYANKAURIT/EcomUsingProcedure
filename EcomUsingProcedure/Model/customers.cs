using System.ComponentModel.DataAnnotations;

namespace EcomUsingProcedure.Model
{
    public class customers
    {
        public int cust_id { get; set; }
        public string? cust_name { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? cust_mobile { get; set; }
        public string? cust_email { get; set; }
        public string? passwords { get; set; }
        public gender cust_gender { get; set; }
        public int cust_billing_address_id { get; set; }
        public int cust_shipping_address_id { get; set; }
        public DateTime cust_account_created { get; set; }
        public bool cust_is_deleted { get; set; }
        public string? flag { get; set; }
    }

    public enum gender
    {
        Male, Female, Others
    }

    public class DtoRegistration
    {
        public int cust_id { get; set; }
        public string? cust_name { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? cust_mobile { get; set; }
        public string? cust_email { get; set; }
        public string? passwords { get; set; }
        public gender cust_gender { get; set; }
    }

    public class DtoLogin
    {
        public string? cust_email { get; set; }
        public string? passwords { get; set; }
    }
}

