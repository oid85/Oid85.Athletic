using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    public class TrainingEntity : BaseEntity
    {
        public string Name { get; set; }

        public int CountCycles { get; set; }

        public ICollection<ExerciseEntity> Exercises { get; set; }
    }
}
