﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace HemNetCore.Common.Utils
{
    /// <summary>
    /// 验证码实用类
    /// </summary>
    public static class VerificationCodeUtil
    {
        /// <summary>
        /// 生成随机验证码
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomCode(int codeLength = 4)
        {
            var digitals= "1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
            var array = digitals.Split(new[] { ',' });
            var random = new Random();
            var verifiycode = string.Empty;
            var temp = -1;
            for (int i = 0; i < codeLength; i++)
            {
                if (temp != -1)
                    random = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));

                var index = random.Next(array.Length);

                if (temp != -1 && temp == index)
                    return GenerateRandomCode(codeLength);

                temp = index;

                verifiycode += array[index];
            }
            return verifiycode;
        }

        /// <summary>
        /// 生成随机验证码图片
        /// </summary>
        /// <param name="code"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static VerificationCodeResult GenerateCodeImage(string verificationCode, int width = 0, int height = 30)
        {

            //验证码颜色集合
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

            //验证码字体集合
            string[] fonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial" };

            //定义图像的大小，生成图像的实例

            var image = new  Bitmap(width == 0 ? verificationCode.Length * 25 : width, height);

            var g = Graphics.FromImage(image);

            //背景设为白色
            g.Clear(Color.White);

            var random = new Random();

            for (var i = 0; i < 100; i++)
            {
                var x = random.Next(image.Width);
                var y = random.Next(image.Height);
                g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            }

            //验证码绘制在g中  
            for (var i = 0; i < verificationCode.Length; i++)
            {
                //随机颜色索引值 
                var cindex = random.Next(c.Length);

                //随机字体索引值 
                var findex = random.Next(fonts.Length);

                //字体 
                var f = new Font(fonts[findex], 15, FontStyle.Bold);

                //颜色  
                Brush b = new SolidBrush(c[cindex]);

                var ii = 4;
                if ((i + 1) % 2 == 0)
                    ii = 2;

                //绘制一个验证字符  
                g.DrawString(verificationCode.Substring(i, 1), f, b, 17 + (i * 17), ii);
            }

            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);

            g.Dispose();
            image.Dispose();

            return new VerificationCodeResult { VerificationUUID = Guid.NewGuid().ToString().ToUpper(), VerificationCode = verificationCode, CaptchaMemoryStream = ms, Timestamp = DateTime.Now };
        }

        /// <summary>
        /// 验证码结果实体
        /// </summary>
        public class VerificationCodeResult
        {
            /// <summary>
            /// 验证ID，GUID类型
            /// </summary>
            public string VerificationUUID { get; set; }

            /// <summary>
            /// 验证码
            /// </summary>
            public string VerificationCode { get; set; }

            /// <summary>
            /// CaptchaMemoryStream
            /// </summary>
            public MemoryStream CaptchaMemoryStream { get; set; }

            /// <summary>
            /// 时间搓
            /// </summary>
            public DateTime Timestamp { get; set; }
        }

    }
}