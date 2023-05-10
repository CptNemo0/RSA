using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] messageByte;
            
            using (BinaryReader reader = new BinaryReader(File.Open("C:\\Users\\pawel\\Desktop\\test3.txt", FileMode.Open)))
            {
                messageByte = reader.ReadBytes((int)reader.BaseStream.Length);
            }
            
            //Console.WriteLine(BitConverter.ToString(messageByte));
            
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(messageByte);
                Console.WriteLine(BitConverter.ToString(hashValue).Replace("-", ""));
            }

            //Console.WriteLine(Encoding.UTF8.GetString(messageByte));
            Console.WriteLine(messageByte.Length);

            //CORRECTING THE LENGHT
            int reminder = messageByte.Length % 256;
            Console.WriteLine("reminder: " + reminder);
            int add = 256 - reminder;
            int len = messageByte.Length + add;
            Console.WriteLine("new len: " + len);
            //

            //CREATING NEW MESSAGE WITH ZEROS
            byte[] messageCorrected = new byte[len];
            Array.Copy(messageByte, 0, messageCorrected, 0, messageByte.Length);
            //

            KeyPair keyPair = new KeyPair();
            Console.WriteLine("N bitLength: " + keyPair.N.BitLength);
            Console.WriteLine("D bitLength: " + keyPair.D.BitLength);
            Cipher cipher = new Cipher();
            List<BigInteger> cipherText = new List<BigInteger>();
            List<int> lengths = new List<int>();
            lengths.Add(0);
            List<byte[]> blocks = new List<byte[]>();

            Console.WriteLine("\n ENCRYPTION \n");

            //ENCRYPTION
            for (int i = 0 ; i < messageCorrected.Length / 256; i++)
            {
                byte[] block = new byte[256];
                Array.Copy(messageCorrected, i * 256, block, 0, block.Length);
                BigInteger blockInteger = new BigInteger(1, block);

                blocks.Add(block);
                /*
                Console.WriteLine("=======================================");
                Console.WriteLine(BitConverter.ToString(block));
                Console.WriteLine(BitConverter.ToString(blockInteger.ToByteArray()));
                Console.WriteLine(blockInteger.ToByteArray().Length);
                Console.WriteLine("=======================================");
                */
                BigInteger cipheredInteger= cipher.encrypt(keyPair.E, keyPair.N, blockInteger);
                cipherText.Add(cipheredInteger);
                lengths.Add(blockInteger.ToByteArray().Length);

            }

            Console.WriteLine("\n DECRYPTION \n");
            Console.WriteLine("list len: " + cipherText.Count);

            byte[] newPlaintext = new byte[messageCorrected.Length];
            List<BigInteger> decipheredInts = new List<BigInteger>();
            //DECRYPTION
            for(int i = 0 ; i < cipherText.Count; i++) 
            {
                BigInteger cipheredInteger = cipher.decrypt(keyPair.D, keyPair.N, cipherText[i]);
                decipheredInts.Add(cipheredInteger);
                byte[] cipheredBlock = cipheredInteger.ToByteArray();

                Console.WriteLine(cipheredBlock.Length);
                if (cipheredBlock.Length == 257)
                {
                    Console.WriteLine("fix \n \n");
                    byte[] errorBlock = new byte[256];

                    for(int j =  0 ; j < errorBlock.Length; j++)
                    {
                        errorBlock[j] = cipheredBlock[j + 1];
                    }

                    cipheredBlock = new byte[256];

                    errorBlock.CopyTo(cipheredBlock, 0);
                }
                

                if (!blocks[i].SequenceEqual<byte>(cipheredBlock))
                {
                    Console.WriteLine();
                    Console.WriteLine("=======================================");
                    Console.WriteLine(BitConverter.ToString(cipherText[i].ToByteArray()));
                    Console.WriteLine("=======================================");
                    Console.WriteLine(BitConverter.ToString(blocks[i]));
                    Console.WriteLine("=======================================");
                    Console.WriteLine(BitConverter.ToString(cipheredBlock));
                    Console.WriteLine("=======================================");
                    Console.WriteLine();
                }

                Array.Copy(cipheredBlock, 0, newPlaintext, 256 * i, cipheredBlock.Length );
            }
            //

            Console.WriteLine(newPlaintext.Length);
            

            byte[] shortened = new byte[messageCorrected.Length - add];

            for (int i = 0; i < shortened.Length; i++)
            {
                shortened[i] = newPlaintext[i];
            }

            Console.WriteLine(shortened.Length);
            Console.WriteLine(messageByte.Length);
            //Console.WriteLine(Encoding.UTF8.GetString(shortened));

            int ctr = 0;
            for(int i = 0; i < shortened.Length; i++) 
            {
                if (shortened[i] == messageByte[i]) 
                {
                    ctr++;
                }
            }

            Console.WriteLine("ctr: " + ctr);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(shortened);
                Console.WriteLine(BitConverter.ToString(hashValue).Replace("-", ""));
            }

            //Console.WriteLine(BitConverter.ToString(shortened));
        }
    }
}
