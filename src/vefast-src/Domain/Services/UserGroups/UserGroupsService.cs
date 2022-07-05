using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.UserGroups;
using vefast_src.Domain.Exceptions.UserGroups;
using vefast_src.Domain.Repositories.UserGroups;
using vefast_src.DTO.UserGroups;

namespace vefast_src.Domain.Services.UserGroups
{
    public class UserGroupsService : IUserGroupsService
    {
        private readonly IMapper _mapper;
        private readonly IUserGroupsRepository _user_groupRepository;

        public UserGroupsService(IMapper mapper, IUserGroupsRepository user_groupRepository)
        {
            this._mapper = mapper;
            this._user_groupRepository = user_groupRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._user_groupRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
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
        public IEnumerable<UserGroupsResponse> GetAllUserGroup()
        {
            return _mapper.Map<IEnumerable<UserGroupsResponse>>(_user_groupRepository.GetAll());
        }

        public async Task<UserGroupsResponse> CreateUserGroupAsync(UserGroupsRequest objRequest)
        {
            var user_group = _mapper.Map<Entities.UserGroups.UserGroups>(objRequest);
            _user_groupRepository.Add(user_group);

            try
            {
                await _user_groupRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<UserGroupsResponse>(user_group);
        }

        public async Task<UserGroupsResponse> GetUserGroupByIdAsync(Guid id)
        {
            var user_group = await _user_groupRepository.GetByIDAsync(id);
            if (user_group == null)
            {
                throw new UserGroupsNotFoundException("Grupo de usuario no encontrado.");
            }

            return _mapper.Map<UserGroupsResponse>(user_group);
        }

        public async Task DeleteUserGroupById(Guid id)
        {
            var user_group = _user_groupRepository.GetByID(id);

            if (user_group == null)
            {
                throw new UserGroupsNotFoundException("Grupo de usuario no encontrado.");
            }

            _user_groupRepository.Delete(user_group);
            await _user_groupRepository.SaveAsync();
        }

        public async Task<UserGroupsResponse> EditUserGroupByIdAsync(Guid id, UserGroupsRequest objRequest)
        {
            var user_group = await _user_groupRepository.GetByIDAsync(id);

            if (user_group == null)
            {
                throw new UserGroupsNotFoundException("Grupo de usuario no encontrado.");
            }

            user_group.ID_User = objRequest.user_id;
            user_group.ID_UserGroup = objRequest.group_id;
    

            _user_groupRepository.Update(user_group);
            await _user_groupRepository.SaveAsync();

            return _mapper.Map<UserGroupsResponse>(user_group);
        }
    }
}
