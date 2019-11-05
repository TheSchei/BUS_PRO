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
        private byte[] PrivateKey1 = new byte[8192]; // Also final signature
        private byte[] PrivateKey2 = new byte[8192];
        private readonly byte[] PublicKey1 = new byte[8192];
        private readonly byte[] PublicKey2 = new byte[8192];
        private byte[] Hash;//32 bytes

        public byte[] Public1 => PublicKey1;

        public byte[] Public2 => PublicKey2;

        public Signature()//generating private keys
        {
            Random randomizer = new Random();
            randomizer.NextBytes(PrivateKey1);
            randomizer.NextBytes(PrivateKey2);
        }
        public bool CreatePublicKey()//hashing private keys//easy to parallel
        {
            using (SHA256 mySHA = SHA256.Create())
            {
                byte[] temp;
                for(int i=0; i<256; i++)
                {
                    temp = Support.SubArray(PrivateKey1, 32 * i, 32);//substract 256bit number(32*8)
                    temp = mySHA.ComputeHash(temp);//hashing
                    for (int j = 0; j < 32; j++)//putting into public key variable
                        PublicKey1[32 * i + j] = temp[j];
                }
                for (int i = 0; i < 256; i++)
                {
                    temp = Support.SubArray(PrivateKey2, 32 * i, 32);
                    temp = mySHA.ComputeHash(temp);
                    for (int j = 0; j < 32; j++)
                        PublicKey2[32 * i + j] = temp[j];
                }
            }
            return true;
        }
        public bool CreateHash(string filePath)// hashing file
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
            //if ((Hash[x] & 0b_1000_0000) == 0) PrivateKey1[x + 0] = PrivateKey2[x + 0];
            if ((Hash[x] & 0b_1000_0000) != 0) TransferBytes(x, 0);
            if ((Hash[x] & 0b_0100_0000) != 0) TransferBytes(x, 1);
            if ((Hash[x] & 0b_0010_0000) != 0) TransferBytes(x, 2);
            if ((Hash[x] & 0b_0001_0000) != 0) TransferBytes(x, 3);
            if ((Hash[x] & 0b_0000_1000) != 0) TransferBytes(x, 4);
            if ((Hash[x] & 0b_0000_0100) != 0) TransferBytes(x, 5);
            if ((Hash[x] & 0b_0000_0010) != 0) TransferBytes(x, 6);
            if ((Hash[x] & 0b_0000_0001) != 0) TransferBytes(x, 7);
        }

        private void TransferBytes(int x, int y)
        {
            byte[] temp;
            //temp = Support.SubArray(PrivateKey2, (32 * x + y) * 32, 32);
            temp = Support.SubArray(PrivateKey2, (8 * x + y) * 32, 32);
            for (int j = 0; j < 32; j++)
                //PrivateKey1[32 * x + j] = temp[j];
                PrivateKey1[(8 * x + y) * 32 + j] = temp[j];
        }

        private byte[] CreateSignature()
        {
            //for(int i = 0; i<256; i++)// to 32
            for (int i = 0; i < 32; i++)// to 32
                CheckByte(i);
            PrivateKey2 = new Byte[8192];//deleting privatekey
            return PrivateKey1;//returning overwritten by signature privatekey
        }
        public void CreateFiles(string filename)
        {
            File.WriteAllBytes(filename + ".sign", this.CreateSignature());//creating signature file //256*32 bytes
            File.WriteAllBytes(filename + ".key", PublicKey1.Concat(PublicKey2).ToArray());//creating key file (concated publickey1 ++ publickey2)//2*256*32 bytes
        }
    }
}
