using System;
using System.IO;
using System.Drawing.Imaging;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// WbImage 的摘要说明。
	/// </summary>
	public class WbImage
	{
		/// <summary>
		/// 
		/// </summary>
		public WbImage(){}


		/// <summary>
		/// 生成缩略图,主要用于保存到服务器上的图片
		/// </summary>
		/// <param name="originalImagePath">源图路径（物理路径）</param>
		/// <param name="thumbnailPath">缩略图路径（物理路径）</param>
		/// <param name="width">缩略图宽度</param>
		/// <param name="height">缩略图高度</param>
		/// <param name="mode">生成缩略图的方式:HW,W,H,Cut</param>    
		public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
		{
			if(System.IO.File.Exists(originalImagePath)==false) throw new Exception("被创建的缩略图的源文件不存在！");
			
			System.Drawing.Image originalImage;
			originalImage=System.Drawing.Image.FromFile(originalImagePath);
			int towidth = width;
			int toheight = height;

			int x = 0;
			int y = 0;
			int ow = originalImage.Width;
			int oh = originalImage.Height;

			switch (mode)
			{
				case "HW"://指定高宽缩放（可能变形）                
					break;
				case "W"://指定宽，高按比例                    
					toheight = originalImage.Height * width / originalImage.Width;
					break;
				case "H"://指定高，宽按比例
					towidth = originalImage.Width * height / originalImage.Height;
					break;
				case "Cut"://指定高宽裁减（不变形）                
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
			g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
				new System.Drawing.Rectangle(x, y, ow, oh),
				System.Drawing.GraphicsUnit.Pixel);

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


		/// <summary>
		/// 生成缩略图,主要用于将图片上传到数据库
		/// </summary>
		/// <param name="originalImagePath">源图路径（物理路径）</param>
		/// <param name="width">缩略图宽度</param>
		/// <param name="height">缩略图高度</param>
		/// <param name="mode">生成缩略图的方式,HW为指定宽高缩放,W为指定宽度缩放,H为指定高度缩放,Cut为指定宽度裁减,其余为不缩放</param>    
		///<returns>包含缩略图的二进制数据流</returns>
		public static byte[] MakeThumbnail(string originalImagePath, int width, int height, string mode)
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
				case "HW"://指定高宽缩放（可能变形）                
					break;
				case "W"://指定宽，高按比例                    
					toheight = originalImage.Height * width / originalImage.Width;
					break;
				case "H"://指定高，宽按比例
					towidth = originalImage.Width * height / originalImage.Height;
					break;
				case "Cut"://指定高宽裁减（不变形）                
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
			g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
				new System.Drawing.Rectangle(x, y, ow, oh),
				System.Drawing.GraphicsUnit.Pixel);

			try
			{
				//输出高质量的缩略图的二进制流
				MemoryStream MemStream = new MemoryStream(); 
				System.Drawing.Imaging.ImageCodecInfo myImageCodecInfo;
				Encoder myEncoder;
				EncoderParameter myEncoderParameter;
				EncoderParameters myEncoderParameters;
				myImageCodecInfo = ImageCodecInfo.GetImageEncoders()[0];
				myEncoder = Encoder.Quality;
				myEncoderParameters = new EncoderParameters(1);
				myEncoderParameter = new EncoderParameter(myEncoder, 200L);
				myEncoderParameters.Param[0] = myEncoderParameter;
				bitmap.Save(MemStream,  myImageCodecInfo, myEncoderParameters);
				myEncoderParameter.Dispose();
				myEncoderParameters.Dispose();
				return MemStream.GetBuffer();
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


		/// <summary>
		/// 生成缩略图,主要用于将图片上传到数据库
		/// </summary>
		/// <param name="InputStream">源图的二进制流</param>
		/// <param name="width">缩略图宽度</param>
		/// <param name="height">缩略图高度</param>
		/// <param name="mode">生成缩略图的方式,HW为指定宽高缩放,W为指定宽度缩放,H为指定高度缩放,Cut为指定宽度裁减,其余为不缩放</param>    
		///<returns>包含缩略图的二进制数据流</returns>
		public static byte[] MakeThumbnail(System.IO.Stream InputStream, int width, int height, string mode)
		{
			System.Drawing.Image originalImage = System.Drawing.Image.FromStream(InputStream);

			int towidth = width;
			int toheight = height;

			int x = 0;
			int y = 0;
			int ow = originalImage.Width;
			int oh = originalImage.Height;

			switch (mode)
			{
				case "HW"://指定高宽缩放（可能变形）                
					break;
				case "W"://指定宽，高按比例                    
					toheight = originalImage.Height * width / originalImage.Width;
					break;
				case "H"://指定高，宽按比例
					towidth = originalImage.Width * height / originalImage.Height;
					break;
				case "Cut"://指定高宽裁减（不变形）                
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
			g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
				new System.Drawing.Rectangle(x, y, ow, oh),
				System.Drawing.GraphicsUnit.Pixel);

			try
			{
				//输出高质量的缩略图的二进制流
				MemoryStream MemStream = new MemoryStream(); 
				System.Drawing.Imaging.ImageCodecInfo myImageCodecInfo;
				Encoder myEncoder;
				EncoderParameter myEncoderParameter;
				EncoderParameters myEncoderParameters;
				myImageCodecInfo = ImageCodecInfo.GetImageEncoders()[0];
				myEncoder = Encoder.Quality;
				myEncoderParameters = new EncoderParameters(1);
				myEncoderParameter = new EncoderParameter(myEncoder, 200L);
				myEncoderParameters.Param[0] = myEncoderParameter;
				bitmap.Save(MemStream,  myImageCodecInfo, myEncoderParameters);
				myEncoderParameter.Dispose();
				myEncoderParameters.Dispose();
				return MemStream.GetBuffer();
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

		/// <summary>
		/// 根据图片的文件类型生成相应类型的描述对象
		/// </summary>
		/// <param name="strContentType">图片文件类型字符串</param>
		/// <returns>文件类型描述对象</returns>
		public static System.Drawing.Imaging.ImageFormat GetImageType(object strContentType) 
		{ 
			if ((strContentType.ToString().ToLower()) == "image/pjpeg") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Jpeg; 
			} 
			else if ((strContentType.ToString().ToLower()) == "image/gif") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Gif; 
			} 
			else if ((strContentType.ToString().ToLower()) == "image/bmp") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Bmp; 
			} 
			else if ((strContentType.ToString().ToLower()) == "image/tiff") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Tiff; 
			} 
			else if ((strContentType.ToString().ToLower()) == "image/x-icon") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Icon; 
			} 
			else if ((strContentType.ToString().ToLower()) == "image/x-png") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Png; 
			} 
			else if ((strContentType.ToString().ToLower()) == "image/x-emf") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Emf; 
			} 
			else if ((strContentType.ToString().ToLower()) == "image/x-exif") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Exif; 
			} 
			else if ((strContentType.ToString().ToLower()) == "image/x-wmf") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Wmf; 
			} 
			else 
			{
				return System.Drawing.Imaging.ImageFormat.MemoryBmp; 
			} 
		} 

		/// <summary>
		/// 在图片上增加文字水印
		/// </summary>
		/// <param name="Path">原服务器图片路径</param>
		/// <param name="Path_sy">生成的带文字水印的图片路径</param>
		/// <param name="Mark">水印文字</param>
		public static void AddMarkWord(string Path, string Path_sy,string Mark)
		{
			string addText = Mark;
			System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
			g.DrawImage(image, 0, 0, image.Width, image.Height);
			System.Drawing.Font f = new System.Drawing.Font("Verdana", 16);
			System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);

			g.DrawString(addText, f, b, 15, 15);
			g.Dispose();

			image.Save(Path_sy);
			image.Dispose();
		}


		/// <summary>
		/// 在图片上生成图片水印
		/// </summary>
		/// <param name="Path">原服务器图片路径</param>
		/// <param name="Path_syp">生成的带图片水印的图片路径</param>
		/// <param name="Path_sypf">水印图片路径</param>
		public static void AddMarkPic(string Path, string Path_syp, string Path_sypf)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
			System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
			g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width,copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
			g.Dispose();

			image.Save(Path_syp);
			image.Dispose();
		}
	}
}
