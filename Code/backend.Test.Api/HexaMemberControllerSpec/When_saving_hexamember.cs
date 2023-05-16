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
    public class When_saving_hexamember : UsingHexaMemberControllerSpec
    {
        private ActionResult<HexaMemberDto> _result;

        private HexaMember _hexamember;
        private HexaMemberDto _hexamemberDto;

        public override void Context()
        {
            base.Context();

            _hexamember = new HexaMember
            {
                name = "name",
                age = 55,
                address = 73.08,
                phone = 22,
                project = 45,
                aa = new DateTime(),
                bb = false,
                cc = 67
            };

            _hexamemberDto = new HexaMemberDto{
                    name = "name",
                    age = 28,
                    address = 1.89,
                    phone = 57,
                    project = 7,
                    aa = new DateTime(),
                    bb = true,
                    cc = 98
            };

            _hexamemberService.Save(_hexamember).Returns(_hexamember);
            _mapper.Map<HexaMemberDto>(_hexamember).Returns(_hexamemberDto);
        }
        public override void Because()
        {
            _result = subject.Save(_hexamember);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _hexamemberService.Received(1).Save(_hexamember);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<HexaMemberDto>();

            var resultList = (HexaMemberDto)resultListObject;

            resultList.ShouldBe(_hexamemberDto);
        }
    }
}

