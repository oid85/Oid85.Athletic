using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    public class ExerciseTemplateEntity : BaseEntity
    {
        [Column("name"), MaxLength(500)]
        public string Name { get; set; } = string.Empty;

        [Column("equipment"), MaxLength(500)]
        public string Equipment { get; set; } = string.Empty;
    }
}
