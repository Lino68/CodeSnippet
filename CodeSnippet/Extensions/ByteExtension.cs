using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lino.CodeSnippet.Extensions
{
    /// <summary>
    /// 原文参考：http://www.cnblogs.com/ldp615/archive/2009/08/14/1552133.html
    /// </summary>
    public static class ByteExtension
    {
        /// <summary>
        /// 转换为十六进制
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string ToHex(this byte b)
        {
            return b.ToString("X2");
        }

        /// <summary>
        /// 转换为十六进制
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHex(this IEnumerable<byte> bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        /// <summary>
        /// 转换为Base64字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 转换为Int32
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int ToInt(this byte[] value, int startIndex)
        {
            return BitConverter.ToInt32(value, startIndex);
        }

        /// <summary>
        /// 转换为Int64
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static long ToInt64(this byte[] value, int startIndex)
        {
            return BitConverter.ToInt64(value, startIndex);
        }

        /// <summary>
        /// 转换为指定编码的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Decode(this byte[] data, Encoding encoding)
        {
            return encoding.GetString(data);
        }

        /// <summary>
        /// 使用指定算法Hash
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hashName"></param>
        /// <returns></returns>
        public static byte[] Hash(this byte[] data, string hashName)
        {
            HashAlgorithm algorithm;
            if (string.IsNullOrEmpty(hashName)) algorithm = HashAlgorithm.Create();
            else algorithm = HashAlgorithm.Create(hashName);
            return algorithm.ComputeHash(data);
        }

        /// <summary>
        /// 使用默认算法Hash
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Hash(this byte[] data)
        {
            return Hash(data, null);
        }


        /// <summary>
        /// 位运算，index从0开始，获取取第index是否为1
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool GetBit(this byte b, int index)
        {
            return (b & (1 << index)) > 0;
        }

        /// <summary>
        /// 将第index位设为1
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte SetBit(this byte b, int index)
        {
            b |= (byte)(1 << index);
            return b;
        }

        /// <summary>
        /// 将第index位设为0
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte ClearBit(this byte b, int index)
        {
            b &= (byte)((1 << 8) - 1 - (1 << index));
            return b;
        }

        /// <summary>
        /// 将第index位取反
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte ReverseBit(this byte b, int index)
        {
            b ^= (byte)(1 << index);
            return b;
        }

        /// <summary>
        /// 保存为文件
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>

        public static void Save(this byte[] data, string path)
        {
            File.WriteAllBytes(path, data);
        }

        /// <summary>
        /// 转换为内存流
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this byte[] data)
        {
            return new MemoryStream(data);
        }

    }
}
