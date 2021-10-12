using System.ComponentModel.DataAnnotations;

namespace PlataformService.Dtos
{
    public class PlataformCreateDto
    {
       
        [Required]
        public string Name { get; set; }    

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}