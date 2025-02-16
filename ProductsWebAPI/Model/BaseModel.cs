using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductsWebAPI.Model
{
    public class BaseModel
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime CreateDateTime { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime UpdateDateTime { get; set; } 
    }
}
