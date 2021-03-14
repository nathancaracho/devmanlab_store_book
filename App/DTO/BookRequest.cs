using System.Collections.Generic;

namespace DevMan.BookStore.App.DTO
{

    public class BookRequest
    {
        /// <summary>
        /// Book title
        /// </summary>
        /// <example>O alquimista</example>
        public string Title { get; set; }
        /// <summary>
        /// Book brief description
        /// </summary>
        /// <example>Romance alegórico, O Alquimista segue um jovem pastor andaluz em sua viagem ao Egito, 
        /// depois de ter um sonho recorrente de encontrar tesouro lá.</example>
        public string BriefDescription { get; set; }
        /// <summary>
        /// Book description
        /// </summary>
        /// <example>O alquimista segue a jornada de um pastor andaluz chamado Santiago.
        ///  Acreditando em um sonho recorrente de ser profético, 
        /// ele decide viajar para uma adivinha Romani em uma cidade próxima para descobrir seu significado. 
        /// A mulher interpreta o sonho como uma profecia dizendo ao menino que há um tesouro nas pirâmides no Egito.</example>
        public string Description { get; set; }
        /// <summary>
        /// Authors id
        /// </summary>
        /// <example>1</example>
        public IEnumerable<int> Authors { get; set; }
        /// <summary>
        /// Categories id
        /// </summary>
        /// <example>1</example>
        public IEnumerable<int> Categories { get; set; }
    }
}