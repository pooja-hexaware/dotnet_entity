using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;
using backend.BusinessServices.Services;

namespace backend.Test.Api.HexaMemberControllerSpec
{
    public class When_updating_hexamember : UsingHexaMemberControllerSpec
    {
        private ActionResult<HexaMemberDto > _result;
        private HexaMember _hexamember;
        private HexaMemberDto _hexamemberDto;

        public override void Context()
        {
            base.Context();

            _hexamember = new HexaMember
            {
                name = "name",
                age = 56,
                address = 48.54,
                phone = 99,
                project = 46,
                aa = new DateTime(),
                bb = false,
                cc = 34
            };

            _hexamemberDto = new HexaMemberDto{
                    name = "name",
                    age = 81,
                    address = 51.63,
                    phone = 30,
                    project = 7,
                    aa = new DateTime(),
                    bb = false,
                    cc = 76
            };

            _hexamemberService.Update(_hexamember.Id, _hexamember).Returns(_hexamember);
            _mapper.Map<HexaMemberDto>(_hexamember).Returns(_hexamemberDto);
            
        }
        public override void Because()
        {
            _result = subject.Update(_hexamember.Id, _hexamember);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _hexamemberService.Received(1).Update(_hexamember.Id, _hexamember);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<HexaMemberDto>();

            var resultList = resultListObject as HexaMemberDto;

            resultList.ShouldBe(_hexamemberDto);
        }
    }
}