using System.ComponentModel.DataAnnotations.Schema;

namespace Oid85.Athletic.Infrastructure.Entities.Base;

public class BaseEntity
{
    [Column("id")]
    public Guid Id { get; set; }
}