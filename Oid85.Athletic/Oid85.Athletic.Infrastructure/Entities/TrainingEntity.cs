using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    public class TrainingEntity : BaseEntity
    {
        [Column("name"), MaxLength(500)]
        public string Name { get; set; } = string.Empty;

        [Column("count_cycles")]
        public int CountCycles { get; set; }     
    }
}
