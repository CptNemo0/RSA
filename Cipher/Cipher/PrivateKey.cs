using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace RSA
{
    public class PrivateKey
    {
        private BigInteger d;

        public BigInteger D { get => d; set => d = value; }

        public PrivateKey(BigInteger d)
        {
            this.D = d;
        }
    }
}
