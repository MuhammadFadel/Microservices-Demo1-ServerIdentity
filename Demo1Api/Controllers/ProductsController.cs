using AutoMapper;
using Demo1Api.DTOs;
using Demo1Api.Models;
using Demo1Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        private readonly IProductRepository _prod;
        protected ResponseDto _response;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository)
        {
            _db = unitOfWork;
            _mapper = mapper;
            _prod = productRepository;
            _response = new ResponseDto();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _prod.GetProducts();
                if (products == null)
                    return NoContent();

                var productsToReturn = _mapper.Map<IEnumerable<ProductListDto>>(products);
                _response.Result = productsToReturn;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message};
            }
            return Ok(_response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var product = await _prod.GetProductById(id);
                if (product == null)
                    return BadRequest();

                var productToReturn = _mapper.Map<ProductDetailedDto>(product);
                _response.Result = productToReturn;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
            }
            
            return Ok(_response);
        }

        // POST api/<ValuesController>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateDto productCreateDto)
        {
            try
            {
                if (productCreateDto == null)
                    return BadRequest("Null Product to Create");

                var productToCreate = _mapper.Map<Product>(productCreateDto);
                _db.Add(productToCreate);
                if (!await _db.SaveAll())
                    throw new Exception("Failed on save");

                _response.Result = _mapper.Map<ProductDetailedDto>(productToCreate);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
            }            

            return Ok(_response);
        }

        // PUT api/<ValuesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductCreateDto productCreateDto)
        {
            try
            {
                if (productCreateDto == null)
                    return BadRequest("No Content to Create");

                var productToUpdate = await _prod.GetProductById(id);
                if (productToUpdate == null)
                    return NoContent();

                productToUpdate.Name = productCreateDto.Name;
                productToUpdate.Price = productCreateDto.Price;
                productToUpdate.Description = productCreateDto.Description;

                _db.Update(productToUpdate);
                if (!await _db.SaveAll())
                    throw new Exception("Failed on save");

                _response.Result = _mapper.Map<ProductDetailedDto>(productToUpdate);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
            }
            
            return Ok(_response);
        }

        // DELETE api/<ValuesController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var productToDelete = await _prod.GetProductById(id);
                if (productToDelete == null)
                    return BadRequest();

                _db.Delete(productToDelete);
                if (!await _db.SaveAll())
                    throw new Exception("Failed on delete");
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
            }
            

            return Ok(_response);
        }
    }
}
