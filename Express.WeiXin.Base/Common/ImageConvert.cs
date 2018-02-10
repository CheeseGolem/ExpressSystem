using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Express.WeiXin.Base.Common
{
    public class ImageConvert
    {
        private int ICON_W = 64;
        private int ICON_H = 64;

        public ImageConvert()
        {
        }

        //fileinpath,origaly picture file path,fileoutpath save filepath,index the ImageFormat you want to convert to
        public string Convert(string fileinpath, string fileoutpath, string index)
        {
            try
            {
                Bitmap bitmap = new Bitmap(fileinpath);
                index = index.ToLower();
                switch (index)
                {
                    case "jpg": bitmap.Save(fileoutpath, ImageFormat.Jpeg); break;
                    case "jpeg": bitmap.Save(fileoutpath, ImageFormat.Jpeg); break;
                    case "bmp": bitmap.Save(fileoutpath, ImageFormat.Bmp); break;
                    case "png": bitmap.Save(fileoutpath, ImageFormat.Png); break;
                    case "emf": bitmap.Save(fileoutpath, ImageFormat.Emf); break;
                    case "gif": bitmap.Save(fileoutpath, ImageFormat.Gif); break;
                    case "wmf": bitmap.Save(fileoutpath, ImageFormat.Wmf); break;
                    case "exif": bitmap.Save(fileoutpath, ImageFormat.Exif); break;
                    case "tiff":
                        {
                            Stream stream = File.Create(fileoutpath);
                            bitmap.Save(stream, ImageFormat.Tiff);
                            stream.Close();
                        }
                        break;
                    case "ico":
                        {
                            Icon ico;
                            Stream stream = File.Create(fileoutpath);
                            ico = BitmapToIcon(bitmap, false);
                            ico.Save(stream);       //   save the icon
                            stream.Close();
                        }; break;
                    default: return "Error!";
                }
                return "Success!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Convert(string fileinpath, string fileoutpath, string index, int width, int height)
        {
            if (width <= 0 || height <= 0)
                return "error!size illegal!";
            try
            {
                Bitmap mybitmap = new Bitmap(fileinpath);
                Bitmap bitmap = new Bitmap(mybitmap, width, height);
                index = index.ToLower();
                switch (index)
                {
                    case "jpg": bitmap.Save(fileoutpath, ImageFormat.Jpeg); break;
                    case "jpeg": bitmap.Save(fileoutpath, ImageFormat.Jpeg); break;
                    case "bmp": bitmap.Save(fileoutpath, ImageFormat.Bmp); break;
                    case "png": bitmap.Save(fileoutpath, ImageFormat.Png); break;
                    case "emf": bitmap.Save(fileoutpath, ImageFormat.Emf); break;
                    case "gif": bitmap.Save(fileoutpath, ImageFormat.Gif); break;
                    case "wmf": bitmap.Save(fileoutpath, ImageFormat.Wmf); break;
                    case "exif": bitmap.Save(fileoutpath, ImageFormat.Exif); break;
                    case "tiff":
                        {
                            Stream stream = File.Create(fileoutpath);
                            bitmap.Save(stream, ImageFormat.Tiff);
                            stream.Close();
                        }
                        break;
                    case "ico":
                        {
                            if (height > 256 || width > 256)//ico maxsize 256*256
                                return "Error!Size illegal!";
                            Icon ico;
                            ICON_H = height;
                            ICON_W = width;
                            Stream stream = File.Create(fileoutpath);
                            ico = BitmapToIcon(mybitmap, true);
                            ico.Save(stream);       //   save the icon
                            stream.Close();
                        }; break;
                    default: return "Error!";
                }
                return "Success!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Icon BitmapToIcon(Image obm, bool preserve)
        {
            if (obm == null)
                return null;
            Bitmap bitmap = new Bitmap(obm);
            return BitmapToIcon(bitmap, preserve);
        }
        public Icon BitmapToIcon(Bitmap obm, bool preserve)
        {
            Bitmap bm;
            // if not preserving aspect
            if (!preserve)        // if not preserving aspect
                bm = new Bitmap(obm, ICON_W, ICON_H);  //   rescale from original bitmap

            // if preserving aspect drop excess significance in least significant direction
            else          // if preserving aspect
            {
                Rectangle rc = new Rectangle(0, 0, ICON_W, ICON_H);
                if (obm.Width >= obm.Height)   //   if width least significant
                {          //     rescale with width based on max icon height
                    bm = new Bitmap(obm, (ICON_H * obm.Width) / obm.Height, ICON_H);
                    rc.X = (bm.Width - ICON_W) / 2;  //     chop off excess width significance
                    if (rc.X < 0) rc.X = 0;
                }
                else         //   if height least significant
                {          //     rescale with height based on max icon width
                    bm = new Bitmap(obm, ICON_W, (ICON_W * obm.Height) / obm.Width);
                    rc.Y = (bm.Height - ICON_H) / 2; //     chop off excess height significance
                    if (rc.Y < 0) rc.Y = 0;
                }
                bm = bm.Clone(rc, bm.PixelFormat);  //   bitmap for icon rectangle
            }

            // create icon from bitmap
            try
            {
                Icon icon = Icon.FromHandle(bm.GetHicon()); // create icon from bitmap

                return icon;        // return icon
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                bm.Dispose();        // dispose of bitmap
            }
            return null;
        }

        /// <summary>
        /// Convert Image to Byte[]
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image img)
        {
            Bitmap image = new Bitmap(img);
            try
            {
                ImageFormat format = img.RawFormat;
                using (MemoryStream ms = new MemoryStream())
                {
                    if (format.Equals(ImageFormat.Jpeg))
                    {
                        image.Save(ms, ImageFormat.Jpeg);
                    }
                    else if (format.Equals(ImageFormat.Png))
                    {
                        image.Save(ms, ImageFormat.Png);
                    }
                    else if (format.Equals(ImageFormat.Bmp))
                    {
                        image.Save(ms, ImageFormat.Bmp);
                    }
                    else if (format.Equals(ImageFormat.Gif))
                    {
                        image.Save(ms, ImageFormat.Gif);
                    }
                    else if (format.Equals(ImageFormat.Icon))
                    {
                        image.Save(ms, ImageFormat.Icon);
                    }
                    else
                    {
                        image.Save(ms, ImageFormat.Png);
                    }
                    byte[] buffer = new byte[ms.Length];
                    //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(buffer, 0, buffer.Length);
                    ms.Dispose();
                    return buffer;
                }
            }
            catch (Exception)
            {
                return ImageToBytesG(image);
            }

        }

        public static byte[] ImageToBytesG(Image image)
        {
            byte[] bytes = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                //创建一个bitmap类型的bmp变量来读取文件。
                //Bitmap bmp = new Bitmap(image);
                //新建第二个bitmap类型的bmp2变量，我这里是根据我的程序需要设置的。
                Bitmap bmp2 = new Bitmap(image.Width, image.Height, image.PixelFormat);
                //将第一个bmp拷贝到bmp2中
                using (Graphics draw = Graphics.FromImage(bmp2))
                {
                    draw.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    draw.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    draw.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                    draw.DrawImage(image, 0, 0, image.Width, image.Height);
                    bmp2.Save(ms, image.RawFormat);
                }
                bytes = ms.ToArray();
                bmp2.Dispose();
                //image.Dispose();//释放bmp文件资源
            }
            return bytes;
        }
        /// <summary>
        /// Convert Byte[] to Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] buffer)
        {
            //try
            //{
            //    using (MemoryStream ms = new MemoryStream(buffer))
            //    {
            //        Image image = System.Drawing.Image.FromStream(ms);
            //        ms.Dispose();
            //        return image;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Hiview.LogManager.Default.Error("byte to image error", ex);
            //    return null;
            //}
            Image photo = null;
            if (buffer != null)
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    ms.Write(buffer, 0, buffer.Length);
                    photo = Image.FromStream(ms);
                }

            return photo;
        }

        /// <summary>
        /// Convert Byte[] to a picture and Store it in file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string CreateImageFromBytes(string fileName, byte[] buffer)
        {
            string file = fileName;
            Image image = BytesToImage(buffer);
            ImageFormat format = image.RawFormat;
            if (format.Equals(ImageFormat.Jpeg))
            {
                file += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Png))
            {
                file += ".png";
            }
            else if (format.Equals(ImageFormat.Bmp))
            {
                file += ".bmp";
            }
            else if (format.Equals(ImageFormat.Gif))
            {
                file += ".gif";
            }
            else if (format.Equals(ImageFormat.Icon))
            {
                file += ".icon";
            }
            System.IO.FileInfo info = new System.IO.FileInfo(file);
            System.IO.Directory.CreateDirectory(info.Directory.FullName);
            File.WriteAllBytes(file, buffer);
            return file;
        }

        #region 缩略图
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW":  //指定高宽缩放（可能变形）                
                    break;
                case "W":   //指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H":   //指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        // 生成缩略图
        public static Image MakeThumbnail(Image originalImageSource, int width, int height, string mode)
        {
            byte[] byteSource = ImageToBytes(originalImageSource);
            return BytesToImage(MakeThumbnail(byteSource, width, height, mode));
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImageSource">byte[]</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>   
        public static byte[] MakeThumbnail(byte[] originalImageSource, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = BytesToImage(originalImageSource);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW":  //指定高宽缩放（可能变形）                
                    break;
                case "W":   //指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H":   //指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                //bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ImageToBytes(bitmap);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion
    }
}
