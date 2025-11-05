using Oid85.Athletic.Core.Models.Base;

namespace Oid85.Athletic.Core.Models
{
    public class Exercise : BaseModel
    {
        public int CountIterations { get; set; }
        public int Order { get; set; }
        public ExerciseTemplate ExerciseTemplate { get; set; } = new();
        public Training Training { get; set; } = new();
    }
}
