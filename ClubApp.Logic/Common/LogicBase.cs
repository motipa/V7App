using AutoMapper;
using Microsoft.Extensions.Configuration;
using ClubApp.Data;

namespace ClubApp.Logic.Common
{
    public abstract class LogicBase
    {
        protected readonly DatabaseContext _db;

        protected readonly IMapper _mapper;

        protected readonly IConfiguration _config;

        protected LogicBase(DatabaseContext db, IMapper mapper,IConfiguration config)
        {
            _db = db;
            _mapper = mapper;
            _config = config;
            
        }
    }
}
