using DDAC_API.Data;
using DDAC_API.Models;
using DDAC_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly DDAC_Context _context;

        public OrderController(DDAC_Context context)
        {
            _context = context;
        }

        [HttpPut("updateOrder")]
        public async Task<ActionResult> PutOrder(Order order)
        {

            _context.Entry(order).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.
                Include(a => a.Customer).
                 Include(a => a.OrderItems).
                 ThenInclude(a => a.Album).
                 ThenInclude(a => a.AlbumPhotos).
                 FirstOrDefaultAsync(a => a.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpGet("total_buyers")]
        public ActionResult<int> TotalBuyers(DateTime timeFrom, DateTime timeTo, int orderStatus = 0)
        {

            IQueryable<Order> orders = _context.Orders;

            if (timeFrom != null && timeTo != null)
            {
                orders = orders.Where(a => a.CreatedDate >= timeFrom).Where(a => a.CreatedDate <= timeTo);
            }

            if (orderStatus != 0)
            {
                if(orderStatus == 1)
                {
                    orders = orders.Where(a => a.Status == (int)OrderStatusEnum.Paid || a.Status == (int)OrderStatusEnum.Shipped || a.Status == (int)OrderStatusEnum.Completed);

                }
                else
                {
                    orders = orders.Where(a => a.Status == orderStatus);

                }

            }

            var result = orders.GroupBy(a=>a.CustomerId).Count();

            return result;
        }

        [HttpGet("total_orders")]
        public ActionResult<int> TotalOrders(DateTime timeFrom, DateTime timeTo, int orderStatus = 0)
        {

            IQueryable<Order> orders = _context.Orders;

            if (timeFrom != null && timeTo != null)
            {
                orders = orders.Where(a => a.CreatedDate >= timeFrom).Where(a => a.CreatedDate <= timeTo);

            }

            if (orderStatus != 0)
            {
                if (orderStatus == 1)
                {
                    orders = orders.Where(a => a.Status == (int)OrderStatusEnum.Paid || a.Status == (int)OrderStatusEnum.Shipped || a.Status == (int)OrderStatusEnum.Completed);

                }
                else
                {
                    orders = orders.Where(a => a.Status == orderStatus);

                }

            }

            var result = orders.GroupBy(e=>e.OrderId).Count();

            return result;
        }

        [HttpGet("total_sales")]
        public ActionResult<double> TotalSales(DateTime timeFrom, DateTime timeTo, int orderStatus = 0)
        {

            IQueryable<Order> orders = _context.Orders;

            if (timeFrom != null && timeTo != null)
            {
                orders = orders.Where(a => a.CreatedDate >= timeFrom).Where(a => a.CreatedDate <= timeTo);

            }

            if (orderStatus != 0)
            {
                if (orderStatus == 1)
                {
                    orders = orders.Where(a => a.Status == (int)OrderStatusEnum.Paid || a.Status == (int)OrderStatusEnum.Shipped || a.Status == (int)OrderStatusEnum.Completed);

                }
                else
                {
                    orders = orders.Where(a => a.Status == orderStatus);

                }

            }

            var result = orders.SelectMany(a => a.OrderItems).Sum(e => e.Quantity * e.Price);

            return result;
        }

        [HttpGet("get_orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(DateTime timeFrom, DateTime timeTo, int pageNumber = 1, int pageSize = 15, int order_id = 0, int orderStatus = 0)
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            IQueryable<Order> orders = _context.Orders;

            if(timeFrom != null && timeTo != null)
            {
                orders = orders.Where(a => a.CreatedDate >= timeFrom).Where(a=>a.CreatedDate <= timeTo);
                
            }

            if(order_id != 0)
            {
                orders = orders.Where(a => a.OrderId == order_id);

            }

            if (orderStatus != 0)
            {
                orders = orders.Where(a => a.Status == orderStatus);

            }

            var result = await orders.
                 Include(a => a.Customer).
                 Include(a => a.OrderItems).
                 ThenInclude(a=>a.Album).
                 ThenInclude(a=>a.AlbumPhotos).
                 OrderByDescending(e => e.OrderId).
                 Skip(excludeRecords).
                 Take(pageSize).
                 ToListAsync();

            return result;
        }

        [HttpPost("postOrder")]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrder", new { id = order.OrderId}, order);
        }

        [HttpGet("count_orders")]
        public ActionResult<int> CountOrders(DateTime timeFrom, DateTime timeTo, int order_id = 0, int orderStatus = 0)
        {

            IQueryable<Order> orders = _context.Orders;

            if (timeFrom != null && timeTo != null)
            {
                orders = orders.Where(a => a.CreatedDate >= timeFrom).Where(a => a.CreatedDate <= timeTo);

            }

            if (order_id != 0)
            {
                orders = orders.Where(a => a.OrderId == order_id);

            }

            if (orderStatus != 0)
            {
                orders = orders.Where(a => a.Status == orderStatus);

            }
            var result = orders.GroupBy(e => e.OrderId).Count();


            return result;
        }

        [HttpGet("count_orders_history")]
        public ActionResult<int> CountOrdersHistory(DateTime timeFrom, DateTime timeTo, int customer_id = 0,  int orderStatus = 0)
        {

            IQueryable<Order> orders = _context.Orders;

            if (timeFrom != null && timeTo != null)
            {
                orders = orders.Where(a => a.CreatedDate >= timeFrom).Where(a => a.CreatedDate <= timeTo);

            }

         
            if (customer_id != 0)
            {
                orders = orders.Where(a => a.CustomerId == customer_id);

            }

            if (orderStatus != 0)
            {
                orders = orders.Where(a => a.Status == orderStatus);

            }
            var result = orders.GroupBy(e => e.OrderId).Count();


            return result;
        }

        [HttpGet("get_orders_history")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersHistory(DateTime timeFrom, DateTime timeTo, int pageNumber = 1, int pageSize = 15, int customer_id = 0,  int orderStatus = 0)
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            IQueryable<Order> orders = _context.Orders;

            if (timeFrom != null && timeTo != null)
            {
                orders = orders.Where(a => a.CreatedDate >= timeFrom).Where(a => a.CreatedDate <= timeTo);

            }

            
            if (customer_id != 0)
            {
                orders = orders.Where(a => a.CustomerId == customer_id);

            }
            if (orderStatus != 0)
            {
                orders = orders.Where(a => a.Status == orderStatus);

            }

            var result = await orders.
                 Include(a => a.Customer).
                 Include(a => a.OrderItems).
                 ThenInclude(a => a.Album).
                 ThenInclude(a => a.AlbumPhotos).
                 OrderByDescending(e => e.OrderId).
                 Skip(excludeRecords).
                 Take(pageSize).
                 ToListAsync();

            return result;
        }
    }
}
