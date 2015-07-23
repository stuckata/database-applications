using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Model
{
    public class Resource
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public Uri Url { get; set; }
    }
}
