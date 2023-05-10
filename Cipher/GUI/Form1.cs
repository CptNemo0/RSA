using RSA;
using System.Text.Json;
using Org.BouncyCastle.Math;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace GUI
{
    public partial class Form1 : Form
    {
        /*
        private readonly string privateKey = "privateKey.bin";
        private readonly string publicKey = "publicKey.json";
        private readonly string initialMessagePath = "message.bin";
        private readonly string encodedPath = "encoded.bin";
        private readonly string decodedPath = "decoded.bin";
        */
        private Data data;
        private readonly Cipher cipher = new Cipher();

        private bool keysGenerated;
        private bool ctGenerated;
        private bool isFileMode;

        public Form1()
        {
            InitializeComponent();
            this.data = new Data();
            keysGenerated = false;
            ctGenerated = false;
            isFileMode = false;
        }

        private void gkpButton_Click(object sender, EventArgs e)
        {
            KeyPair kp = new KeyPair();

            data.Key.E = kp.E;
            data.Key.N = kp.N;
            data.PrivateKey.D = kp.D;
            keysGenerated = true;
        }

        private void skpButton_Click(object sender, EventArgs e)
        {
            if (keysGenerated)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Saving Priave Key";
                saveFileDialog.Filter = "Bin files (*.bin)|*.bin";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                    {
                        writer.Write(data.PrivateKey.D.ToByteArray());
                    }
                }

                var tempKey = new
                {
                    e = data.Key.E.ToString(),
                    n = data.Key.N.ToString(),
                };
                string jsonString = JsonConvert.SerializeObject(tempKey);

                SaveFileDialog saveFileDialog2 = new SaveFileDialog();
                saveFileDialog2.Title = "Saving Public Key";
                saveFileDialog2.Filter = "Json files (*.json)|*.json";
                saveFileDialog2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog2.FileName;
                    File.WriteAllText(fileName, jsonString);
                }
            }
        }

        private void lkpButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load Private Key!";
            openFileDialog.Filter = "Bin files (*.bin)|*.bin";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                byte[] key = new byte[16];

                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    key = reader.ReadBytes((int)reader.BaseStream.Length);
                    data.PrivateKey.D = new BigInteger(key);
                }
            }

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Title = "Load Public Key";
            openFileDialog2.Filter = "Json files (*.json)|*.json";
            openFileDialog2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog2.Multiselect = false;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog2.FileName;
                string jsonString = File.ReadAllText(fileName);
                JsonElement root = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(jsonString);
                string eValue = root.GetProperty("e").GetString();
                string nValue = root.GetProperty("n").GetString();

                data.Key.E = new BigInteger(eValue);
                data.Key.N = new BigInteger(nValue);
            }

            keysGenerated = true;
        }


        private void sctButton_Click(object sender, EventArgs e)
        {
            if (ctGenerated)
            {

                List<string> keys = new List<string>();

                foreach(BigInteger key in data.CipherText)
                {
                    keys.Add(key.ToString());
                }

                string json = JsonConvert.SerializeObject(keys);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save Ciphertext!";
                saveFileDialog.Filter = "Json files (*.json)|*.json";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    File.WriteAllText(fileName, json);
                }

                SaveFileDialog saveLenght = new SaveFileDialog();
                saveLenght.Title = "Save Add!";
                saveLenght.Filter = "Bin files (*.bin)|*.bin";
                saveLenght.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveLenght.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveLenght.FileName;

                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.Write(data.Add);
                    }
                }
            }
        }

        private void lctButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load Ciphertext!";
            openFileDialog.Filter = "Json files (*.json)|*.json";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            List<string> stringList = new List<string>();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                string jsonString = File.ReadAllText(fileName);
                stringList = JsonConvert.DeserializeObject<List<string>>(jsonString);
            }

            data.CipherText = new List<BigInteger>();

            foreach (string key in stringList)
            {
                data.CipherText.Add(new BigInteger(key));
            }

            ciphertextBox.Text = data.GetCipherText();

            OpenFileDialog openFileDialogLen = new OpenFileDialog();
            openFileDialogLen.Title = "Load Add!";
            openFileDialogLen.Filter = "Bin files (*.bin)|*.bin";
            openFileDialogLen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialogLen.Multiselect = false;

            if (openFileDialogLen.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialogLen.FileName;

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line = reader.ReadLine();
                    data.Add = int.Parse(line);
                }
            }
        }


        private void lptButton_CLick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load Plaintext!";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            byte[] messageByte = new byte[2];

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    messageByte = reader.ReadBytes((int)reader.BaseStream.Length);
                }
            }

            int reminder = messageByte.Length % 256;
            data.Add = 256 - reminder;
            int len = messageByte.Length + data.Add;
            data.PlainText = new byte[len];
            Array.Copy(messageByte, 0, data.PlainText, 0, messageByte.Length);

            plaintextBox.Text = BitConverter.ToString(messageByte).Replace("-", "");

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(messageByte);
                string hashString = BitConverter.ToString(hashValue).Replace("-", "");
                checksumBox.Text = hashString;
            }
        }

       
        private void encryptButton_Click(object sender, EventArgs e)
        {
            if (keysGenerated)
            {
                if(!isFileMode) 
                {
                    byte[] messageByte = Encoding.UTF8.GetBytes(plaintextBox.Text);

                    int reminder = messageByte.Length % 256;
                    data.Add = 256 - reminder;
                    int len = messageByte.Length + data.Add;
                    data.PlainText = new byte[len];
                    Array.Copy(messageByte, 0, data.PlainText, 0, messageByte.Length);

                    plaintextBox.Text = BitConverter.ToString(messageByte).Replace("-", "");

                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] hashValue = sha256.ComputeHash(messageByte);
                        string hashString = BitConverter.ToString(hashValue).Replace("-", "");
                        checksumBox.Text = hashString;
                    }

                    for (int i = 0; i < data.PlainText.Length / 256; i++)
                    {
                        byte[] block = new byte[256];
                        Array.Copy(data.PlainText, i * 256, block, 0, block.Length);
                        BigInteger blockInteger = new BigInteger(1, block);

                        data.Blocks.Add(block);
                        
                        BigInteger cipheredInteger = cipher.encrypt(data.Key.E, data.Key.N, blockInteger);
                        data.CipherText.Add(cipheredInteger);
                        data.Lengths.Add(blockInteger.ToByteArray().Length);

                    }
                    
                    ciphertextBox.Text = data.GetCipherText();
                }
                else
                {
                    for (int i = 0; i < data.PlainText.Length / 256; i++)
                    {
                        byte[] block = new byte[256];
                        Array.Copy(data.PlainText, i * 256, block, 0, block.Length);
                        BigInteger blockInteger = new BigInteger(1, block);

                        data.Blocks.Add(block);

                        BigInteger cipheredInteger = cipher.encrypt(data.Key.E, data.Key.N, blockInteger);
                        data.CipherText.Add(cipheredInteger);
                        data.Lengths.Add(blockInteger.ToByteArray().Length);

                    }

                    ciphertextBox.Text = data.GetCipherText();
                }

                ctGenerated = true;
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            byte[] newPlaintext = new byte[data.CipherText.Count * 256];
            List<BigInteger> decipheredInts = new List<BigInteger>();

            if (keysGenerated)
            {
                for(int i = 0; i < data.CipherText.Count; i++) 
                {
                    BigInteger cipheredInteger = cipher.decrypt(data.PrivateKey.D, data.Key.N, data.CipherText[i]);
                    decipheredInts.Add(cipheredInteger);
                    byte[] cipheredBlock = cipheredInteger.ToByteArray();

                    if (cipheredBlock.Length == 257)
                    {
                        byte[] errorBlock = new byte[256];

                        for (int j = 0; j < errorBlock.Length; j++)
                        {
                            errorBlock[j] = cipheredBlock[j + 1];
                        }

                        cipheredBlock = new byte[256];

                        errorBlock.CopyTo(cipheredBlock, 0);
                    }

                    Array.Copy(cipheredBlock, 0, newPlaintext, 256 * i, cipheredBlock.Length);
                }

                data.PlainText = new byte[data.CipherText.Count * 256 - data.Add];

                Array.Copy(newPlaintext, 0, data.PlainText, 0, data.PlainText.Length);

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashValue = sha256.ComputeHash(data.PlainText);
                    checksumBox.Text = BitConverter.ToString(hashValue).Replace("-", "");
                }

                plaintextBox.Text = data.GetPlainText();
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                data = new Data();

                keysGenerated = false;
                ctGenerated = false;                
                isFileMode = false;

                ciphertextBox.Text = string.Empty;
                plaintextBox.Text = string.Empty;
                checksumBox.Text = string.Empty;

                plaintextBox.Enabled = true;
                loadptButton.Enabled = true;
                loadctButton.Enabled = true;
                isFileMode = true;
            }
            else if (listBox1.SelectedIndex == 1)
            {
                data = new Data();

                keysGenerated = false;
                ctGenerated = false;
                isFileMode = false;

                ciphertextBox.Text = string.Empty;
                plaintextBox.Text = string.Empty;
                checksumBox.Text = string.Empty;

                plaintextBox.Enabled = true;
                loadptButton.Enabled = false;
                loadctButton.Enabled = false;
                isFileMode = false;
            }
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            
            data = new Data();

            keysGenerated = false;
            ctGenerated = false;
            isFileMode = false;

            ciphertextBox.Text = string.Empty;
            plaintextBox.Text = string.Empty;
            checksumBox.Text = string.Empty;
        }
    }
}