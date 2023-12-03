using _2nd.Data;

using _2nd.Model;
using _2nd.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2nd.Controllers
{
    [Route("api/Sohag")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        public CouponController(AppDbContext db)
        {
            _db = db;
            _responseDto = new ResponseDto();
        }
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> CouponList = _db.coupons.ToList();
                _responseDto.Result = CouponList;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.message = ex.Message;
            }
           
            return _responseDto; 
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon CouponList = _db.coupons.First(x=> x.CouponId==id);
                CouponDto couponDto = new CouponDto()
                {
                    CouponId = CouponList.CouponId,
                    CouponCode = CouponList.CouponCode,
                    DiscountAmount = CouponList.DiscountAmount,
                    MinAmount = CouponList.MinAmount,  
                };
                _responseDto.Result = couponDto;
            }
            catch (Exception ex)
            {

                _responseDto.message = $"এই {id} Id দিয়া কোনো ডাটা পাওয়া যাই নাই। ";
                _responseDto.IsSuccess = false;
            }
            return _responseDto;

        }
        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto xyz)
        {
            try
            {
                Coupon coupon = new Coupon()
                {
                    CouponCode = xyz.CouponCode,
                    DiscountAmount = xyz.DiscountAmount,
                    MinAmount = xyz.MinAmount,
                };

                _db.coupons.Add(coupon);
                _db.SaveChanges();

                _responseDto.Result = xyz;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess  =false;
                _responseDto.message = ex.Message;
            }

            return _responseDto;
            
        }
        [HttpPut]
        public object Put()
        {
            return Ok();
        }
        [HttpDelete]
        public object Delete()
        {
            return Ok();
        }
    }
}
