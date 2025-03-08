using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Library.CartoonMirDB.Crypto
{
    internal class Crypto
    {
        public static class AesUtils
        {
            public const int KeySize = 256;
            public const int KeySizeBytes = 32;
            public const int BlockSize = 128;
            public const int BlockSizeBytes = 16;
            public const int DefaultBufferSize = 8192;

            public static SymmetricAlgorithm CreateSymmetricAlgorithm()
            {
                Aes aes = Aes.Create();
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                return (SymmetricAlgorithm)aes;
            }

            public static long CopyTo(Stream input, Stream output, byte[] buffer)
            {
                if (buffer == null)
                    throw new ArgumentNullException(nameof(buffer));
                if (input == null)
                    throw new ArgumentNullException(nameof(input));
                if (output == null)
                    throw new ArgumentNullException(nameof(output));
                if (buffer.Length == 0)
                    throw new ArgumentException("buffer大小为0");
                long num = 0;
                int count;
                while ((count = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, count);
                    num += (long)count;
                }
                return num;
            }

            public static byte[] ReadFully(Stream input, int bufferSize)
            {
                if (bufferSize < 1)
                    throw new ArgumentOutOfRangeException(nameof(bufferSize));
                byte[] buffer = new byte[bufferSize];
                if (buffer == null)
                    throw new ArgumentNullException("buffer");
                if (input == null)
                    throw new ArgumentNullException(nameof(input));
                if (buffer.Length == 0)
                    throw new ArgumentException("buffer大小为0");
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Library.CartoonMirDB.Crypto.Crypto.AesUtils.CopyTo(input, (Stream)memoryStream, buffer);
                    if (memoryStream.Length == (long)memoryStream.GetBuffer().Length)
                        return memoryStream.GetBuffer();
                    return memoryStream.ToArray();
                }
            }

            public static byte[] CreateKey()
            {
                using (SymmetricAlgorithm symmetricAlgorithm = Library.CartoonMirDB.Crypto.Crypto.AesUtils.CreateSymmetricAlgorithm())
                    return symmetricAlgorithm.Key;
            }

            public static byte[] CreateIv()
            {
                using (SymmetricAlgorithm symmetricAlgorithm = Library.CartoonMirDB.Crypto.Crypto.AesUtils.CreateSymmetricAlgorithm())
                    return symmetricAlgorithm.IV;
            }

            public static void CreateKeyAndIv(out byte[] cryptKey, out byte[] iv)
            {
                using (SymmetricAlgorithm symmetricAlgorithm = Library.CartoonMirDB.Crypto.Crypto.AesUtils.CreateSymmetricAlgorithm())
                {
                    cryptKey = symmetricAlgorithm.Key;
                    iv = symmetricAlgorithm.IV;
                }
            }

            public static void CreateCryptAuthKeysAndIv(
              out byte[] cryptKey,
              out byte[] authKey,
              out byte[] iv)
            {
                using (SymmetricAlgorithm symmetricAlgorithm = Library.CartoonMirDB.Crypto.Crypto.AesUtils.CreateSymmetricAlgorithm())
                {
                    cryptKey = symmetricAlgorithm.Key;
                    iv = symmetricAlgorithm.IV;
                }
                using (SymmetricAlgorithm symmetricAlgorithm = Library.CartoonMirDB.Crypto.Crypto.AesUtils.CreateSymmetricAlgorithm())
                    authKey = symmetricAlgorithm.Key;
            }

            public static string Encrypt(string text, byte[] cryptKey, byte[] iv)
            {
                return Convert.ToBase64String(Library.CartoonMirDB.Crypto.Crypto.AesUtils.Encrypt(Encoding.UTF8.GetBytes(text), cryptKey, iv));
            }

            public static byte[] Encrypt(byte[] bytesToEncrypt, byte[] cryptKey, byte[] iv)
            {
                using (SymmetricAlgorithm symmetricAlgorithm = Library.CartoonMirDB.Crypto.Crypto.AesUtils.CreateSymmetricAlgorithm())
                {
                    using (ICryptoTransform encryptor = symmetricAlgorithm.CreateEncryptor(cryptKey, iv))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                using (BinaryWriter binaryWriter = new BinaryWriter((Stream)cryptoStream))
                                    binaryWriter.Write(bytesToEncrypt);
                            }
                            return memoryStream.ToArray();
                        }
                    }
                }
            }

            public static string Decrypt(string encryptedBase64, byte[] cryptKey, byte[] iv)
            {
                return Encoding.UTF8.GetString(Library.CartoonMirDB.Crypto.Crypto.AesUtils.Decrypt(Convert.FromBase64String(encryptedBase64), cryptKey, iv));
            }

            public static byte[] Decrypt(byte[] encryptedBytes, byte[] cryptKey, byte[] iv)
            {
                using (SymmetricAlgorithm symmetricAlgorithm = Library.CartoonMirDB.Crypto.Crypto.AesUtils.CreateSymmetricAlgorithm())
                {
                    using (ICryptoTransform decryptor = symmetricAlgorithm.CreateDecryptor(cryptKey, iv))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(encryptedBytes, 0, encryptedBytes.Length, true, true))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                                return Library.CartoonMirDB.Crypto.Crypto.AesUtils.ReadFully((Stream)cryptoStream, 8192);
                        }
                    }
                }
            }
        }
    }
}
