using System;
using System.Collections.Generic;

namespace PerleyHealthLib
{
    public class WRITE_DNA
    {
        private readonly Dictionary<string, string> binaryDict = new Dictionary<string, string>
        {
            {"A", "00"},
            {"T", "01"},
            {"G", "10"},
            {"C", "11"}
        };
        private readonly Dictionary<string, string> pairDict = new Dictionary<string, string>
        {
            { "T", "A"},
            { "A", "T"},
            { "C", "G"},
            { "G", "C"}
        };
        private readonly Dictionary<string, string> mPairDict = new Dictionary<string, string>
        {
            { "A", "T"},
            { "U", "A"},
            { "G", "C"},
            { "C", "G"}
        };
        private readonly Dictionary<string, string> tPairDict = new Dictionary<string, string>
        {
            { "U", "A"},
            { "A", "U"},
            { "C", "G"},
            { "G", "C"}
        };

        /// <summary>
        /// reads every 2 bits this way its simpler matching to the binary lib
        /// (5-3)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected string Write_Binary(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("There is no data.");

            string rtnval = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (this.binaryDict.ContainsKey(input[i].ToString()))
                    rtnval += this.binaryDict[input[i].ToString()];
            }
            return rtnval;
        }

        /// <summary>
        /// Creates the second string in DNA strand (3-5)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected string ExtractDNA(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("There is no data.");

            string rtnval = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (this.pairDict.ContainsKey(input[i].ToString()))
                    rtnval += this.binaryDict[input[i].ToString()];
            }
            return rtnval;
        }

        /// <summary>
        /// converts into tRNA sequence
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected string Write_tRNA(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("There is no data.");

            string rtnval = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (this.tPairDict.ContainsKey(input[i].ToString()))
                    rtnval += this.tPairDict[input[i].ToString()];
            }
            return rtnval;
        }

        /// <summary>
        /// Gets the mRNA sequence
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected string Write_mRNA(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("There is no data.");

            string rtnval = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (this.mPairDict.ContainsKey(input[i].ToString()))
                    rtnval += this.mPairDict[input[i].ToString()];
            }
            return rtnval;
        }

        protected string[] ExtractCodon(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("There is no data.");

            string pair = string.Empty;
            List<string> rtnval = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (pair.Length != 3)
                {
                    pair += input[i].ToString();
                }
                else
                {
                    rtnval.Add(pair);
                    pair = string.Empty;
                    pair += input[i].ToString();
                }
            }
            return rtnval.ToArray();
        }
    }
}
