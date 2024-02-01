using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI.Models.Entity;
using WebAPI.Models.Product;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly TruongVanPhatContext _context;
        public ProductController(TruongVanPhatContext context)
        {
            _context = context;
        }
        //api get all data
        [HttpGet("danh-sach1")] //http://localhost:5464/api/Product/sanh-sach
        public IActionResult Danhsach1()
        {
            var item = _context.Products.Select
            return Ok(item);
        }
        [HttpGet("danh-sach")] //http://localhost:5464/api/Product/sanh-sach
        public IActionResult Danhsach()
        {
            var item = _context.Products.ToList();
            return Ok(item);
        }
        //get 1 data co tham so dau vao
        [HttpGet("{id}")]
        public IActionResult itemProduct(string id)
        {
            var item = _context.Products.FirstOrDefault(c => c.Id == id);
            return Ok(item);

        }
        //API delete
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var item = _context.Products.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _context.Products.Remove(item);
                _context.SaveChanges();
            }
            return Ok(item);

        }
        [HttpPost("tao-moi")]
        public IActionResult Create([FromForm] InputProduct input)
        {
            if(ModelState.IsValid)
            {
                Product product= new Product();
                product.TenSanPham=input.TenSanPham;
                product.Mota=input.Mota;
                product.Gia=input.Gia;
                product.Filter= input.TenSanPham+" " +input.Mota;
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }

            return BadRequest();
        }
        [HttpPut("cap-nhat/{id}")]
        public IActionResult Update( Guid id, [FromForm] InputProduct input)
        {
            var item = _context.Products.FirstOrDefault(c => c.Id == id.ToString());
            if(item != null) 
            { 
                item.TenSanPham=input.TenSanPham;
                item.Mota=input.Mota;
                item.Gia=input.Gia;
                item.Filter = input.Mota + " " + input.Gia + " " + input.TenSanPham;
                _context.Products.Update(item);
                _context.SaveChanges();
                return Ok(item);
            }
            return NotFound();
        }
    }
}
