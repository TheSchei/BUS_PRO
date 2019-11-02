using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace BusPro
{
    class Signature
    {
        private Byte[] PrivateKey1 = new Byte[8192]; // Also final signature
        private Byte[] PrivateKey2 = new Byte[8192];
        private Byte[] PublicKey1 = new Byte[8192];
        private Byte[] PublicKey2 = new Byte[8192];
        private Byte[] Hash;//32 bytes

        public Signature()//generating private keys
        {
            Random randomizer = new Random();
            randomizer.NextBytes(PrivateKey1);
            randomizer.NextBytes(PrivateKey2);
        }

        public Boolean createPublicKey()//hashing private keys
        {
            return true;
        }
        public Boolean createHash(String filePath)// hashing file
        {
            using (SHA256 mySHA = SHA256.Create())
            {
                try
                {
                    FileStream file = new FileStream(filePath, FileMode.Open);
                    Hash = mySHA.ComputeHash(file);
                    file.Close();
                }
                catch { return false; }
            }
            return true;
        }
        private void checkByte(int x) // creating signature based on hash (need to be used for each hash byte)
        {
            if ((Hash[x] & 0b_1000_0000) == 0) PrivateKey1[x + 0] = PrivateKey2[x + 0];
            if ((Hash[x] & 0b_0100_0000) == 0) PrivateKey1[x + 1] = PrivateKey2[x + 1];
            if ((Hash[x] & 0b_0010_0000) == 0) PrivateKey1[x + 2] = PrivateKey2[x + 2];
            if ((Hash[x] & 0b_0001_0000) == 0) PrivateKey1[x + 3] = PrivateKey2[x + 3];
            if ((Hash[x] & 0b_0000_1000) == 0) PrivateKey1[x + 4] = PrivateKey2[x + 4];
            if ((Hash[x] & 0b_0000_0100) == 0) PrivateKey1[x + 5] = PrivateKey2[x + 5];
            if ((Hash[x] & 0b_0000_0010) == 0) PrivateKey1[x + 6] = PrivateKey2[x + 6];
            if ((Hash[x] & 0b_0000_0001) == 0) PrivateKey1[x + 7] = PrivateKey2[x + 7];
        }
    }
}
