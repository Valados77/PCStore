using System.ComponentModel.DataAnnotations.Schema;

namespace PCStore_MVC.Models.ModelDB
{
    public class Image
    {
        public int Id { get; set; }

        public string ImageTitle { get; set; } = null!;

        public string Format { get; set; } = null!;

        [NotMapped]
        public string Name => $"{ImageTitle}.{Format}";
    }
}
