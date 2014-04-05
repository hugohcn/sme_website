using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public static class PhotoUtils {

    // *** Jpeg Format ***
    private static ImageCodecInfo GetEncoderInfo(string mimeType) {
        int j;
        ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
        for (j = 0; j < encoders.Length; ++j) {
            if (encoders[j].MimeType == mimeType)
                return encoders[j];
        }
        return null;
    }

    public static void SaveToJpeg(Bitmap bitmap, string filePath, long qualityPercent) {
        ImageCodecInfo imageCodecInfo = GetEncoderInfo("image/jpeg");
        Encoder encoder = Encoder.Quality;
        EncoderParameters encoderParameters = new EncoderParameters(1);
        encoderParameters.Param[0] = new EncoderParameter(encoder, qualityPercent);
        bitmap.Save(filePath, imageCodecInfo, encoderParameters);
    }

    // *** Thumbnails ***
    public static Bitmap CreateThumbnail(Image image, int thumbnailSize) {
        int w;
        int h;
        if (image.Width > image.Height) {
            h = thumbnailSize;
            w = (int)((image.Width * (float)h) / (float)image.Height);
        }
        else {
            w = thumbnailSize;
            h = (int)((image.Height * (float)w) / (float)image.Width);
        }
        Bitmap newImage = new Bitmap(thumbnailSize, thumbnailSize, PixelFormat.Format24bppRgb);
        using (Graphics canvas = Graphics.FromImage(newImage)) {
            canvas.SmoothingMode = SmoothingMode.AntiAlias;
            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
            canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
            canvas.DrawImage(image, new Rectangle(0, 0, w, h));
        }
        return newImage;
    }

    public static void CreateThumbnailFile(string filePath, int thumbnailSize,
        string thumbnailFilePath, long qualityPercent) {

        using (FileStream stream = new FileStream(filePath, FileMode.Open)) {
            using (System.Drawing.Image image =
                System.Drawing.Image.FromStream(stream)) {

                if (image.Width == thumbnailSize && image.Height == thumbnailSize) {
                    File.Copy(filePath, thumbnailFilePath, true);
                }
                else {
                    using (Bitmap bitmap =
                        CreateThumbnail(image, thumbnailSize)) {
                        SaveToJpeg(bitmap, thumbnailFilePath, qualityPercent);
                    }
                }
            }
        }
    }

    public static void CreateThumbnailFile(string filePath, int thumbnailSize,
        string thumbnailFilePath) {
        CreateThumbnailFile(filePath, thumbnailSize, thumbnailFilePath, 90L);
    }
}
