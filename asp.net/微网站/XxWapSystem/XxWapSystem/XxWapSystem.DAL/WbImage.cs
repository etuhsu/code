using System;
using System.IO;
using System.Drawing.Imaging;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// WbImage ��ժҪ˵����
	/// </summary>
	public class WbImage
	{
		/// <summary>
		/// 
		/// </summary>
		public WbImage(){}


		/// <summary>
		/// ��������ͼ,��Ҫ���ڱ��浽�������ϵ�ͼƬ
		/// </summary>
		/// <param name="originalImagePath">Դͼ·��������·����</param>
		/// <param name="thumbnailPath">����ͼ·��������·����</param>
		/// <param name="width">����ͼ���</param>
		/// <param name="height">����ͼ�߶�</param>
		/// <param name="mode">��������ͼ�ķ�ʽ:HW,W,H,Cut</param>    
		public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
		{
			if(System.IO.File.Exists(originalImagePath)==false) throw new Exception("������������ͼ��Դ�ļ������ڣ�");
			
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
				case "HW"://ָ���߿����ţ����ܱ��Σ�                
					break;
				case "W"://ָ�����߰�����                    
					toheight = originalImage.Height * width / originalImage.Width;
					break;
				case "H"://ָ���ߣ�������
					towidth = originalImage.Width * height / originalImage.Height;
					break;
				case "Cut"://ָ���߿�ü��������Σ�                
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

			//�½�һ��bmpͼƬ
			System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

			//�½�һ������
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

			//���ø�������ֵ��
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

			//���ø�����,���ٶȳ���ƽ���̶�
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			//��ջ�������͸������ɫ���
			g.Clear(System.Drawing.Color.Transparent);

			//��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
			g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
				new System.Drawing.Rectangle(x, y, ow, oh),
				System.Drawing.GraphicsUnit.Pixel);

			try
			{
				//��jpg��ʽ��������ͼ
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
		/// ��������ͼ,��Ҫ���ڽ�ͼƬ�ϴ������ݿ�
		/// </summary>
		/// <param name="originalImagePath">Դͼ·��������·����</param>
		/// <param name="width">����ͼ���</param>
		/// <param name="height">����ͼ�߶�</param>
		/// <param name="mode">��������ͼ�ķ�ʽ,HWΪָ���������,WΪָ���������,HΪָ���߶�����,CutΪָ����Ȳü�,����Ϊ������</param>    
		///<returns>��������ͼ�Ķ�����������</returns>
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
				case "HW"://ָ���߿����ţ����ܱ��Σ�                
					break;
				case "W"://ָ�����߰�����                    
					toheight = originalImage.Height * width / originalImage.Width;
					break;
				case "H"://ָ���ߣ�������
					towidth = originalImage.Width * height / originalImage.Height;
					break;
				case "Cut"://ָ���߿�ü��������Σ�                
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

			//�½�һ��bmpͼƬ
			System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

			//�½�һ������
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

			//���ø�������ֵ��
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

			//���ø�����,���ٶȳ���ƽ���̶�
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			//��ջ�������͸������ɫ���
			g.Clear(System.Drawing.Color.Transparent);

			//��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
			g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
				new System.Drawing.Rectangle(x, y, ow, oh),
				System.Drawing.GraphicsUnit.Pixel);

			try
			{
				//���������������ͼ�Ķ�������
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
		/// ��������ͼ,��Ҫ���ڽ�ͼƬ�ϴ������ݿ�
		/// </summary>
		/// <param name="InputStream">Դͼ�Ķ�������</param>
		/// <param name="width">����ͼ���</param>
		/// <param name="height">����ͼ�߶�</param>
		/// <param name="mode">��������ͼ�ķ�ʽ,HWΪָ���������,WΪָ���������,HΪָ���߶�����,CutΪָ����Ȳü�,����Ϊ������</param>    
		///<returns>��������ͼ�Ķ�����������</returns>
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
				case "HW"://ָ���߿����ţ����ܱ��Σ�                
					break;
				case "W"://ָ�����߰�����                    
					toheight = originalImage.Height * width / originalImage.Width;
					break;
				case "H"://ָ���ߣ�������
					towidth = originalImage.Width * height / originalImage.Height;
					break;
				case "Cut"://ָ���߿�ü��������Σ�                
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

			//�½�һ��bmpͼƬ
			System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

			//�½�һ������
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

			//���ø�������ֵ��
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

			//���ø�����,���ٶȳ���ƽ���̶�
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			//��ջ�������͸������ɫ���
			g.Clear(System.Drawing.Color.Transparent);

			//��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
			g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
				new System.Drawing.Rectangle(x, y, ow, oh),
				System.Drawing.GraphicsUnit.Pixel);

			try
			{
				//���������������ͼ�Ķ�������
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
		/// ����ͼƬ���ļ�����������Ӧ���͵���������
		/// </summary>
		/// <param name="strContentType">ͼƬ�ļ������ַ���</param>
		/// <returns>�ļ�������������</returns>
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
		/// ��ͼƬ����������ˮӡ
		/// </summary>
		/// <param name="Path">ԭ������ͼƬ·��</param>
		/// <param name="Path_sy">���ɵĴ�����ˮӡ��ͼƬ·��</param>
		/// <param name="Mark">ˮӡ����</param>
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
		/// ��ͼƬ������ͼƬˮӡ
		/// </summary>
		/// <param name="Path">ԭ������ͼƬ·��</param>
		/// <param name="Path_syp">���ɵĴ�ͼƬˮӡ��ͼƬ·��</param>
		/// <param name="Path_sypf">ˮӡͼƬ·��</param>
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
