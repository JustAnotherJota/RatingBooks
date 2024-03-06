using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Data.Dtos.LivroDtos
{
    public class GetLivroDto
    {
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Genero { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public string Descricao { get; set; }
        public DateTime InicioDaLeitura { get; set; }
        public DateTime FimDaLeitura { get; set; }
        public string Status { get; set; }
        public int Paginas { get; set; }
        public string Analise { get; set; }
        public double Nota { get; set; }
        public string UrlImagemCapaDoLivro { get; set; }
    }
}
