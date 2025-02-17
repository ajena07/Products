using System.ComponentModel.DataAnnotations;

namespace ProductsWebAPI.Model
{
    public class Product : BaseModel, IValidatableObject
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public string ProductClassification { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int Quantity { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (String.IsNullOrWhiteSpace(ProductName))
            {
                results.Add(new ValidationResult("Invalid Product Name"));
            }

            if (String.IsNullOrWhiteSpace(ProductType))
            {
                results.Add(new ValidationResult("Invalid Product Type"));
            }

            if (Quantity <= 0)
            {
                results.Add(new ValidationResult("Invalid Quantity Value"));
            }

            return results;
        }
    }
}
