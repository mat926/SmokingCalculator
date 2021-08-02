using System;
using System.Collections.Generic;
using System.Text;

namespace SmokingCalculator.Models
{
    public class Achievement
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public DateTime CompletedDate { get; set; }
        public Boolean Completed { get; set; }
        public string ImageUrl { get; set; }

        //public override string ToString()
        //{
        //    return Title;
        //}
    }
}
