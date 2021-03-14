using System.Collections.Generic;
using System.Linq;

namespace DevMan.BookStore.Domain.Models
{
    public class Book
    {
        /// <summary>
        /// Book uniq autogenerate id
        /// </summary>
        /// <example>1</example>
        public int Id { get; private set; }
        /// <summary>
        /// Book title
        /// </summary>
        /// <example>O alquimista</example>
        public string Title { get; private set; }
        /// <summary>
        /// Book brief description
        /// </summary>
        /// <example>Romance alegórico, O Alquimista segue um jovem pastor andaluz em sua viagem ao Egito, 
        /// depois de ter um sonho recorrente de encontrar tesouro lá.</example>
        public string BriefDescription { get; private set; }
        /// <summary>
        /// Book description
        /// </summary>
        /// <example>O alquimista segue a jornada de um pastor andaluz chamado Santiago. 
        /// Acreditando em um sonho recorrente de ser profético, 
        /// ele decide viajar para uma adivinha Romani em uma cidade próxima para descobrir seu significado. 
        /// A mulher interpreta o sonho como uma profecia dizendo ao menino que há um tesouro nas pirâmides no Egito.</example>
        public string Description { get; private set; }
        /// <summary>
        /// Book Authors
        /// </summary>
        public IEnumerable<Author> Authors { get; private set; }
        /// <summary>
        /// Book Categories
        /// </summary>
        public IEnumerable<Category> Categories { get; private set; }

        public static Book Create(
                            string title,
                            string briefDescription,
                            string description,
                            IEnumerable<Author> authors,
                            IEnumerable<Category> categories) =>
            new Book
            {
                Title = title,
                BriefDescription = briefDescription,
                Description = description,
                Authors = authors,
                Categories = categories
            };

        public static Book Create(int id) => new Book { Id = id };

        public void Update(string title = null,
                            string briefDescription = null,
                            string description = null,
                            IEnumerable<Author> authors = null,
                            IEnumerable<Category> categories = null)
        {
            Title = title ?? Title;
            BriefDescription = briefDescription ?? BriefDescription;
            Description = description ?? Description;
            Authors = authors ?? Authors;
            Categories = categories ?? Categories;
        }

    }
}
