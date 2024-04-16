namespace RatingBooks.Domain.Entidades
{
    public class StatusLivro
    {
        public string[] statusLivroArray;
        public StatusLivro()
        {
            statusLivroArray = new string[] { "COMEÇO", "MEIO", "FINAL", "FINALIZADO" };
        }
    }
}
