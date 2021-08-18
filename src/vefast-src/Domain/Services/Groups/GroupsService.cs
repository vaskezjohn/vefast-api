using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Groups;
using vefast_src.Domain.Repositories.Groups;
using vefast_src.DTO.Groups;

namespace vefast_src.Domain.Services.Groups
{
    public class GroupsService : IGroupsService
    {
        private readonly IMapper _mapper;
        private readonly IGroupsRepository _groupsRepository;

        public GroupsService(IMapper mapper, IGroupsRepository groupsRepository)
        {
            this._mapper = mapper;
            this._groupsRepository = groupsRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._groupsRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
        //    if (!String.IsNullOrEmpty(lastCode))
        //    {
        //        int number = Convert.ToInt32(lastCode[4..]);

        //        return "CLI-" + (number + 1);
        //    }
        //    else
        //    {
        //        return "CLI-1";
        //    }
        //}
        public IEnumerable<GroupsResponse> GetAllGroups()
        {
            return _mapper.Map<IEnumerable<GroupsResponse>>(_groupsRepository.GetAll());
        }

        public async Task<GroupsResponse> CreateGroupsAsync(GroupsRequest objRequest)
        {
            var groups = _mapper.Map<Entities.Groups.Groups>(objRequest);
            _groupsRepository.Add(groups);

            try
            {
                await _groupsRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<GroupsResponse>(groups);
        }

        public async Task<GroupsResponse> GetGroupsByIdAsync(Guid id)
        {
            var groups = await _groupsRepository.GetByIDAsync(id);
            if (groups == null)
            {
                throw new GroupsNotFoundException("Grupo no encontrado.");
            }

            return _mapper.Map<GroupsResponse>(groups);
        }

        public async Task DeleteGroupsById(Guid id)
        {
            var groups = _groupsRepository.GetByID(id);

            if (groups == null)
            {
                throw new GroupsNotFoundException("Grupo no encontrado.");
            }

            _groupsRepository.Delete(groups);
            await _groupsRepository.SaveAsync();
        }

        public async Task<GroupsResponse> EditGroupsByIdAsync(Guid id, GroupsRequest objRequest)
        {
            var groups = await _groupsRepository.GetByIDAsync(id);

            if (groups == null)
            {
                throw new GroupsNotFoundException("Grupo no encontrado.");
            }

            groups.group_name = objRequest.group_name;
            groups.permission = objRequest.permission;
 

            _groupsRepository.Update(groups);
            await _groupsRepository.SaveAsync();

            return _mapper.Map<GroupsResponse>(groups);
        }
    }
}
