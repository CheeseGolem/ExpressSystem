using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace HongYang.WeiXin.Base.Utility.Extensions
{
   public static class StringExtensions
    {
        #region Null extension

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        public static bool IsNotNullAndNotEmpty(this string source)
        {
            return !string.IsNullOrEmpty(source);
        }

        public static bool IsNotNullAndNotWhiteSpace(this string source)
        {
            return !string.IsNullOrWhiteSpace(source);
        }

        public static string TrimEvenNull(this string source)
        {
            return source == null ? null : source.Trim();
        }

        #endregion

        #region file and dir
        public static string GetValidFileName(this string fileName)
        {
            string strFileName = "文件名称";
            StringBuilder rBuilder = new StringBuilder(strFileName);
            foreach (char rInvalidChar in Path.GetInvalidFileNameChars())
                rBuilder.Replace(rInvalidChar.ToString(), string.Empty);
            return rBuilder.ToString();
        }
        #endregion

        #region Hash

        public static string GetMD5Hash(this string stringToHash)
        {
            if (stringToHash.IsNullOrWhiteSpace())
            {
                return null;
            }
            return GetMD5Hash(stringToHash, Encoding.UTF8);
        }

        public static string GetMD5Hash(this string stringToHash, Encoding encoding)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(encoding.GetBytes(stringToHash));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                stringBuilder.AppendFormat("{0:x2}", encryptedBytes[i]);
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region 按命名规则转换

        /// <summary>
        /// 将字符串转换成Camel命名法字符串
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>Camel命名法字符串</returns>
        public static string ToCamelCase(this string source)
        {
            return source.Substring(0, 1).ToLower() + source.Substring(1).Replace(" ", "");
        }

        /// <summary>
        /// 将字符串转换成Pascal命名法字符串
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>Pascal命名法字符串</returns>
        public static string ToPascalCase(this string source)
        {
            return source.Substring(0, 1).ToUpper() + source.Substring(1).Replace(" ", "");
        }

        #endregion

        #region 编码转换

        public static byte[] ToBase64Bytes(this string source)
        {
            return Convert.FromBase64String(source);
        }

        public static string ToBase64String(this byte[] source)
        {
            return Convert.ToBase64String(source);
        }

        public static byte[] ToUTF8Bytes(this string source)
        {
            return Encoding.UTF8.GetBytes(source);
        }

        public static string ToUTF8String(this byte[] source)
        {
            return Encoding.UTF8.GetString(source);
        }

        #endregion

        #region GZIP压缩解压

        /// <summary>
        /// 压缩字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <returns>压缩后的字符串</returns>
        public static string Compress(this string source)
        {
            byte[] buffer = UTF8Encoding.Unicode.GetBytes(source);
            MemoryStream ms = new MemoryStream();
            using (GZipStream gzip = new GZipStream(ms, CompressionMode.Compress))
            {
                gzip.Write(buffer, 0, buffer.Length);
            }
            return Convert.ToBase64String(ms.GetBuffer()).TrimEnd('\0');
        }

        /// <summary>
        /// 解压缩字符串
        /// </summary>
        /// <param name="str">压缩后的字符串</param>
        /// <returns>原字符串</returns>
        public static string Decompress(this string source)
        {
            byte[] buffer = Convert.FromBase64String(source);
            MemoryStream ms = new MemoryStream();
            MemoryStream msOut = new MemoryStream();
            ms.Write(buffer, 0, buffer.Length);
            ms.Position = 0;
            byte[] writeData = new byte[4096];
            using (GZipStream gzip = new GZipStream(ms, CompressionMode.Decompress))
            {
                int n;
                while ((n = gzip.Read(writeData, 0, writeData.Length)) != 0)
                {
                    msOut.Write(writeData, 0, n);
                }
            }
            return UTF8Encoding.Unicode.GetString(msOut.GetBuffer()).TrimEnd('\0');
        }

        #endregion

        #region 将字符串转换成字符串集合

        /// <summary>
        /// 将字符串转换成字符串集合
        /// </summary>
        /// <param name="formatValue">原字符串</param>
        /// <param name="comma">分隔符</param>
        /// <returns>字符串集合</returns>
        public static List<string> ToList(this string formatValue, char comma)
        {
            List<string> list = new List<string>();
            if (formatValue.IsNotNullAndNotEmpty())
            {
                list.AddRange(formatValue.Split(comma));
            }
            return list;
        }

        public static List<string> ToList(this string formatValue)
        {
            return ToList(formatValue, ',');
        }

        #endregion

        #region 比较

        public static bool EqualsNoCase(this string source, string compare)
        {
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(compare))
            {
                return false;
            }
            return source.Equals(compare, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ContainsNoCase(this string source, string compare)
        {
            source = source ?? "";
            compare = compare ?? "";
            return source.ToLower().Contains(compare.ToLower());
        }

        #endregion

        #region Web扩展

        /// <summary>
        /// 获取html中所有的图片路径
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static List<string> GetImageUrl(this string html)
        {
            Regex RegImgSrc = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            List<string> urls = new List<string>();
            MatchCollection mc = RegImgSrc.Matches(html);
            // 取得匹配项列表
            if (mc.IsNull() && mc.Count > 0)
            {
                foreach (Match match in mc)
                {
                    if (match.Groups["imgUrl"] != null && match.Groups["imgUrl"].Value.IsNotNullAndNotWhiteSpace())
                    {
                        urls.Add(match.Groups["imgUrl"].Value.Trim());
                    }
                }
            }
            return urls;
        }


        /// <summary>
        /// 获取html中所有的第一张图片的路径
        /// </summary>
        public static string GetFirstImageUrl(this string html)
        {
            Regex RegImgSrc = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            MatchCollection mc = RegImgSrc.Matches(html);
            // 取得匹配项列表
            if (mc.IsNotNull() && mc.Count > 0)
            {
                foreach (Match match in mc)
                {
                    if (match.Groups["imgUrl"] != null && match.Groups["imgUrl"].Value.IsNotNullAndNotWhiteSpace())
                    {
                        return match.Groups["imgUrl"].Value.Trim();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 除掉字符串中的web标签
        /// </summary>
        public static string RemoveTags(this string html)
        {
            string result = String.IsNullOrEmpty(html)
                        ? ""
                        : Regex.Replace(html, "<[^<>]*>", "", RegexOptions.Singleline);

            result = String.IsNullOrEmpty(result)
                        ? ""
                        : Regex.Replace(result, "&nbsp;", "", RegexOptions.Singleline);

            return result;
        }


        /// <summary>
        /// 连接查询字符串和url
        /// </summary>
        public static string AppendQueryString(this string url, string qs)
        {
            string split = url.IndexOf('?') > 0 ? "&" : "?";
            return string.Concat(url, split, qs);
        }

        /// <summary>
        /// 为url添加一个查询字符串
        /// </summary>
        public static string AppendQueryString(this string url, string name, string val)
        {
            string split = url.IndexOf('?') > 0 ? "&" : "?";
            return string.Format("{0}{1}{2}={3}", url, split, name, val);
        }

        /// <summary>
        /// 将换行符号转化为web的换行
        /// </summary>
        public static string WrapLine(this string source)
        {
            return new StringBuilder(source).Replace("\r\n", "<br/>")
                .Replace("\n", "<br/>")
                .ToString();
        }

        /// <summary>
        /// 将换行符号转化为web的换行，空格转化为web的空格
        /// </summary>
        public static string WrapLineAndSpace(this string source)
        {
            return new StringBuilder(source).Replace("\r\n", "<br/>")
                    .Replace("\n", "<br/>").Replace(" ", "&nbsp;")
                    .ToString();
        }

        /// <summary>
        /// 截取字符串，并补充省略号
        /// </summary>
        public static string SubstringWithDots(this string source, int length = 20)
        {
            if (source.IsNotNullAndNotWhiteSpace() && source.Length > length)
            {
                return source.Substring(0, length) + "...";
            }
            return source ?? string.Empty;
        }

        /// <summary>
        /// 将字符串加上http://
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string WithHttp(this string source)
        {
            if (source.IsNull() || source.StartsWith("http://") || source.StartsWith("https://"))
            {
                return source;
            }
            return "http://" + source;
        }

        #endregion

        /// <summary>
        /// 隐藏手机号中间4位
        /// </summary>
        public static string HidePhone(this string phone)
        {
            if (phone.IsNotNullAndNotWhiteSpace() && phone.Length >= 11)
            {
                return $"{phone.Substring(0, 3)}****{phone.Substring(7, 4)}";
            }
            return "***********";
        }

        public static string HideQQ(this string QQ)
        {
            if (QQ.IsNotNullAndNotWhiteSpace() && QQ.Length >= 4)
            {
                return QQ.Substring(0, QQ.Length / 3) + "****" + QQ.Substring(QQ.Length - QQ.Length / 3);
            }
            return "******";
        }

        public static string HideEmail(this string email)
        {
            if (email.IsNotNullAndNotWhiteSpace() && email.IndexOf("@") > -1)
            {
                var pos = email.IndexOf("@");
                var left = email.Substring(0, pos);
                if (left.Length < 4)
                {
                    return "*****" + email.Substring(pos);
                }
                return left.Substring(0, left.Length / 3) + "****" + left.Substring(left.Length - left.Length / 3) + email.Substring(pos);
            }
            return "******";
        }

        /// <summary>
        /// 隐藏密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string HiddenPassword(this string pwd)
        {
            if (pwd.IsNull() || pwd.Length < 6)
            {
                return "******";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(pwd.Substring(0, 2));
            int hideLen = pwd.Length - 3;

            for (int i = 0; i < hideLen; i++)
            {
                sb.Append('*');
            }
            sb.Append(pwd.Substring(pwd.Length - 1, 1));
            return sb.ToString();
        }


        /// <summary>
        /// 把相对路径转换为物理目录地址
        /// </summary>
        public static string GetPhysicalPath(this string path)
        {
            if (path.IndexOf(":\\") > 0)
                return path;
            if (!path.StartsWith("~"))
            {
                if (!path.StartsWith("/"))
                    path = "~/" + path;
                else
                    path = "~" + path;
            }
            if (HttpContext.Current != null)
                return HttpContext.Current.Server.MapPath(path);
            else
            {
                var tpath = path.Replace("~/", "").Replace("/", "\\");
                string fp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, tpath);
                if (Directory.Exists(fp) || File.Exists(fp))
                    return fp;

                fp = string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, tpath);
                if (Directory.Exists(fp) || File.Exists(fp))
                    return fp;

                fp = string.Format("{0}{1}", HttpRuntime.BinDirectory, tpath);
                if (Directory.Exists(fp) || File.Exists(fp))
                    return fp;
            }
            if (!string.IsNullOrEmpty(path))
                return HostingEnvironment.MapPath(path);

            return path;
        }

        public static bool ContainsEnum(this string enums, Enum value, char split = ',')
        {
            return enums.IfNullOrWhiteSpace("").Split(split).Contains(value.ToString());
        }

        public static string EnumDescriptions(this string enums, Type enumType, char split = ',', string showSplit = "|")
        {
            var enumNameDescriptions = new Dictionary<string, string>();
            foreach (var field in enumType.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                var descAttr = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                    .OfType<DescriptionAttribute>()
                                    .FirstOrDefault();

                var text = descAttr == null ? field.Name : descAttr.Description;
                var value = field.Name;
                enumNameDescriptions.Add(value, text);
            }

            return string.Join(showSplit, enums.IfNullOrWhiteSpace("")
                                               .Split(split)
                                               .Where(e => enumNameDescriptions.ContainsKey(e))
                                               .Select(e => enumNameDescriptions[e]));
        }
        /// <summary>
        /// 生成GUID
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string NewGuid(this string guid)
        {
            return System.Guid.NewGuid().ToString();
        }


        /// <summary>
        /// 替换权限dal生成的更新语句有错
        ///  sql.Replace(" Parentid = '' ", " Parentid = NULL ")
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string ReplaceParentIDNull(this string sql)
        {
            return sql = sql.Replace("Parentid=''", " Parentid = null ");
        }

        #region 代码与汉字转换

        /// <summary>
        /// 性别转换成中文
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static string ToSexChinese(this string sex)
        {
            string SexChinese = "不详";
            switch (sex)
            {
                case "1": SexChinese = "男"; break;
                case "2": SexChinese = "女"; break;
                default:
                    break;
            }
            return SexChinese;
        }
        #endregion


        #region yyyy-m-d转成yyyy-MM-dd
        /// <summary>
        /// 将yyyy-MM-dd格式的日期，月份与日数不是双位数的，自动补0
        /// </summary>
        /// <param name="DateTimeString"></param>
        /// <returns></returns>
        public static string ChangeDateFormat(this string DateTimeString) {

           string[] DateArray= DateTimeString.Split('-');
            for (int i = 0; i < DateArray.Length; i++)
            {
                if (DateArray[i].Length==1)
                {
                    DateArray[i] = "0" + DateArray[i];
                }
            }

            DateTimeString = DateArray[0] + "-" + DateArray[1] + "-" + DateArray[2];
            return DateTimeString;
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// 随机6位数验证码
        /// </summary>
        /// <param name="VCode"></param>
        /// <returns></returns>
        public static string getVerifyCode(this string VCode)
        {
            string[] verifyString = new string[] { "0", "1", "2", "3", "4", "5",
                "6", "7", "8", "9" };
            Random random = new Random();
            StringBuilder verifyBuilder = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                int rd = random.Next(0, 10);
                verifyBuilder.Append(verifyString[rd]);
            }
            VCode= verifyBuilder.ToString();
            return VCode;
        }
        #endregion
    }
}
