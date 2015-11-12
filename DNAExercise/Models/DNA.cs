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

        public string Feedback { get; set; }

        public DNA()
        {
            Data = string.Empty;
            Feedback = string.Empty;
        }

        public DNA(string data = "", string feedback = "")
        {
            this.Data = data;
            this.Feedback = feedback;
        }

        private string Repair(string data)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(data))
            {
                // Remove invalid characters
                result = Regex.Replace(data, @"[^ACTGactg]", string.Empty);

                // Convert characters to upper case
                result = result.ToUpper();
            }

            return result;
        }
    }
}