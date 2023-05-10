using Org.BouncyCastle.Math;

namespace RSA
{
    public class Cipher
    {
        public Cipher() { }

        public BigInteger encrypt(BigInteger e, BigInteger n, BigInteger ct)
        {
            return ct.ModPow(e, n);
        }

        public BigInteger decrypt(BigInteger d, BigInteger n, BigInteger ct)
        {
            return ct.ModPow(d, n);
        }
    }
}
