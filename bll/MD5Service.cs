using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace bll
{
	public static class MD5Service
	{
		private static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        /// <summary>
        /// string - MD5
        /// </summary>
        /// <param name="n_text"></param>
        /// <returns></returns>
		public static string GetMD5CodeToString(string n_text)
		{
			byte[] u_byte = Encoding.Default.GetBytes(n_text);
			byte[] u_code = md5.ComputeHash(u_byte);
			return BitConverter.ToString(u_code);
		}
        /// <summary>
        /// ÎÄ¼þÂ·¾¶ - MD5
        /// </summary>
        /// <param name="n_path"></param>
        /// <returns></returns>
		public static string GetMD5CodeToFile(string n_path)
		{
			FileStream u_stream = File.OpenRead(n_path);
			byte[] u_code = md5.ComputeHash(u_stream);
			return BitConverter.ToString(u_code);
		}
	}
}
