using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace RSA
{
    public class KeyPair
    {
        private readonly int bitLen = 1024;
        private BigInteger p;
        private BigInteger q;
        private BigInteger n;
        private BigInteger CTF;
        private BigInteger e;
        private BigInteger d;
        private Cipher cipher;

        public KeyPair()
        {
            SecureRandom random = new SecureRandom();
            Utils slh = new Utils();
            
            do
            {
                this.p = new BigInteger(bitLen, 30, random);
                this.q = new BigInteger(bitLen, 30, random);
                this.N = p.Multiply(q);
            } while (N.BitLength != 2048);
            
            this.CTF = slh.CTF(p, q);
            this.E = new BigInteger("65537");
            //this.E = new BigInteger(n.BitLength, 30, random);
            this.D = slh.CalculateD(E, CTF);
            this.cipher = new Cipher();

            this.p = null;
            this.q = null;
            this.CTF = null;
            random = null;
        }

        public BigInteger N { get => n; set => n = value; }
        public BigInteger E { get => e; set => e = value; }
        public BigInteger D { get => d; set => d = value; }

        /*
        public BigInteger encrypt(BigInteger pt)
        {
            return cipher.encrypt(e, n, pt);
        }

        public BigInteger decrypt(BigInteger pt) 
        {
            return cipher.decrypt(d, n, pt);
        }
        */
    }
}
