using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpryCoder.WebcamCaptureTool
{
    public static class CamUtil
    {
        private const int width = 640;
        private const int height = 480;

        private const string wuCamFtp = "webcam.wunderground.com";

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
            string output;

            output = input;
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

        public static async Task<Image> CaptureImage(CaptureType CapType)
        {
            Image image = null;
            Bitmap bitmap = null;
            Image finalImage;

            try
            {
                if (CapType == CaptureType.FinalImage)
                {
                    // Http Post Request/Response
                    System.Net.WebRequest request = System.Net.WebRequest.Create(string.Format("http://{0}/{1}", Properties.Settings.Default.IPAddress.ToString(), Properties.Settings.Default.SnapshotUrl.ToString()));
                    System.Net.NetworkCredential creds = new System.Net.NetworkCredential(Properties.Settings.Default.Username.ToString(), PasswordMgmt.DecryptString(Properties.Settings.Default.Password.ToString()));
                    request.Credentials = creds;
                    request.Method = "POST";
                    System.Net.WebResponse response = await request.GetResponseAsync();
                    System.IO.Stream stream = response.GetResponseStream();

                    // Image
                    image = System.Drawing.Image.FromStream(stream);
                }
                else if (CapType == CaptureType.OptionPreviewImage)
                {
                    bitmap = new Bitmap(width, height);
                }


                finalImage = (image == null) ? bitmap : image;


                using (Graphics g = Graphics.FromImage(finalImage))
                {
                    // Full preview picture rectangle fill
                    if (finalImage == bitmap) g.FillRectangle(Brushes.Green, new Rectangle(0, 0, width, height));

                    // Brush for transparency
                    Brush semiTransBrush = new SolidBrush(Color.FromArgb(CamUtil.CalculateTransparency(Properties.Settings.Default.OverlayTransparency), 176, 176, 176));

                    // Right alignment string format
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Far;

                    // Top Overlay
                    if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.OverlayTopLeftText) || !string.IsNullOrWhiteSpace(Properties.Settings.Default.OverlayTopRightText))
                    {
                        // Top Overlay rectangle with transparency
                        RectangleF rectfTop = new RectangleF(0, 0, width, 20);
                        g.FillRectangle(semiTransBrush, rectfTop);

                        // Top Left Text
                        g.DrawString(CamUtil.TemplateReplace(Properties.Settings.Default.OverlayTopLeftText), new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, 5, 6);

                        // Top Right Text
                        g.DrawString(CamUtil.TemplateReplace(Properties.Settings.Default.OverlayTopRightText), new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, width - 5, 6, sf);
                    }

                    // Bottom Overlay
                    if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.OverlayBottomLeftText) || !string.IsNullOrWhiteSpace(Properties.Settings.Default.OverlayBottomRightText))
                    {
                        // Bottom Overlay rectangle with transparency
                        RectangleF rectfBottom = new RectangleF(0, height - 20, width, 20);
                        g.FillRectangle(semiTransBrush, rectfBottom);

                        // Bottom Left Text
                        g.DrawString(CamUtil.TemplateReplace(Properties.Settings.Default.OverlayBottomLeftText), new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, 5, 465);

                        // Bottom Right Text
                        g.DrawString(CamUtil.TemplateReplace(Properties.Settings.Default.OverlayBottomRightText), new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, width - 5, 465, sf);
                    }
                }

                // TODO: Bitmap dispose?

                return finalImage;

            }
            catch
            {
                throw;
            }
        }

        public static void UploadWUCamImage(string username, string password, Image image)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + wuCamFtp + "/image.jpg");
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(username, password);

                // Copy the contents of the file to the request stream.
                MemoryStream imageStream = new MemoryStream();
                image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);

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
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
