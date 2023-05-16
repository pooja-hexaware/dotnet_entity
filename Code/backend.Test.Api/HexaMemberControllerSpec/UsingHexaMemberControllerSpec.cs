using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.HexaMemberControllerSpec
{
    public abstract class UsingHexaMemberControllerSpec : SpecFor<HexaMemberController>
    {
        protected IHexaMemberService _hexamemberService;
        protected IMapper _mapper;

        public override void Context()
        {
            _hexamemberService = Substitute.For<IHexaMemberService>();
            _mapper = Substitute.For<IMapper>();
            subject = new HexaMemberController(_hexamemberService,_mapper);

        }

    }
}
