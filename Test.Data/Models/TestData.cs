using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Models
{
    public class TestData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime TestDateTime { get; set; }
        public int TestInteger { get; set; }

        public bool TestBool { get; set; }
    }
}
