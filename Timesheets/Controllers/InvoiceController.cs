using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Dto;
using Timesheets.Models;
using Timesheets.Domain.Interfaces;
using AutoMapper;

namespace Timesheets.Controllers
{
    public class InvoiceController:TimesheetBaseController
    {
        private readonly IContractManager _contractManager;
        private readonly IInvoiceManager _invoiceManager;
        private readonly IMapper _mapper;
        public InvoiceController(IMapper mapper, IInvoiceManager invoiceManager, IContractManager contractManager)
        {
            _invoiceManager = invoiceManager;
            _contractManager = contractManager;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceDto invoice)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(invoice.ContractId);

            if (isAllowedToCreate != null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {invoice.ContractId} is not active or not found.");
            }

            var id = await _invoiceManager.Greate(_mapper.Map<Invoice>(invoice));
            return Ok(id);
        }
    }
}
