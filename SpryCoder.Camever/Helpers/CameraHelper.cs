using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using SpryCoder.Camever.Properties;

namespace SpryCoder.Camever.Helpers
{
    public static class CameraHelper
    {
        private const int Width = 640;
        private const int Height = 480;

        private const string WuCamFtp = "webcam.wunderground.com";

        public enum CaptureType { OptionPreviewImage, FinalImage }
        public static DateTime NextCaptureTime(DateTime dt, double minuteInterval)
        {
            // Usage:
            // var dt3 = RoundUp(DateTime.Parse("2011-08-11 17:01"), TimeSpan.FromMinutes(15));
            // dt3 == {11/08/2011 17:15:00}

            //return new DateTime(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks);
            TimeSpan d = TimeSpan.FromMinutes(minuteInterval);

            return new DateTime(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks);
        }

        public static int CalculateTransparency(int value)
        {
            int slider = value;
            double percent = (slider / 1000.0) * 100;
            return (int)(255 * percent);
        }

        public static string TemplateReplace(string input)
        {
            var output = input;
            output = output.Replace("{monthno}", DateTime.Now.ToString("MM"));
            output = output.Replace("{month}", DateTime.Now.ToString("MMM"));
            output = output.Replace("{day}", DateTime.Now.ToString("dd"));
            output = output.Replace("{year4}", DateTime.Now.ToString("yyyy"));
            output = output.Replace("{year2}", DateTime.Now.ToString("yy"));
            output = output.Replace("{12hour}", DateTime.Now.ToString("hh"));
            output = output.Replace("{24hour}", DateTime.Now.ToString("HH"));
            output = output.Replace("{min}", DateTime.Now.ToString("mm"));
            output = output.Replace("{sec}", DateTime.Now.ToString("ss"));
            output = output.Replace("{ampm}", DateTime.Now.ToString("tt"));

            return output;
        }

        public static async Task<Image> CaptureImage(CaptureType capType)
        {

            // DEBUG/Tracing
            //var st = new StackTrace();
            //var sfMethodCalling = st.GetFrame(1).GetMethod().DeclaringType.FullName;
            //LogHelper.WriteLogEntry(sfMethodCalling, LogHelper.LogEntryType.Information);

            Image image = null;
            Bitmap bitmap = null;
            Image finalImage;

            if (capType == CaptureType.FinalImage)
            {
                // Http Post Request/Response
                WebRequest request = WebRequest.Create(
                    $"http://{Settings.Default.CameraHostname}/{Settings.Default.SnapshotUrl}");
                NetworkCredential creds = new NetworkCredential(Settings.Default.Username, PasswordHelper.DecryptString(Settings.Default.Password));
                request.Credentials = creds;
                request.Method = "POST";
                WebResponse response = await request.GetResponseAsync().ConfigureAwait(false);
                Stream stream = response.GetResponseStream();

                // Image
                if (stream != null) image = Image.FromStream(stream);
            }
            else if (capType == CaptureType.OptionPreviewImage)
            {
                bitmap = new Bitmap(Width, Height);
            }


            finalImage = image ?? bitmap;


            if (finalImage != null)
            {
                using (Graphics g = Graphics.FromImage(finalImage))
                {
                    // Full preview picture rectangle fill
                    if (finalImage == bitmap) g.FillRectangle(Brushes.Green, new Rectangle(0, 0, Width, Height));

                    // Brush for transparency
                    Brush semiTransBrush = new SolidBrush(Color.FromArgb(CalculateTransparency(Settings.Default.OverlayTransparency), 176, 176, 176));

                    // Right alignment string format
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Far;

                    // Top Overlay
                    if (!string.IsNullOrWhiteSpace(Settings.Default.OverlayTopLeftText) || !string.IsNullOrWhiteSpace(Settings.Default.OverlayTopRightText))
                    {
                        // Top Overlay rectangle with transparency
                        RectangleF rectfTop = new RectangleF(0, 0, Width, 20);
                        g.FillRectangle(semiTransBrush, rectfTop);

                        // Top Left Text
                        g.DrawString(TemplateReplace(Settings.Default.OverlayTopLeftText), new Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, 5, 6);

                        // Top Right Text
                        g.DrawString(TemplateReplace(Settings.Default.OverlayTopRightText), new Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, Width - 5, 6, sf);
                    }

                    // Bottom Overlay
                    if (!string.IsNullOrWhiteSpace(Settings.Default.OverlayBottomLeftText) || !string.IsNullOrWhiteSpace(Settings.Default.OverlayBottomRightText))
                    {
                        // Bottom Overlay rectangle with transparency
                        RectangleF rectfBottom = new RectangleF(0, Height - 20, Width, 20);
                        g.FillRectangle(semiTransBrush, rectfBottom);

                        // Bottom Left Text
                        g.DrawString(TemplateReplace(Settings.Default.OverlayBottomLeftText), new Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, 5, 465);

                        // Bottom Right Text
                        g.DrawString(TemplateReplace(Settings.Default.OverlayBottomRightText), new Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, Width - 5, 465, sf);
                    }
                }

                // TODO: Bitmap dispose?

                
            }

            return finalImage;
        }

        public static async Task UploadWuCamImage(string username, string password, Image image)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + WuCamFtp + "/image.jpg");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username, password);

            // Copy the contents of the file to the request stream.
            MemoryStream imageStream = new MemoryStream();
            image.Save(imageStream, ImageFormat.Jpeg);

            // Read image into a byte array
            byte[] bytes = imageStream.ToArray();

            // Write the bytes into the request stream
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            // Get response
            FtpWebResponse response = (FtpWebResponse) await request.GetResponseAsync();
            response.Close();
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
