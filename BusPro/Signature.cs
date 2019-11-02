using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace BusPro
{
    static class Support//Subclass to hold static method
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)//Substracting array
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    };
    class Signature
    {
        private readonly Byte[] PrivateKey1 = new Byte[8192]; // Also final signature//maybe
        private readonly Byte[] PrivateKey2 = new Byte[8192];
        private readonly Byte[] PublicKey1 = new Byte[8192];
        private readonly Byte[] PublicKey2 = new Byte[8192];
        private Byte[] Hash;//32 bytes

        public Signature()//generating private keys
        {
            Random randomizer = new Random();
            randomizer.NextBytes(PrivateKey1);
            randomizer.NextBytes(PrivateKey2);
        }
        public Boolean CreatePublicKey()//hashing private keys//easy to parallel
        {
            using (SHA256 mySHA = SHA256.Create())
            {
                Byte[] temp;
                for(int i=0; i<=255; i++)
                {
                    temp = Support.SubArray<Byte>(PrivateKey1, 32 * i, 32);//substract 256bit number(32*8)
                    temp = mySHA.ComputeHash(temp);//hashing
                    for (int j = 0; j < 32; j++)//putting into public key variable
                    {
                        PublicKey1[32 * i + j] = temp[j];
                    }
                }
                for (int i = 0; i <= 255; i++)
                {
                    temp = Support.SubArray<Byte>(PrivateKey2, 32 * i, 32);
                    temp = mySHA.ComputeHash(temp);
                    for (int j = 0; j < 32; j++)
                    {
                        PublicKey2[32 * i + j] = temp[j];
                    }
                }
            }
            return true;
        }
        public Boolean CreateHash(String filePath)// hashing file
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
        private void CheckByte(int x) // creating signature based on hash (need to be used for each hash byte)
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
