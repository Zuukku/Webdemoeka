﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDemoMilja.Models;

namespace WebDemoMilja.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersApiController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<Customers> GetAll()
        {
            NorthwindContext context = new NorthwindContext();
            List<Customers> all = context.Customers.ToList();

            return all;
        }

        [HttpGet]
        [Route("{customerid}")]
        public Customers GetSingle(string customerid)
        {
            NorthwindContext context = new NorthwindContext();

            if (customerid != null)
            {
                Customers customer = context.Customers.Find(customerid);

                return customer;
            }
            return null;
        }

        // lisäys

        [HttpPut]
        [Route("{customerid}")]

        public Customers PutEdit(string customerid)
        {

            NorthwindContext context = new NorthwindContext();

            if (customerid != null)
            {
                Customers customer = context.Customers.Find(customerid);
                return customer;
            }
            return null;
        }


        // muokkaus
        [HttpPut]
        [Route("{customerid}")]
        public Customers PutEdit([FromRoute] string customerid,
           [FromBody] Customers newData)
        {
            NorthwindContext context = new NorthwindContext();

            if (customerid != null)
            {
                Customers customer = context.Customers.Find(customerid);

                if (customer != null)
                {
                    customer.CompanyName = newData.CompanyName;
                    customer.ContactName = newData.ContactName;
                    customer.City = newData.City;
                    customer.Country = newData.Country;
                    // ...

                    context.SaveChanges();
                }

                return customer;
            }
            return null;
        }



        //

        [HttpGet]
        [Route("pvm")]
        public string Päivämäärä()
        {
            string pvm = DateTime.Now.ToString();
            return pvm;
        }
    }
}
