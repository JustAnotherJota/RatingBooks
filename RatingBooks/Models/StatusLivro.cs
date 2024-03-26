namespace RatingBooks.Models
{
    public class StatusLivro
    {
        public string[] statusLivroArray;
        public StatusLivro()
        {
                this.statusLivroArray = new string[] { "Começo", "Meio", "Final", "Finalizado" };
        }
    }
}
