using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using CoopSystemWebApp.Helper;

namespace CoopSystemWebApp.Helper
{
    public class EncryptDecryptString
    {
        static String secretCode = "aSecretCode12345";
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("aSecretCode12345");
        private const int keysize = 256;

        public static string Encrypt(string text)
        {
            string encryptedText = "";

            try
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);

                using (PasswordDeriveBytes password = new PasswordDeriveBytes(secretCode, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);

                    using (RijndaelManaged rmKey = new RijndaelManaged())
                    {
                        rmKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform encryptor = rmKey.CreateEncryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream mStream = new MemoryStream())
                            {
                                using (CryptoStream cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cStream.Write(textBytes, 0, textBytes.Length);
                                    cStream.FlushFinalBlock();
                                    encryptedText = Convert.ToBase64String(mStream.ToArray());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                encryptedText = ExceptionHelper.ExceptionStackTrace(exception);
            }

            return encryptedText;
        }

        public static string Decrypt(string text)
        {
            string decryptedText = "";

            try
            {
                byte[] textBytes = Convert.FromBase64String(text);

                using (PasswordDeriveBytes password = new PasswordDeriveBytes(secretCode, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);

                    using (RijndaelManaged rmKey = new RijndaelManaged())
                    {
                        rmKey.Mode = CipherMode.CBC;

                        using (ICryptoTransform decryptor = rmKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream mStream = new MemoryStream(textBytes))
                            {
                                using (CryptoStream cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                                {
                                    textBytes = new byte[textBytes.Length];
                                    int countDecryptByte = cStream.Read(textBytes, 0, textBytes.Length);
                                    decryptedText = Encoding.UTF8.GetString(textBytes, 0, countDecryptByte);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                decryptedText = ExceptionHelper.ExceptionStackTrace(exception);
            }

            return decryptedText;
        }
    }
}
