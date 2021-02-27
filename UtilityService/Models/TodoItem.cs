
namespace UtilityService.Models
{
    public class TodoItem
    {
        /// <summary>
        /// Todo ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Todo Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Todo IsComplete
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
