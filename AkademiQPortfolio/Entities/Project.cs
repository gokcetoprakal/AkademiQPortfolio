using System;
using System.Collections.Generic;

namespace AkademiQPortfolio.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
