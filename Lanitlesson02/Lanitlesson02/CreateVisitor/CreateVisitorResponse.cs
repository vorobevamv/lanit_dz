using System;
using System.Collections.Generic;

namespace Models
{
    public class CreateVisitorResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Result { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
