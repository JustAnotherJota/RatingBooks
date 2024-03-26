using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RatingBooks.Models
{
    public class Agendamento
    {
        [ForeignKey(name:nameof(Livro))] //O data anotatiton não preencheu na migration, foi realizado a inserção manual da Foreign Key na pasta Migrations
                                         //no arquivo 20240320193921_Criando tabelas, foi definido o Delete da FK como cascade para que caso um livro com agendamento seja deletado
                                         //o agendamento do mesmo também seja, o usuário será informado antes de deletar o livro sobre a exclusão de ambos
        [Required]
        public int LivroId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AgendamentoId { get; set; }
        [Required]
        public DateTime AgendamentoData { get; set; }
    }
}