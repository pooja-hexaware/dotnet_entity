using System.Collections.Generic;
using backend.BusinessServices.Interfaces;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace backend.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HexaMemberController : ControllerBase
    {
        readonly IHexaMemberService _HexaMemberService;
        private readonly IMapper _mapper;
        public HexaMemberController(IHexaMemberService HexaMemberService,IMapper mapper)
        {
            _HexaMemberService = HexaMemberService;
            _mapper = mapper;
        }

        // GET: api/HexaMember
        [HttpGet]
        public ActionResult<IEnumerable<HexaMemberDto>> Get()
        {
            var HexaMemberDTOs = _mapper.Map<IEnumerable<HexaMemberDto>>(_HexaMemberService.GetAll());
            return Ok(HexaMemberDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<HexaMemberDto> GetById(string id)
        {
            var HexaMemberDTO = _mapper.Map<HexaMemberDto>(_HexaMemberService.Get(id));
            return Ok(HexaMemberDTO);
        }

        [HttpPost]
        public ActionResult<HexaMemberDto> Save(HexaMember HexaMember)
        {
            var HexaMemberDTOs = _mapper.Map<HexaMemberDto>(_HexaMemberService.Save(HexaMember));
            return Ok(HexaMemberDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<HexaMemberDto> Update([FromRoute] string id, HexaMember HexaMember)
        {
            var HexaMemberDTOs = _mapper.Map<HexaMemberDto>(_HexaMemberService.Update(id, HexaMember));
            return Ok(HexaMemberDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _HexaMemberService.Delete(id);
            return Ok(res);
    }


    }
}
