using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesignExamples.NonCRUD.Migrations.SampleData
{
    //public class ProductData
    //{
    //    private readonly IGenericProductRepository _productRepository;

    //    public ProductData(IGenericProductRepository productRepository)
    //    {
    //        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    //    }
    //    public async Task PopulateData()
    //    {
    //        var productData = GetInitialProductData();
    //        foreach (var product in productData)
    //        {
    //            await _productRepository.Create(product);
    //        }
    //    }

    //    private IEnumerable<Product.Product> GetInitialProductData()
    //    {
    //        var data = new[]
    //        {
    //            new
    //            {
    //                Id = "6E5D5D3C-867C-DDD1-C1D6-30D22645979A",
    //                Name = "Cast Iron Planter Pot"
    //            },
    //            new
    //            {
    //                Id = "A4DB31DB-72C1-DEE5-4756-45A6F3327643",
    //                Name = "3D Printed Coat Hanger"
    //            },
    //            new
    //            {
    //                Id = "5433E73B-EECE-A12F-7227-0D2ED036AB62",
    //                Name = "Bone Cutlery"
    //            },
    //            new
    //            {
    //                Id = "B778CB31-1BEE-D625-92C1-B4CAA40B1991",
    //                Name = "Mercury Walking Cane"
    //            },
    //            new
    //            {
    //                Id = "B7D1414C-24CE-13D6-10DF-7E6E5A94C327",
    //                Name = "Silicone Jewelry Box"
    //            },
    //            new
    //            {
    //                Id = "01D8DAC7-83FD-252F-E344-5949C89E5691",
    //                Name = "Steel Keyboard"
    //            },
    //            new
    //            {
    //                Id = "BB805173-CB19-BE1B-6AC6-CE82283F61C3",
    //                Name = "Corrosive Floor Lamp"
    //            },
    //            new
    //            {
    //                Id = "50F089C2-0D5B-C4E6-0D0F-5B136DE1B18F",
    //                Name = "Ivory Sofa"
    //            },
    //            new
    //            {
    //                Id = "FDB383E8-6366-BBC7-AAA5-3A4AA45EF7C8",
    //                Name = "Floating Tape Dispenser"
    //            },
    //            new
    //            {
    //                Id = "84497D5F-3664-4216-2295-9B46798C8A8B",
    //                Name = "Carbon Fiber Dresser"
    //            }
    //        };

    //        return data.Select(d => new Product.Product
    //        {
    //            Id = new Guid(d.Id),
    //            Name = d.Name
    //        });
    //    }
    //}
}