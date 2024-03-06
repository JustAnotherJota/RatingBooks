using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Data.Dtos.LivroDtos
{
    public class DeleteLivroDto
    {
        [Required]
        public int Id { get; set; }
    }
}
