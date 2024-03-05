using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Data.Dtos.LivroDtos
{
    public class DeleteLivro
    {
        [Required]
        public int Id { get; set; }
    }
}
