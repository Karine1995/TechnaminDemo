using System;

namespace DAL.Entities
{
    public class BaseEntity
    {
        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
