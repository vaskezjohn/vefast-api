using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.UsersGroups;
using vefast_src.Domain.Exceptions.UserGroup;
using vefast_src.Domain.Repositories.UserGroup;
using vefast_src.DTO.UserGroup;

namespace vefast_src.Domain.Services.UserGroup
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IMapper _mapper;
        private readonly IUserGroupRepository _user_groupRepository;

        public UserGroupService(IMapper mapper, IUserGroupRepository user_groupRepository)
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
        public IEnumerable<UserGroupResponse> GetAllUserGroup()
        {
            return _mapper.Map<IEnumerable<UserGroupResponse>>(_user_groupRepository.GetAll());
        }

        public async Task<UserGroupResponse> CreateUserGroupAsync(UserGroupRequest objRequest)
        {
            var user_group = _mapper.Map<UsersGroups>(objRequest);
            _user_groupRepository.Add(user_group);

            try
            {
                await _user_groupRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<UserGroupResponse>(user_group);
        }

        public async Task<UserGroupResponse> GetUserGroupByIdAsync(Guid id)
        {
            var user_group = await _user_groupRepository.GetByIDAsync(id);
            if (user_group == null)
            {
                throw new UserGroupNotFoundException("Grupo de usuario no encontrado.");
            }

            return _mapper.Map<UserGroupResponse>(user_group);
        }

        public async Task DeleteUserGroupById(Guid id)
        {
            var user_group = _user_groupRepository.GetByID(id);

            if (user_group == null)
            {
                throw new UserGroupNotFoundException("Grupo de usuario no encontrado.");
            }

            _user_groupRepository.Delete(user_group);
            await _user_groupRepository.SaveAsync();
        }

        public async Task<UserGroupResponse> EditUserGroupByIdAsync(Guid id, UserGroupRequest objRequest)
        {
            var user_group = await _user_groupRepository.GetByIDAsync(id);

            if (user_group == null)
            {
                throw new UserGroupNotFoundException("Grupo de usuario no encontrado.");
            }

            user_group.user_id = objRequest.user_id;
            user_group.group_id = objRequest.group_id;
    

            _user_groupRepository.Update(user_group);
            await _user_groupRepository.SaveAsync();

            return _mapper.Map<UserGroupResponse>(user_group);
        }
    }
}
