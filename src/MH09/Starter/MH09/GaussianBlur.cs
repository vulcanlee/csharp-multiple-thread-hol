using SkiaSharp;

namespace MH09;

public class ImageItem
{
    public string ImageUrl { get; set; }
    public string ImagePath { get; set; }
    public string ImageConvertPath { get; set; }
}
public class GaussianBlur
{
    public async Task ProcessAsync()
    {
        List<ImageItem> imageItems = new List<ImageItem>();

        // 建立圖片來源
        imageItems.Clear();
        for (int i = 1; i <= 30; i++)
        {
            imageItems.Add(new ImageItem
            {
                ImageUrl = $"https://vulcanmvpfiles.blob.core.windows.net/$web/share/2024/Images/sample{i}.jpg",
                ImagePath = $@"sample{i}.jpg",
                ImageConvertPath = $@"sample{i}-Convert.jpg"
            });
        }

        foreach (var item in imageItems)
        {
            // 下載圖片
            await Console.Out.WriteLineAsync($"下載圖片 {item.ImagePath}");
            await DownloadImageAsync(item.ImageUrl, item.ImagePath);

            // 影像去噪
            await Console.Out.WriteLineAsync($"影像去噪 {item.ImagePath}");
            ApplyGaussianBlur(item.ImagePath, item.ImageConvertPath, 10f);
        }
    }

    private static async Task DownloadImageAsync(string imageUrl, string imagePath)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(imageUrl);
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                using (var fileStream = File.Create(imagePath))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }
    }

    static void ApplyGaussianBlur(string inputImagePath, string outputImagePath, float sigma = 5.0f)
    {
        // 加载图像
        using (var inputStream = File.OpenRead(inputImagePath))
        using (var originalBitmap = SKBitmap.Decode(inputStream))
        {
            // 创建一个新的图像，用于绘制处理后的图像
            using (var surface = SKSurface.Create(new SKImageInfo(originalBitmap.Width, originalBitmap.Height)))
            {
                var canvas = surface.Canvas;

                // 使用高斯模糊滤镜
                var paint = new SKPaint
                {
                    IsAntialias = true,
                    FilterQuality = SKFilterQuality.High,
                    ImageFilter = SKImageFilter.CreateBlur(sigma, sigma)
                };

                // 绘制原始图像应用高斯模糊
                canvas.DrawBitmap(originalBitmap, 0, 0, paint);

                // 保存处理后的图像
                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Jpeg, 100))
                using (var outputStream = File.OpenWrite(outputImagePath))
                {
                    data.SaveTo(outputStream);
                }
            }
        }
    }
}
