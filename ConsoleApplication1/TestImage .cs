using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Drawing;
using System.IO;
namespace ConsoleApplication1
{
   public class TestImage : MonoBehaviour
    {
       
        private string filePath;
        // Use this for initialization  
      public  void Start()
        {
            filePath = @Application.streamingAssetsPath + "/test.jpg";
            AddTextToImg("卧槽啊！小贱！");
        }

        // Update is called once per frame  
      public  void Update()
        {

        }
        private void AddTextToImg(string text)
        {
            
            //判断指定图片是否存在  
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file don't exist!");
            }
            if (text == string.Empty)
            {
                return;
            }
            Image image = Image.FromFile(filePath);
            Bitmap bitmap = new Bitmap(image, image.Width, image.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //字体大小  
            float fontSize = 40.0f;
            //文本的长度  
            float textWidth = text.Length * fontSize;
            //下面定义一个矩形区域，以后在这个矩形里画上白底黑字  
            float rectX = 120;
            float rectY = 200;
            float rectWidth = text.Length * (fontSize + 40);
            float rectHeight = fontSize + 40;
            //声明矩形域  
            RectangleF textArea = new RectangleF(rectX, rectY, rectWidth, rectHeight);
            //定义字体  
            System.Drawing.Font font = new System.Drawing.Font("微软雅黑", fontSize, System.Drawing.FontStyle.Bold);
            //font.Bold = true;  
            //白笔刷，画文字用  
            Brush whiteBrush = new SolidBrush(System.Drawing.Color.DodgerBlue);
            //黑笔刷，画背景用  
            //Brush blackBrush = new SolidBrush(Color.Black);     
            //g.FillRectangle(blackBrush, rectX, rectY, rectWidth, rectHeight);  
            g.DrawString(text, font, whiteBrush, textArea);
            //输出方法一：将文件生成并保存到C盘  
            string path = @Application.streamingAssetsPath + "/test2.jpg";
            bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            g.Dispose();
            bitmap.Dispose();
            image.Dispose();
        }
    }
}
