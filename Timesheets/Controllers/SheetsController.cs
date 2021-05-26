using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;
using Timesheets.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Timesheets.Controllers
{
    [Authorize]
    public class SheetsController :TimesheetBaseController
    {
        private readonly ISheetManager _sheetManager;
        private readonly IContractManager _contractManager;
        private readonly IMapper _mapper;

        public SheetsController(IMapper mapper, ISheetManager sheetManager, IContractManager contractManager)
        {
            _sheetManager = sheetManager;
            _contractManager = contractManager;
            _mapper = mapper;
        }
        [Authorize(Roles = "user, admin")]
        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] Guid id)
        {
            var result = _sheetManager.GetItem(id);

            return Ok(result);
        }
        [Authorize(Roles = "user, admin")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _sheetManager.GetItems();
            return Ok(result);
        }

        /// <summary> Возвращает запись табеля </summary>
        [Authorize(Roles = "user, admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SheetDto sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);

            if (isAllowedToCreate != null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {sheet.ContractId} is not active or not found.");
            }

            var id = await _sheetManager.Create(_mapper.Map<Sheet>(sheet));
            return Ok(id);
        }

        /// <summary> Обновляет запись табеля </summary>
        [Authorize(Roles = "user, admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SheetDto sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);

            if (isAllowedToCreate != null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {sheet.ContractId} is not active or not found.");
            }

            await _sheetManager.Update(id, _mapper.Map<Sheet>(sheet));

            return Ok();
        }
    }
}
