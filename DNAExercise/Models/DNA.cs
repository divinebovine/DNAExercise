using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DNAExercise.Models
{
    public class DNA
    {
        private string data;
        public string Data
        {
            get { return data; }
            set { data = Repair(value); }
        }

        public DNA()
        { 
        }

        public DNA(string data)
        {
            this.Data = data;
        }

        private string Repair(string data)
        {
            string result;

            // Remove invalid characters
            result = Regex.Replace(data, @"[^ACTGactg]", string.Empty);            

            // Convert characters to upper case
            result = result.ToUpper();

            return result;
        }
    }
}