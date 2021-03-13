namespace Domain.Models
{
    public class Category
    {
        /// <summary>
        /// uniq and incremental ID
        /// </summary>
        /// <example>1</example>
        public int Id { get; private set; }
        /// <summary>
        /// uniq Category name
        /// </summary>
        /// <example>Fantasy</example>
        public string Name { get; private set; }
        /// <summary>
        /// Category description
        /// </summary>
        /// <example>Fantasy is a genre of literature that features magical and supernatural elements </example>
        public string Description { get; private set; }

        /// <summary>
        /// Create category with name and description
        /// </summary>
        /// <param name="name">category name</param>
        /// <param name="description">category description</param>
        /// <returns>new Category</returns>
        public static Category Create(string name, string description) =>
            new Category
            {
                Name = name,
                Description = description
            };
        /// <summary>
        /// Create catogory with Id
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>new Category</returns>
        public static Category Create(int id) => new Category { Id = id };

        /// <summary>
        /// upadate category
        /// </summary>
        /// <param name="name">category name</param>
        /// <param name="description">category description</param>
        /// <returns> updated category </returns>
        public void Update(string name = null, string description = null) =>
           (Name, Description) = (name ?? Name, description ?? Description);


    }
}