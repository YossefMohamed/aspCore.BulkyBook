using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

       
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage="Display Order Has To Be Between 1 and 100")]
        public string DisplayOrder{ get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;

         
    }
}
 