using System;

namespace DevMan.BookStore.App.DTO
{
    public class AuthorRequest
    {
        /// <summary>
        /// Author Name
        /// </summary>
        /// <example>Paulo coelho</example>
        public string Name { get; set; }
        /// <summary>
        /// Author birthday
        /// </summary>
        /// <example>1947-09-24</example>
        public DateTime Birthday { get; set; }
    }
}