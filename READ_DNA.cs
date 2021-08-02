using System;
using System.Collections.Generic;

namespace PerleyHealthLib
{
    public class READ_DNA
    {
        private readonly Dictionary<string, string> binaryDict = new Dictionary<string, string>
        {
            { "00", "A"},
            { "01", "T"},
            { "10", "G"},
            { "11", "C"}
        };
        private readonly Dictionary<string, string> pairDict = new Dictionary<string, string>
        {
            { "A", "T"},
            { "T", "A"},
            { "G", "C"},
            { "C", "G"}
        };
        private readonly Dictionary<string, string> mPairDict = new Dictionary<string, string>
        {
            { "T", "A"},
            { "A", "U"},
            { "C", "G"},
            { "G", "C"}
        };
        private readonly Dictionary<string, string> tPairDict = new Dictionary<string, string>
        {
            { "A", "U"},
            { "U", "A"},
            { "G", "C"},
            { "C", "G"}
        };

        /// <summary>
        /// reads every 2 bits this way its simpler matching to the binary lib
        /// (5-3)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected string Read_Binary(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("There is no data.");

            string pair = string.Empty;
            List<string> pairs = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (pair.Length != 2)
                {
                    pair += input[i].ToString();
                }
                else
                {
                    pairs.Add(pair);
                    pair = string.Empty;
                    pair += input[i].ToString();
                }
            }

            string rtnval = string.Empty;
            for (int i = 0; i < pairs.Count; i++)
            {
                if (this.binaryDict.ContainsKey(pairs[i]))
                    rtnval += this.binaryDict[pairs[i]];
            }
            return rtnval;
        }

        /// <summary>
        /// Creates the second string in DNA strand (3-5)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected string ExtractPair(string input)
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
        protected string Read_tRNA(string input)
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
        protected string Read_mRNA(string input)
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

