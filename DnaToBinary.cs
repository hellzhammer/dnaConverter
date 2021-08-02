namespace PerleyHealthLib
{
    public class DnaToBinary : WRITE_DNA
    {
        public (string binaryConvert, string dnaPair, string mrna, string trna) GetAllSequences(string input)
        {
            string rtn4 = this.Write_tRNA(input);
            string rtn3 = this.Write_mRNA(rtn4);
            string rtn2 = this.ExtractDNA(rtn3);
            string rtn1 = this.Write_Binary(rtn2);

            return (rtn1, rtn2, rtn3, rtn4);
        }

        public string GetPair(string dna)
        {
            return this.ExtractDNA(dna);
        }

        public string From_Binary(string input)
        {
            return this.Write_Binary(input);
        }

        public string ConvertTo_MRNA(string dnaPair)
        {
            return this.Write_mRNA(dnaPair);
        }

        public string ConvertTo_TRNA(string mrna)
        {
            return this.Write_tRNA(mrna);
        }

        public (string dnaPair, string mrna, string trna) GetSequence(string nonBinary)
        {
            string rtn3 = this.Write_tRNA(nonBinary);
            string rtn2 = this.Write_mRNA(rtn3);
            string rtn1 = this.ExtractDNA(rtn2);

            return (rtn1, rtn2, rtn3);
        }
    }
}
