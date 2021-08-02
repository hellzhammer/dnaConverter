namespace PerleyHealthLib
{
    public class BinaryToDNA : READ_DNA
    {
        public (string binaryConvert, string dnaPair, string mrna, string trna) GetAllSequences(string binary)
        {
            string rtn1 = this.Read_Binary(binary);
            string rtn2 = this.ExtractPair(rtn1);
            string rtn3 = this.Read_mRNA(rtn2);
            string rtn4 = this.Read_tRNA(rtn3);

            return (rtn1, rtn2, rtn3, rtn4);
        }

        public string GetPair(string dna)
        {
            return this.ExtractPair(dna);
        }

        public string From_Binary(string binary)
        {
            return this.Read_Binary(binary);
        }

        public string ConvertTo_MRNA(string dnaPair)
        {
            return this.Read_mRNA(dnaPair);
        }

        public string ConvertTo_TRNA(string mrna)
        {
            return this.Read_tRNA(mrna);
        }

        public (string dnaPair, string mrna, string trna) GetSequence(string nonBinary)
        {
            string rtn1 = this.ExtractPair(nonBinary);
            string rtn2 = this.Read_mRNA(rtn1);
            string rtn3 = this.Read_tRNA(rtn2);

            return (rtn1, rtn2, rtn3);
        }
    }
}
