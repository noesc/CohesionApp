using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CohesionApp.Data.Entities
{
    public abstract class BaseEntity<T>
    {
        [Key]
        [Column(TypeName = "char(36)")]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public abstract void CopyFrom(T entity);
    }
}
