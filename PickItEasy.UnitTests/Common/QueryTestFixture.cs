using AutoMapper;
using PickItEasy.Application.Common.Mappings;
using PickItEasy.Application.Interfaces;
using PickItEasy.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public PickItEasyDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = PickItEasyContextFactory.Create();
            var mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AssemblyMappingProfile(typeof(IPickItEasyDbContext).Assembly)));
            Mapper = mapperConfiguration.CreateMapper();
        }

        public void Dispose()
        {
            PickItEasyContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
