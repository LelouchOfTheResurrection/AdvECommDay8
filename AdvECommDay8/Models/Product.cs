#region Usings

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace AdvECommDay8.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Category")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}