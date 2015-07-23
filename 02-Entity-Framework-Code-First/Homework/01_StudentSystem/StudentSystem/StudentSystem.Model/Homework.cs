using System;
using System.Net.Mime;

namespace StudentSystem.Model
{
    public class Homework
    {
        public int Id { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }
    }
}
