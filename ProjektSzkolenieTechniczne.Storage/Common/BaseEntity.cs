using System.ComponentModel.DataAnnotations;


namespace SzkolenieTechniczneStorage.Common
{
    public abstract class BaseEntity
    {

        [Key]
        public long Id { get; set; }
    }
}
