using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductListingMVC.Models;

namespace ProductListingMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new List<Product>());
    }
    
    [HttpGet("/search/{searchTerm?}")]
    public IActionResult GetProductsByProductName(string searchTerm)
    {
        List<Product> products = GetDummyProductList();
        List<Product> filteredProducts = products.Where(p => p.Name.Contains(searchTerm)).ToList();

        return Json(filteredProducts);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private List<Product> GetDummyProductList()
    {
        return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Türk Kahvesi",
                    Description = "Geleneksel Türk kahvesi, ince öğütülmüş ve köpüklü",
                    Price = 49.90m
                },
                new Product
                {
                    Id = 2,
                    Name = "El Yapımı Çini Tabak",
                    Description = "İznik desenli, 25cm çapında el yapımı çini tabak",
                    Price = 299.50m
                },
                new Product
                {
                    Id = 3,
                    Name = "Antep Fıstıklı Baklava",
                    Description = "Taze antep fıstıklı, 1kg özel yapım baklava",
                    Price = 349.99m
                },
                new Product
                {
                    Id = 4,
                    Name = "Türk Halısı",
                    Description = "Yün el dokuma, 2x3m geleneksel Anadolu motifli halı",
                    Price = 2499.00m
                },
                new Product
                {
                    Id = 5,
                    Name = "Nazar Boncuğu",
                    Description = "El yapımı cam nazar boncuğu, duvar süsü",
                    Price = 79.90m
                },
                new Product
                {
                    Id = 6,
                    Name = "Lokum Seti",
                    Description = "Karışık lezzetli lokum seti, özel ahşap kutuda 500g",
                    Price = 129.50m
                },
                new Product
                {
                    Id = 7,
                    Name = "Bakır Cezve",
                    Description = "El işlemeli bakır cezve, 2 kişilik kahve yapımı için",
                    Price = 189.90m
                },
                new Product
                {
                    Id = 8,
                    Name = "Yağlı Boya Tablo",
                    Description = "İstanbul Boğazı manzaralı el yapımı yağlı boya tablo",
                    Price = 750.00m
                },
                new Product
                {
                    Id = 9,
                    Name = "Zeytinyağı",
                    Description = "Soğuk sıkım, organik Ayvalık zeytinyağı, 1L",
                    Price = 149.90m
                },
                new Product
                {
                    Id = 10,
                    Name = "Hamam Seti",
                    Description = "Geleneksel pamuklu peştamal, sabun ve kese içeren hamam seti",
                    Price = 279.00m
                },
                new Product
                {
                    Id = 11,
                    Name = "Ebru Sanatı Tablo",
                    Description = "Çerçeveli el yapımı ebru sanatı eseri, 30x40cm",
                    Price = 450.00m
                },
                new Product
                {
                    Id = 12,
                    Name = "Kuru Kayısı",
                    Description = "Malatya'dan özel seçim doğal kuru kayısı, 500g",
                    Price = 89.90m
                },
                new Product
                {
                    Id = 13,
                    Name = "El Dokuma Kilim",
                    Description = "Geleneksel motifli, doğal boyalı pamuk kilim, 150x200cm",
                    Price = 899.00m
                },
                new Product
                {
                    Id = 14,
                    Name = "Tahin Helvası",
                    Description = "Antep fıstıklı özel yapım tahin helvası, 400g",
                    Price = 119.90m
                },
                new Product
                {
                    Id = 15,
                    Name = "Osmanli Tespih",
                    Description = "El oyması kehribar tespih, gümüş püsküllü",
                    Price = 599.00m
                },
                new Product
                {
                    Id = 16,
                    Name = "Seramik Çay Bardağı Seti",
                    Description = "El yapımı, 6 kişilik geleneksel çay bardağı ve tabağı seti",
                    Price = 249.90m
                },
                new Product
                {
                    Id = 17,
                    Name = "Sürme Bakır Semaver",
                    Description = "Elektrikli, geleneksel el işlemeli bakır semaver, 5L",
                    Price = 1299.00m
                },
                new Product
                {
                    Id = 18,
                    Name = "Cevizli Sucuk",
                    Description = "Geleneksel Türk tatlısı, cevizli sucuk, 300g",
                    Price = 129.90m
                },
                new Product
                {
                    Id = 19,
                    Name = "Hat Sanatı Tablo",
                    Description = "El yazması hat sanatı eseri, çerçeveli, 40x60cm",
                    Price = 850.00m
                },
                new Product
                {
                    Id = 20,
                    Name = "Türk Çayı",
                    Description = "Rize'den taze toplanmış siyah çay, 1kg",
                    Price = 99.90m
                },
                new Product
                {
                    Id = 21,
                    Name = "Deri Cüzdan",
                    Description = "El yapımı hakiki deri, geleneksel motifli erkek cüzdanı",
                    Price = 399.90m
                },
                new Product
                {
                    Id = 22,
                    Name = "Kapadokya Peribacası Heykel",
                    Description = "El yapımı seramik Kapadokya peribacası biblosu, 20cm",
                    Price = 179.90m
                },
                new Product
                {
                    Id = 23,
                    Name = "Lavanta Yastığı",
                    Description = "Isparta lavantası ile doldurulmuş el işi yastık",
                    Price = 159.90m
                },
                new Product
                {
                    Id = 24,
                    Name = "Karagöz-Hacivat Kukla Seti",
                    Description = "Geleneksel Türk gölge oyunu karakterleri, deri yapım",
                    Price = 299.90m
                },
                new Product
                {
                    Id = 25,
                    Name = "Gümüş Bilezik",
                    Description = "El işlemeli, geleneksel motifli gümüş kadın bileziği",
                    Price = 799.90m
                },
                new Product
                {
                    Id = 26,
                    Name = "Yöresel Peynir Seti",
                    Description = "Farklı bölgelerden 5 çeşit geleneksel Türk peyniri, 500g",
                    Price = 249.90m
                },
                new Product
                {
                    Id = 27,
                    Name = "Ahşap Satranç Takımı",
                    Description = "El oyması ceviz ağacından Osmanlı figürlü satranç takımı",
                    Price = 649.90m
                },
                new Product
                {
                    Id = 28,
                    Name = "Türk Rakısı",
                    Description = "Geleneksel anason aromalı rakı, 70cl",
                    Price = 199.90m
                },
                new Product
                {
                    Id = 29,
                    Name = "İpek Şal",
                    Description = "El boyama Türk motifleri, %100 ipek şal",
                    Price = 379.90m
                },
                new Product
                {
                    Id = 30,
                    Name = "Sedef Kakmalı Ayna",
                    Description = "El işi sedef kakmalı duvar aynası, ahşap çerçeveli",
                    Price = 899.90m
                },
                new Product
                {
                    Id = 31,
                    Name = "Lüle Taşı Pipo",
                    Description = "El oyması Eskişehir lüle taşı pipo",
                    Price = 549.90m
                },
                new Product
                {
                    Id = 32,
                    Name = "Kuru İncir",
                    Description = "Aydın'dan özel seçim doğal kuru incir, 400g",
                    Price = 109.90m
                },
                new Product
                {
                    Id = 33,
                    Name = "El İşi Bakır Sahan",
                    Description = "Geleneksel yemekler için bakır sahan, kapaklı, 24cm",
                    Price = 329.90m
                },
                new Product
                {
                    Id = 34,
                    Name = "Keten Sofra Bezi Seti",
                    Description = "El işlemeli, 6 parça keten sofra bezi ve peçete takımı",
                    Price = 429.90m
                },
                new Product
                {
                    Id = 35,
                    Name = "Hürrem Sultan Yüzüğü Replika",
                    Description = "Gümüş ve zirkon taşlı Hürrem Sultan yüzüğü replikası",
                    Price = 499.90m
                },
                new Product
                {
                    Id = 36,
                    Name = "Divit Kalem Seti",
                    Description = "Osmanlı tarzı divit kalem ve mürekkep seti",
                    Price = 349.90m
                },
                new Product
                {
                    Id = 37,
                    Name = "Çömlekte Keşkek",
                    Description = "Geleneksel tarifte hazırlanan çömlekte keşkek, 1kg",
                    Price = 169.90m
                },
                new Product
                {
                    Id = 38,
                    Name = "Türk Delight Gift Box",
                    Description = "Turistik hediye paketi, 12 çeşit lokum ve baklava, 600g",
                    Price = 279.90m
                },
                new Product
                {
                    Id = 39,
                    Name = "Fildiş Tavla",
                    Description = "El işlemeli, fildiş kaplamalı özel tavla seti",
                    Price = 1499.90m
                },
                new Product
                {
                    Id = 40,
                    Name = "Sultan Ahmet Camii Minyatürü",
                    Description = "El yapımı, detaylı Sultan Ahmet Camii minyatürü, 30x20cm",
                    Price = 799.90m
                },
                new Product
                {
                    Id = 41,
                    Name = "Tulum Peyniri",
                    Description = "Karadeniz'den geleneksel tulum peyniri, 500g",
                    Price = 199.90m
                },
                new Product
                {
                    Id = 42,
                    Name = "Yörük Çadırı Minyatür",
                    Description = "El yapımı geleneksel Yörük çadırı minyatürü, 40x30cm",
                    Price = 599.90m
                },
                new Product
                {
                    Id = 43,
                    Name = "Bakır Kahve Değirmeni",
                    Description = "El yapımı bakır kahve değirmeni, mekanizmalı",
                    Price = 449.90m
                },
                new Product
                {
                    Id = 44,
                    Name = "Antik Gümüş Kemer",
                    Description = "El işlemeli, antik tarzda kadın gümüş kemeri",
                    Price = 1299.90m
                },
                new Product
                {
                    Id = 45,
                    Name = "Osmanlı Baharat Seti",
                    Description = "12 çeşit baharat içeren geleneksel ahşap kutu seti",
                    Price = 349.90m
                },
                new Product
                {
                    Id = 46,
                    Name = "Derviş Biblosu",
                    Description = "El yapımı seramik semazen biblosu, 25cm",
                    Price = 249.90m
                },
                new Product
                {
                    Id = 47,
                    Name = "Mevlana Şekeri",
                    Description = "Konya'dan geleneksel Mevlana şekeri, 300g",
                    Price = 89.90m
                },
                new Product
                {
                    Id = 48,
                    Name = "Dövme Bakır Mangal",
                    Description = "El yapımı dövme bakır mangal, katlanabilir, 40cm",
                    Price = 899.90m
                },
                new Product
                {
                    Id = 49,
                    Name = "İğne Oyası Yazma",
                    Description = "El yapımı iğne oyalı geleneksel başörtüsü",
                    Price = 299.90m
                },
                new Product
                {
                    Id = 50,
                    Name = "Mozaik Cam Lamba",
                    Description = "El yapımı Türk mozaik cam masa lambası",
                    Price = 599.90m
                }
            };
    }
}