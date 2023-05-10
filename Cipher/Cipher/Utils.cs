using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace RSA
{
    public class Utils
    {
        private BigInteger LCM(BigInteger a, BigInteger b)
        {
            BigInteger top = BigInteger.Zero;
            top = a.Multiply(b);
            top = top.Abs();

            BigInteger gcd = BigInteger.Zero;
            gcd = a.Gcd(b);

            BigInteger result = top.Divide(gcd);

            return result;
        }

        public BigInteger CTF(BigInteger a, BigInteger b) 
        {
            return LCM(a.Subtract(BigInteger.One), b.Subtract(BigInteger.One));
        }

        public BigInteger[] EEA(BigInteger a, BigInteger modulo)
        {
            BigInteger temp;
            BigInteger q = BigInteger.Zero;

            BigInteger[] r = new BigInteger[2];
            r[0] = modulo;
            r[1] = a;

            BigInteger[] s = new BigInteger[2];
            s[0] = BigInteger.One;
            s[1] = BigInteger.Zero;

            BigInteger[] t = new BigInteger[2];
            t[0] = BigInteger.Zero;
            t[1] = BigInteger.One;

            while (!r[1].Equals(BigInteger.Zero)) 
            {
                q = r[0].Divide(r[1]);

                temp = r[0].Subtract(q.Multiply(r[1]));
                r[0] = r[1];
                r[1] = temp;

                temp = s[0].Subtract(q.Multiply(s[1]));
                s[0] = s[1];
                s[1] = temp;

                temp = t[0].Subtract(q.Multiply(t[1]));
                t[0] = t[1];
                t[1] = temp;
            }

            BigInteger[] retValue = new BigInteger[3];
            retValue[0] = q;
            retValue[1] = s[0];
            retValue[2] = t[0];

            return retValue;

        }
    
        public BigInteger CalculateD(BigInteger a, BigInteger modulo)
        {

            BigInteger retValue = EEA(a, modulo)[2];
             
            if(retValue.CompareTo(BigInteger.Zero) <= 0)
            {
                retValue = retValue.Add(modulo); 
            }

            return retValue;
        }
    } 
}
