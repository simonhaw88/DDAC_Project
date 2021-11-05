using DDAC_Project.Helper;
using DDAC_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDAC_Project.Controllers
{
    public class OrderController : Controller
    {
        ApiHelper _api = new ApiHelper();
        private HttpClient client;
        private readonly string seassion_userId = "userId";
        private readonly string seassion_role = "role";
        public OrderController()
        {
            client = _api.Initial();
        }

        [HttpPost]
        public async Task<IActionResult> PostCheckout(List<CartItem> cartItems)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Auth");
            }

            //get customer id
            int customerId = 0;

            Customer customer = new Customer();
            HttpResponseMessage responseGetCustomer = await this.client.GetAsync($"api/customer?userId={userId}");
            if (responseGetCustomer.IsSuccessStatusCode)
            {
                var result = responseGetCustomer.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result);
                customerId = customer.CustomerId;
            }
            if (customerId != 0)
            {
                Order order = new Order()
                {
                    CreatedDate = DateTime.Now,
                    Status = (int)OrderStatusEnum.Unpaid,
                    Line = customer.Address.Line,
                    City = customer.Address.City,
                    Region = customer.Address.Region,
                    PostCode = customer.Address.PostCode,
                    Country = customer.Address.Country,
                    CustomerId = customerId,
                };
                List<OrderItem> orderItems = new List<OrderItem>();
                foreach (var item in cartItems)
                {
                    if (item.IsSelected)
                    {
                        OrderItem orderItem = new OrderItem()
                        {
                            Quantity = item.Quantity,
                            Price = item.Price,
                            AlbumId = item.AlbumId,
                        };
                        orderItems.Add(orderItem);
                    }
                }
                order.OrderItems = orderItems;
                HttpResponseMessage responsePostOrder = await this.client.PostAsJsonAsync(
                                   "api/order/postOrder", order);
                if (!responsePostOrder.IsSuccessStatusCode)
                {
                    TempData["fail"] = await responsePostOrder.Content.ReadAsStringAsync();
                    return RedirectToAction("Checkout");
                }
                else
                {
                    var result = responsePostOrder.Content.ReadAsStringAsync().Result;
                    order = JsonConvert.DeserializeObject<Order>(result);
                    foreach (var item in cartItems)
                    {
                        HttpResponseMessage responseDelete = await this.client.DeleteAsync(
                                     $"api/cartItem/delete/{item.CartItemId}");

                        if (!responseDelete.IsSuccessStatusCode)
                        {
                            TempData["fail"] = await responseDelete.Content.ReadAsStringAsync();
                            return RedirectToAction("Checkout");

                        }
                    }
                    HttpContext.Session.SetInt32("orderId", order.OrderId);
                }
            }
            return RedirectToAction("SubmitAddress");

        }

        [HttpPost]
        public IActionResult PayOrder(int orderId)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }

            HttpContext.Session.SetInt32("orderId", orderId);
            return RedirectToAction("SubmitAddress");
        }

        public IActionResult SubmitPayment()
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }
                return View();
        }

        public async Task<IActionResult> CompletePayment()
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            
            }
            var order_id = HttpContext.Session.GetInt32("orderId");
            if (order_id.HasValue)
            {
                Order orderDb = new Order();
                HttpResponseMessage responseGetOrder = await this.client.GetAsync($"api/order/{order_id}");
                if (responseGetOrder.IsSuccessStatusCode)
                {
                    var result = responseGetOrder.Content.ReadAsStringAsync().Result;
                    orderDb = JsonConvert.DeserializeObject<Order>(result);
                    orderDb.Status = (int)OrderStatusEnum.Paid;
                    HttpResponseMessage responseUpdateOrder = await client.PutAsJsonAsync("api/order/updateOrder", orderDb);
                    if (responseUpdateOrder.IsSuccessStatusCode)
                    {
                        HttpContext.Session.Remove("orderId");
                    }
                }

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress(Order order)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }

            var order_id = HttpContext.Session.GetInt32("orderId");
            if (order_id.HasValue)
            {
                Order orderDb = new Order();
                HttpResponseMessage responseGetOrder = await this.client.GetAsync($"api/order/{order_id}");
                if (responseGetOrder.IsSuccessStatusCode)
                {
                    var result = responseGetOrder.Content.ReadAsStringAsync().Result;
                    orderDb = JsonConvert.DeserializeObject<Order>(result);

                    orderDb.Line = order.Line;
                    orderDb.City = order.City;
                    orderDb.Region = order.Region;
                    orderDb.PostCode = order.PostCode;
                    orderDb.Country = order.Country;

                    HttpResponseMessage responseUpdateOrder = await client.PutAsJsonAsync("api/order/updateOrder", orderDb);
                    if (responseUpdateOrder.IsSuccessStatusCode)
                    {
                        return RedirectToAction("SubmitPayment");
                    }
                    else
                    {
                        ModelState.AddModelError("fail", await responseUpdateOrder.Content.ReadAsStringAsync());
                    }
                }

            }
            else
            {
                ModelState.AddModelError("fail", "Order does not exist");
            }
            return View("SubmitAddress");
        }

        public async Task<IActionResult> SubmitAddress()
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }

            Order order = new Order();
            var order_id = HttpContext.Session.GetInt32("orderId");
            if (order_id.HasValue)
            {
                HttpResponseMessage responseGetOrder = await this.client.GetAsync($"api/order/{order_id}");
                if (responseGetOrder.IsSuccessStatusCode)
                {
                    var result = responseGetOrder.Content.ReadAsStringAsync().Result;
                    order = JsonConvert.DeserializeObject<Order>(result);
                }

            }
             var message = TempData["fail"];
            if (message != null)
            {
                ModelState.AddModelError("fail", message.ToString());

            }
            return View(order);
        }

       
        [HttpGet]
        public async Task<IActionResult> Search(string timeFrom, string timeTo, int order_id = 0, int order_status = 0, int pageNumber = 1)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin && role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (timeFrom == null && timeTo == null)
            {
                timeFrom = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                timeTo = DateTime.Now.ToString("yyyy-MM-dd");
            }
            //get orders
            List<Order> orders = new List<Order>();
            int pageSize = 15;
            HttpResponseMessage responseGetOrders = await this.client.GetAsync(
                $"api/order/get_orders?pageSize={pageSize}&pageNumber={pageNumber}&timeFrom={timeFrom}&timeTo={timeTo}&order_id={order_id}&orderStatus={order_status}");
            if (responseGetOrders.IsSuccessStatusCode)
            {
                var result = responseGetOrders.Content.ReadAsStringAsync().Result;
                orders = JsonConvert.DeserializeObject<List<Order>>(result);
            }

            //get orders count
            int order_count = 0;
            HttpResponseMessage responseOrdersCount = await this.client.GetAsync(
                $"api/order/count_orders?timeFrom={timeFrom}&timeTo={timeTo}&order_id={order_id}&orderStatus={order_status}");
            if (responseOrdersCount.IsSuccessStatusCode)
            {
                var result = responseOrdersCount.Content.ReadAsStringAsync().Result;
                order_count = Convert.ToInt32(result);
            }
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.totalItems = order_count;
            ViewBag.Url = "Order";
            ViewBag.Orders = orders;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Completed(int id)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }

            Order order = new Order();
            HttpResponseMessage responseGetOrder = await this.client.GetAsync(
                $"api/order/{id}");
            if (responseGetOrder.IsSuccessStatusCode)
            {
                var result = responseGetOrder.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<Order>(result);
            }
            if (order == null)
            {
                TempData["fail"] = "Order not exist";
                return RedirectToAction("History");
            }


            order.Status = (int)OrderStatusEnum.Completed;
            //update order status
            HttpResponseMessage responseUpdateStatus = await client.PutAsJsonAsync("api/order/updateOrder", order);
            if (!responseUpdateStatus.IsSuccessStatusCode)
            {
                TempData["fail"] = await responseUpdateStatus.Content.ReadAsStringAsync();
                return RedirectToAction("History");

            }
            TempData["success"] = "Order has been completed.";
            return RedirectToAction("History");
        }

        [HttpGet]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }

            Order order = new Order();
            HttpResponseMessage responseGetOrder = await this.client.GetAsync(
                $"api/order/{id}");
            if (responseGetOrder.IsSuccessStatusCode)
            {
                var result = responseGetOrder.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<Order>(result);
            }
            if (order == null)
            {
                TempData["fail"] = "Order not exist";
                return RedirectToAction("History");
            }

            
            order.Status = (int)OrderStatusEnum.Cancelled;

            //update order status
            HttpResponseMessage responseUpdateStatus = await client.PutAsJsonAsync("api/order/updateOrder", order);
            if (!responseUpdateStatus.IsSuccessStatusCode)
            {
                TempData["fail"] = await responseUpdateStatus.Content.ReadAsStringAsync();
                return RedirectToAction("History");

            }

            foreach(var item in order.OrderItems)
            {
                //get album 
                Album album = new Album();
                HttpResponseMessage responseGetAlbum = await this.client.GetAsync($"api/album/{item.AlbumId}");
                if (responseGetAlbum.IsSuccessStatusCode)
                {
                    var result = responseGetAlbum.Content.ReadAsStringAsync().Result;
                    album = JsonConvert.DeserializeObject<Album>(result);
                    //update album's quantity
                    album.Stock = album.Stock + item.Quantity;
                    HttpResponseMessage responseUpdateAlbum = await client.PutAsJsonAsync("api/album/updateAlbum", album);
                }
            }
           
            TempData["success"] = "Order has been cancelled successfully.";
            return RedirectToAction("History");
        }

        [HttpGet]
        public async Task<IActionResult> History(string timeFrom, string timeTo, int order_status = 0, int pageNumber = 1)
        {

            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (timeFrom == null && timeTo == null)
            {
                timeFrom = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                timeTo = DateTime.Now.ToString("yyyy-MM-dd");
            }

            //get customer id
            int customerId = 0;

            Customer customer = new Customer();
            HttpResponseMessage responseGetCustomer = await this.client.GetAsync($"api/customer?userId={userId}");
            if (responseGetCustomer.IsSuccessStatusCode)
            {
                var result = responseGetCustomer.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result);
                customerId = customer.CustomerId;
            }
            if(customerId != 0)
            {
                //get orders
                List<Order> orders = new List<Order>();
                int pageSize = 15;
                HttpResponseMessage responseGetOrders = await this.client.GetAsync(
                    $"api/order/get_orders_history?pageSize={pageSize}&pageNumber={pageNumber}&timeFrom={timeFrom}&timeTo={timeTo}&orderStatus={order_status}&customer_id={customerId}");
                if (responseGetOrders.IsSuccessStatusCode)
                {
                    var result = responseGetOrders.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<List<Order>>(result);
                }

                //get orders count
                int order_count = 0;
                HttpResponseMessage responseOrdersCount = await this.client.GetAsync(
                    $"api/order/count_orders_history?timeFrom={timeFrom}&timeTo={timeTo}&orderStatus={order_status}&customer_id={customerId}");
                if (responseOrdersCount.IsSuccessStatusCode)
                {
                    var result = responseOrdersCount.Content.ReadAsStringAsync().Result;
                    order_count = Convert.ToInt32(result);
                }
                ViewBag.pageNumber = pageNumber;
                ViewBag.pageSize = pageSize;
                ViewBag.totalItems = order_count;
                ViewBag.Orders = orders;
            }
            var fail = TempData["fail"];
            var success = TempData["success"];
            if (fail != null)
            {
                ModelState.AddModelError("fail", fail.ToString());

            }

            if (success != null)
            {
                ModelState.AddModelError("success", success.ToString());

            }
            ViewBag.Url = "My Order";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int id, int status)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin && role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
            }

            Order order = new Order();
            HttpResponseMessage responseGetOrder = await this.client.GetAsync(
                $"api/order/{id}");
            if (responseGetOrder.IsSuccessStatusCode)
            {
                var result = responseGetOrder.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<Order>(result);
            }
            if (order == null)
            {
                TempData["fail"] = "Order not exist";
                return RedirectToAction("OrderDetails", new { id = id });
            }

            //if user want to ship the order (validation)
            if ((status == (int)OrderStatusEnum.Shipped || status == (int)OrderStatusEnum.Cancelled) && order.Status != (int)OrderStatusEnum.Paid)
            {
                TempData["fail"] = "Order's status does not allowed to be ship.";
                return RedirectToAction("OrderDetails", new { id = id });
            }
            order.Status = status;

            //update order status
            HttpResponseMessage responseUpdateStatus = await client.PutAsJsonAsync("api/order/updateOrder", order);
            if (!responseUpdateStatus.IsSuccessStatusCode)
            {
                TempData["fail"] = await responseUpdateStatus.Content.ReadAsStringAsync();
                return RedirectToAction("OrderDetails", new { id = id });

            }
            TempData["success"] = "Order has been updated successfully.";
            return RedirectToAction("OrderDetails", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetails(int id)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin && role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
            }

            Order order = new Order();
            HttpResponseMessage responseGetOrder = await this.client.GetAsync(
                $"api/order/{id}");
            if (responseGetOrder.IsSuccessStatusCode)
            {
                var result = responseGetOrder.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<Order>(result);
            }
            ViewBag.Order = order;

            var fail = TempData["fail"];
            var success = TempData["success"];
            if (fail != null)
            {
                ModelState.AddModelError("fail", fail.ToString());

            }

            if (success != null)
            {
                ModelState.AddModelError("success", success.ToString());

            }
            return View();
        }
    }
}
