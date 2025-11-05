using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    public class ExerciseTemplateEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Equipment { get; set; }
    }
}
