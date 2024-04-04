using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Domain.Dtos.LivroDtos
{
    public class CreateLivroDto
    {
        [Required]
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        [Required]
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Genero { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public string Descricao { get; set; }
        public DateTime InicioDaLeitura { get; set; }
        public DateTime FimDaLeitura { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Paginas { get; set; }
        [Required]
        public string Analise { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 5)]
        public double Nota { get; set; }
        public string UrlImagemCapaDoLivro { get; set; }

        public CreateLivroDto()
        {
            SubTitulo = "";
            Editora = "";
            Genero = "";
            Descricao = "";
            UrlImagemCapaDoLivro = "";
        }
    }
}
