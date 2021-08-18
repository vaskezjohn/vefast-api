using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.User_group;
using vefast_src.Domain.Repositories.User_group;
using vefast_src.DTO.User_group;

namespace vefast_src.Domain.Services.User_group
{
    public class User_groupService : IUser_groupService
    {
        private readonly IMapper _mapper;
        private readonly IUser_groupRepository _user_groupRepository;

        public User_groupService(IMapper mapper, IUser_groupRepository user_groupRepository)
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
        public IEnumerable<User_groupResponse> GetAllUser_group()
        {
            return _mapper.Map<IEnumerable<User_groupResponse>>(_user_groupRepository.GetAll());
        }

        public async Task<User_groupResponse> CreateUser_groupAsync(User_groupRequest objRequest)
        {
            var user_group = _mapper.Map<Entities.User_group.User_group>(objRequest);
            _user_groupRepository.Add(user_group);

            try
            {
                await _user_groupRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<User_groupResponse>(user_group);
        }

        public async Task<User_groupResponse> GetUser_groupByIdAsync(Guid id)
        {
            var user_group = await _user_groupRepository.GetByIDAsync(id);
            if (user_group == null)
            {
                throw new User_groupNotFoundException("Grupo de usuario no encontrado.");
            }

            return _mapper.Map<User_groupResponse>(user_group);
        }

        public async Task DeleteUser_groupById(Guid id)
        {
            var user_group = _user_groupRepository.GetByID(id);

            if (user_group == null)
            {
                throw new User_groupNotFoundException("Grupo de usuario no encontrado.");
            }

            _user_groupRepository.Delete(user_group);
            await _user_groupRepository.SaveAsync();
        }

        public async Task<User_groupResponse> EditUser_groupByIdAsync(Guid id, User_groupRequest objRequest)
        {
            var user_group = await _user_groupRepository.GetByIDAsync(id);

            if (user_group == null)
            {
                throw new User_groupNotFoundException("Grupo de usuario no encontrado.");
            }

            user_group.user_id = objRequest.user_id;
            user_group.group_id = objRequest.group_id;
    

            _user_groupRepository.Update(user_group);
            await _user_groupRepository.SaveAsync();

            return _mapper.Map<User_groupResponse>(user_group);
        }
    }
}
