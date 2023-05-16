using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.HexaMemberControllerSpec
{
    public class When_getting_all_hexamember : UsingHexaMemberControllerSpec
    {
        private ActionResult<IEnumerable<HexaMemberDto>> _result;

        private IEnumerable<HexaMember> _all_hexamember;
        private HexaMember _hexamember;

        private IEnumerable<HexaMemberDto>  _all_hexamemberDto;
        private HexaMemberDto _hexamemberDto;
    

        public override void Context()
        {
            base.Context();

            _hexamember = new HexaMember{
                name = "name",
                age = 54,
                address = 76.11,
                phone = 60,
                project = 54,
                aa = new DateTime(),
                bb = false,
                cc = 2
            };

            _hexamemberDto = new HexaMemberDto{
                    name = "name",
                    age = 85,
                    address = 69.87,
                    phone = 12,
                    project = 44,
                    aa = new DateTime(),
                    bb = false,
                    cc = 94
                };

            _all_hexamember = new List<HexaMember> { _hexamember};
            _hexamemberService.GetAll().Returns(_all_hexamember);
            _all_hexamemberDto  = new List<HexaMemberDto> {_hexamemberDto};
            _mapper.Map<IEnumerable<HexaMemberDto>>(_all_hexamember).Returns( _all_hexamemberDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _hexamemberService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<HexaMemberDto>>();

            List<HexaMemberDto> resultList = resultListObject as List<HexaMemberDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_hexamemberDto);
        }
    }
}