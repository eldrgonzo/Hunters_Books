using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Hunters_Books.Models;
using DevExtreme.AspNet.Data;
using Hunters_Books.Data;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Drawing.Printing;

namespace Hunters_Books.Controllers
{
    [Route("api/DataGridWebApi/{action}", Name = "DataGridWebApi")]
    public class DataGridWebApiController : ApiController
    {
        InMemoryNorthwindContext _nwind = new InMemoryNorthwindContext();

        public class DataChange
        {
            public string Type { get; set; }
            public string Key { get; set; }
            public object Data { get; set; }
        }


        [HttpGet]
        public HttpResponseMessage Orders(DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(_nwind.Books, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage InsertOrder(FormDataCollection form)
        {
            var values = form.Get("values");

            var newOrder = new Order();
            JsonConvert.PopulateObject(values, newOrder);

            Validate(newOrder);
            if (!ModelState.IsValid)
                return null;//Request.CreateErrorResponse(HttpStatusCode.BadRequest, null;

            _nwind.Orders.Add(newOrder);
            _nwind.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, newOrder);
        }

        [HttpPut]
        public HttpResponseMessage UpdateOrder(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var values = form.Get("values");
            var order = _nwind.Books.First(o => o.Id == key);

            JsonConvert.PopulateObject(values, order);

            Validate(order);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState.GetFullErrorMessage());

            _nwind.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, order);
        }

        [HttpDelete]
        public void DeleteOrder(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var order = _nwind.Books.First(o => o.Id == key);

            _nwind.Books.Remove(order);
            _nwind.SaveChanges();
        }

        // additional actions
        /*
        [HttpGet]
        public HttpResponseMessage OrderDetails(int orderID, DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(
                from i in _nwind.Books
                where i.Id == orderID
                select new
                {
                    Product = i.Title,
                    author = i.Author,
                    i.GenreID,
                    i.Genre 
                },
                loadOptions
            ));
        }
        
        [HttpGet]
        public HttpResponseMessage ShippersLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _nwind.Shippers
                         orderby i.CompanyName
                         select new
                         {
                             Value = i.ShipperID,
                             Text = i.CompanyName
                         };

            return Request.CreateResponse(DataSourceLoader.Load(lookup, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage CustomersLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _nwind.Customers
                         let text = i.CompanyName + " (" + i.Country + ")"
                         orderby i.CompanyName
                         select new
                         {
                             Value = i.CustomerID,
                             Text = text
                         };

            return Request.CreateResponse(DataSourceLoader.Load(lookup, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage Batch(List<DataChange> changes)
        {
            foreach (var change in changes)
            {
                Order order;

                if (change.Type == "update" || change.Type == "remove")
                {
                    var key = Convert.ToInt32(change.Key);
                    order = _nwind.Orders.First(o => o.OrderID == key);
                }
                else
                {
                    order = new Order();
                }

                if (change.Type == "insert" || change.Type == "update")
                {
                    JsonConvert.PopulateObject(change.Data.ToString(), order);

                    Validate(order);
                    if (!ModelState.IsValid)
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState.GetFullErrorMessage());

                    if (change.Type == "insert")
                    {
                        _nwind.Orders.Add(order);
                    }
                    change.Data = order;
                }
                else if (change.Type == "remove")
                {
                    _nwind.Orders.Remove(order);
                }
            }

            _nwind.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, changes);
        }*/
    }

}
