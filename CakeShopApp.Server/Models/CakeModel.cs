using System.ComponentModel.DataAnnotations;

namespace CakeShopApp.Server.Models
{
    public class CakeModel
    {
        [Key]
        public string Cake_Id { get; set; }
        public string Cake_Name { get; set; }
        public int Price { get; set; }
        public string Cake_Available { get; set; }
        public string Category { get; set; }
        public int Cake_Weight { get; set; }
        public string Cake_Type { get; set; }
        public string Cake_Description { get; set; }
        public string Cake_Image { get; set; }

    }
}
