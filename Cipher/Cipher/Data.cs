using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    public class Data
    {
        private PublicKey key;
        private PrivateKey privateKey;
        private byte[] plainText;
        private List<BigInteger> cipherText;
        private List<int> lengths;
        private List<byte[]> blocks;
        private int add;

        public Data() 
        {
            this.key = new PublicKey(BigInteger.One, BigInteger.One);
            this.privateKey = new PrivateKey(BigInteger.One);

            this.plainText = new byte[1];
            plainText[0] = 0;

            cipherText = new List<BigInteger>();
            Lengths = new List<int>();
            Lengths.Add(0);

            Blocks = new List<byte[]>();
        }
        
        public PublicKey Key { get => key; set => key = value; }
        public PrivateKey PrivateKey { get => privateKey; set => privateKey = value; }
        public byte[] PlainText { get => plainText; set => plainText = value; }
        public List<BigInteger> CipherText { get => cipherText; set => cipherText = value; }
        public List<byte[]> Blocks { get => blocks; set => blocks = value; }
        public List<int> Lengths { get => lengths; set => lengths = value; }
        public int Add { get => add; set => add = value; }

        public string GetCipherText()
        {
            StringBuilder retValue = new StringBuilder();
            
            for(int i = 0; i < cipherText.Count; i++)
            {
                retValue.Append(BitConverter.ToString(cipherText[i].ToByteArray()).Replace("-", ""));
            }

            return retValue.ToString();
        }

        public string GetPlainText()
        {
            return BitConverter.ToString(plainText).Replace("-", "");
        }
    }
}
