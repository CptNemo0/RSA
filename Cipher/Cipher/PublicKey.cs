using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace RSA
{
    public class PublicKey
    {
        private BigInteger e;
        private BigInteger n;

        public PublicKey(BigInteger e, BigInteger n)
        {
            this.E = e;
            this.N = n;
        }

        public BigInteger E { get => e; set => e = value; }
        public BigInteger N { get => n; set => n = value; }
    }
}
