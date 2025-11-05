using Oid85.Athletic.Core.Models.Base;

namespace Oid85.Athletic.Core.Models
{
    public class Training : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public List<Exercise> Exercises { get; set; } = [];
        public int CountCycles { get; set; }
    }
}
