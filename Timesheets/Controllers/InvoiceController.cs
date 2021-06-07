using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Dto;
using Timesheets.Models;
using Timesheets.Domain.Managers.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Timesheets.Controllers
{
   // [Authorize]
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
        /// <summary> Возвращяет запись счета по id </summary>
       // [Authorize(Roles = "user, admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _invoiceManager.GetItem(id);
            return Ok(result);
        }

      
        /// <summary> Возвращяет все записи счетов </summary>
      //  [Authorize(Roles = "user, admin")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _invoiceManager.GetItems();
            return Ok(result);
        }
        /// <summary> Создает записи счета </summary>
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
        /// <summary> Обновляет запись счета </summary>
       // [Authorize(Roles = "user, admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] InvoiceDto invoice)
        {      
            await _invoiceManager.Update(id, _mapper.Map<Invoice>(invoice));
            return Ok();
        }
        /// <summary> Удаляет запись счета </summary>
       // [Authorize(Roles = "user, admin")]
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _invoiceManager.Delete(id);
            return Ok();
        }
    }
}
