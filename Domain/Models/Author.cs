using System;

namespace DevMan.BookStore.Domain.Models
{
    public class Author
    {
        /// <summary>
        /// uniq, autogerate and incremental Author Id
        /// </summary>
        /// <example>1</example>
        public int Id { get; private set; }
        /// <summary>
        /// Author Name
        /// </summary>
        /// <example>Paulo coelho</example>
        public string Name { get; private set; }
        /// <summary>
        /// Author birthday
        /// </summary>
        /// <example>1947-09-24</example>
        public DateTime Birthday { get; private set; }

        /// <summary>
        /// Author age
        /// </summary>
        /// <example>74</example>
        public int Age => DateTime.Now.Year - Birthday.Year;

        public static Author Create(string name, DateTime birthday) =>
            new Author
            {
                Name = name,
                Birthday = birthday
            };

        public static Author Create(int id) => new Author { Id = id };

        public void Update(string name = null, DateTime? birthday = null) =>
            (Name, Birthday) = (name ?? Name, birthday ?? Birthday);
    }
}