using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace BusPro
{
    class Verify
    {
        private readonly byte[] PublicKey1 = new byte[8192];
        private readonly byte[] PublicKey2 = new byte[8192];
        private readonly byte[] Signature;// = new byte[8192];
        byte[] Hash;
        public Verify(string SignFile, string KeyFile)
        {
            Signature = File.ReadAllBytes(SignFile);
            if (Signature.Length != 8192) throw new Exception("Wrong size of Signature file");
            PublicKey1 = File.ReadAllBytes(KeyFile);
            if (PublicKey1.Length != (8192 * 2)) throw new Exception("Wrong size of Key file");
            PublicKey2 = VerifySupport.SubArrayDeepClone(PublicKey1, 8192, 8192);
            PublicKey1 = VerifySupport.SubArrayDeepClone(PublicKey1, 0, 8192);
        }
        public bool VerifySignature(string filePath)
        {
            using (SHA256 mySHA = SHA256.Create())
            {
                FileStream file = new FileStream(filePath, FileMode.Open);
                Hash = mySHA.ComputeHash(file);
                file.Close();
            }
            using (SHA256 mySHA = SHA256.Create())
            {
                byte[] temp;
                for (int i = 0; i < 256; i++)
                {
                    temp = Support.SubArray(Signature, 32 * i, 32);//substract 256bit number(32*8)
                    temp = mySHA.ComputeHash(temp);//hashing
                    for (int j = 0; j < 32; j++)//putting into public key variable
                        Signature[32 * i + j] = temp[j];
                }
            }
            //compare ChooseBytes(Hash) and new signature
            return Signature.SequenceEqual(ChooseBytes(Hash));
        }
        private byte[] ChooseBytes(byte[] hash)
        {
            for (int i = 0; i < 32; i++)// to 32
                CheckByte(i);
            return PublicKey1;//returning overwritten by signature privatekey
        }

        private void CheckByte(int x) // creating signature based on hash (need to be used for each hash byte)
        {
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
            temp = Support.SubArray(PublicKey2, (8 * x + y) * 32, 32);
            for (int j = 0; j < 32; j++)
                PublicKey1[(8 * x + y) * 32 + j] = temp[j];
        }
    }

    static class VerifySupport
    {
        public static T[] SubArrayDeepClone<T>(this T[] data, int index, int length)
        {
            T[] arrCopy = new T[length];
            Array.Copy(data, index, arrCopy, 0, length);
            using (MemoryStream ms = new MemoryStream())
            {
                var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(ms, arrCopy);
                ms.Position = 0;
                return (T[])bf.Deserialize(ms);
            }
        }
    }
}
