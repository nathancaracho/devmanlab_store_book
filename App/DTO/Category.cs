namespace DevMan.BookStore.App.DTO
{
    public class CategoryRequest
    {
        /// <summary>
        /// Category name
        /// </summary>
        /// <example>Fantasy</example>
        public string Name { get; set; }

        /// <summary>
        /// Caregory description
        /// </summary>
        /// <example>Fantasy is a genre of literature that features magical 
        /// and supernatural elements that do not exist in the real world.</example>
        public string Description { get; set; }
    };

}