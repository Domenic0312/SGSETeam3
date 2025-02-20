﻿using Microsoft.AspNetCore.Mvc;
using SGSE.Models;
using SGSE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGSE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        // GET: api/<PaymentController>
        [HttpGet]
        [Route("/test")]
        public string Test()
        {
            return "test";
        }

        [HttpGet()]
        public async Task<ActionResult<List<Invoice>>> getAllInvoicesForUser()
        {
            var invoices = await _service.GetAll();
            return invoices;
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceForUser(string id)
        {
            var invoice = await _service.GetById(id);
            return invoice;
        }

        // POST api/<PaymentController>
        [HttpPost]
        public async void CreateInvoiceAndPay([FromBody] InvoiceAndAmount invoiceAndAmount, bool payed)
        {
            var createdInvoice = await _service.CreateInvoice(invoiceAndAmount.Invoice);
            await _service.MakePayment(createdInvoice.Id, invoiceAndAmount.Amount, createdInvoice.Recipient.EmailAddress, payed);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Invoice invoice)
        {
            await _service.Update(id, invoice);
            return Ok();
        }
    }
}
