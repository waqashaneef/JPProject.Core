using AutoMapper;
using JPProject.Admin.Application.AutoMapper;
using JPProject.Admin.Application.Interfaces;
using JPProject.Admin.Application.ViewModels;
using JPProject.Admin.Domain.Commands.PersistedGrant;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Domain.Core.Bus;
using JPProject.Domain.Core.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JPProject.Admin.Application.Services
{
    public class PersistedGrantAppService : IPersistedGrantAppService
    {
        private IMapper _mapper;
        private readonly IPersistedGrantRepository _persistedGrantRepository;
        public IMediatorHandler Bus { get; set; }

        public PersistedGrantAppService(
            IMediatorHandler bus,
            IPersistedGrantRepository persistedGrantRepository)
        {
            _mapper = AdminPersistedGrantMapper.Mapper;
            Bus = bus;
            _persistedGrantRepository = persistedGrantRepository;
        }

        public async Task<ListOf<PersistedGrantViewModel>> GetPersistedGrants(IPersistedGrantCustomSearch search)
        {
            var resultado = await _persistedGrantRepository.Search(search);
            var total = await _persistedGrantRepository.Count(search);

            var grants = resultado.Select(s => new PersistedGrantViewModel(s.Key, s.Type, s.SubjectId, s.ClientId, s.CreationTime, s.Expiration, s.Data));
            return new ListOf<PersistedGrantViewModel>(grants, total);
        }

        public Task Remove(RemovePersistedGrantViewModel model)
        {
            // kiss
            var command = _mapper.Map<RemovePersistedGrantCommand>(model);
            return Bus.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}