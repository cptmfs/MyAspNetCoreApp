using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAspNetCoreApp.Web.TagHelpers
{
    [HtmlTargetElement("thumbnail")] //taghelper'a custom isim verme
    public class ImageThumbnailTagHelper:TagHelper
    {

        // Kullanıcıdan alınan resimlerin görsellerin istediğimiz piksel boyutlarında sitemizde göstermek için .. Hazır bir tag helper yazalım..
        public string ImageSrc { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img"; //<img/>
            string fileName = ImageSrc.Split(".")[0]; // Split ile 2 parçaya böleceğiz , 1.png 1 ve png olarak iki parçaya bölmüş olacak..
            string fileExtensions = Path.GetExtension(ImageSrc); // gelen uzantıyı vericek bize .jpg yada .png gibi.

            output.Attributes.SetAttribute("src", $"{fileName}-100x100{fileExtensions}");
        }
    }
}
