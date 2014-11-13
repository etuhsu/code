using System;
using System.Data;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// Encrypt 的摘要说明。
	/// </summary>
	public class Encrypt
	{
		/// <summary>
		/// 
		/// </summary>
		public Encrypt(){}

		/// <summary>
		/// MD5加密函数，此加密不可逆，这里需要引用System.Web.dll
		/// </summary>
		/// <param name="str">被加密的字符串</param>
		/// <param name="code">选择加密得长度,16为使用16位MD5加密,否则使用32位MD5加密,取16位则和ASP中常用的MD5算法的加密结果一样。</param>
		public static string md5(string str,int code) 
		{ 
			if(code==16) //16位MD5加密（取32位加密的9~25字符） 
			{ 
				return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str,"MD5").ToLower().Substring(8,16) ; 
			}  
			else//32位加密 
			{ 
				return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str,"MD5").ToLower(); 
			}  
		}


		/// <summary>
		/// 16位MD5加密方法,以前的DVBBS所使用
		/// </summary>
		/// <param name="strSource">待加密字串</param>
		/// <returns>加密后的字串</returns>
		public string MD5Encrypt(string strSource)
		{
			return MD5Encrypt(strSource, 16);
		}


		/// <summary>
		/// MD5加密,和动网上的16/32位MD5加密结果相同
		/// </summary>
		/// <param name="strSource">待加密字串</param>
		/// <param name="length">16或32值之一,其它则采用.net默认MD5加密算法</param>
		/// <returns>加密后的字串</returns>
		public static string MD5Encrypt(string strSource, int length)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(strSource);
			byte[] hashValue = ((System.Security.Cryptography.HashAlgorithm)System.Security.Cryptography.CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes);
			StringBuilder sb = new StringBuilder();
			switch (length)
			{
				case 16:
					for (int i = 4; i < 12; i++)
						sb.Append(hashValue[i].ToString("x2"));
					break;
				case 32:
					for (int i = 0; i < 16; i++)
					{
						sb.Append(hashValue[i].ToString("x2"));
					}
					break;
				default:
					for (int i = 0; i < hashValue.Length; i++)
					{
						sb.Append(hashValue[i].ToString("x2"));
					}
					break;
			}
			return sb.ToString();
		}


		/// <summary>
		/// 
		/// </summary>
		public static byte[] DESKey = new byte[] 
						{0x82, 0xBC, 0xA1, 0x6A, 0xF5, 0x87, 0x3B, 0xE6, 0x59, 0x6A, 
						 0x32, 0x64, 0x7F, 0x3A, 0x2A, 0xBB, 0x2B, 0x68, 0xE2, 0x5F, 0x06,
						 0xFB, 0xB8, 0x2D, 0x67, 0xB3, 0x55, 0x19, 0x4E, 0xB8, 0xBF, 0xDD };
		
		/// <summary>
		/// DES加密
		/// </summary>
		/// <param name="strSource">待加密字串</param>
		/// <returns>加密后的字符串</returns>
		public static string DESEncrypt(string strSource) 
		{
			return DESEncrypt(strSource, DESKey);
		}


		/// <summary>
		/// DES加密
		/// </summary>
		/// <param name="strSource">待加密字串</param>
		/// <param name="key">32位Key值</param>
		/// <returns>加密后的字符串</returns>
		public static string DESEncrypt(string strSource,byte[] key)
		{
			SymmetricAlgorithm sa = Rijndael.Create();
			sa.Key = key;
			sa.Mode= CipherMode.ECB;
			sa.Padding = PaddingMode.Zeros;
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);
			byte[] byt = Encoding.Unicode.GetBytes(strSource);
			cs.Write(byt, 0, byt.Length);
			cs.FlushFinalBlock();
			cs.Close();
			return Convert.ToBase64String(ms.ToArray());
		}


		/// <summary>
		/// DES解密
		/// </summary>
		/// <param name="strSource">待解密的字串</param>
		/// <returns>解密后的字符串</returns>
		public static string DESDecrypt(string strSource) 
		{
			return DESDecrypt(strSource, DESKey);
		}


		/// <summary>
		/// DES解密
		/// </summary>
		/// <param name="strSource">待解密的字串</param>
		/// <param name="key">32位Key值</param>
		/// <returns>解密后的字符串</returns>
		public static string DESDecrypt(string strSource,byte[] key)
		{
			SymmetricAlgorithm sa = Rijndael.Create();
			sa.Key = key;
			sa.Mode = CipherMode.ECB;
			sa.Padding = PaddingMode.Zeros;
			ICryptoTransform ct = sa.CreateDecryptor();
			byte[] byt = Convert.FromBase64String(strSource);
			MemoryStream ms = new MemoryStream(byt);
			CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Read);
			StreamReader sr = new StreamReader(cs, Encoding.Unicode);
			return sr.ReadToEnd();
		}

	}
}
