using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Users;
using vefast_src.Domain.Repositories.Users;
using vefast_src.DTO.Users;

namespace vefast_src.Domain.Services.User
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _user_groupRepository;

        public UsersService(IMapper mapper, IUsersRepository user_groupRepository)
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
        public IEnumerable<UsersResponse> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<UsersResponse>>(_user_groupRepository.GetAll());
        }

        public async Task<UsersResponse> CreateUsersAsync(UsersRequest objRequest)
        {
            var user_group = _mapper.Map<Entities.Users.Users>(objRequest);
            _user_groupRepository.Add(user_group);

            try
            {
                await _user_groupRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<UsersResponse>(user_group);
        }

        public async Task<UsersResponse> GetUsersByIdAsync(Guid id)
        {
            var user_group = await _user_groupRepository.GetByIDAsync(id);
            if (user_group == null)
            {
                throw new UsersNotFoundException("Grupo de usuario no encontrado.");
            }

            return _mapper.Map<UsersResponse>(user_group);
        }

        public async Task DeleteUsersById(Guid id)
        {
            var user_group = _user_groupRepository.GetByID(id);

            if (user_group == null)
            {
                throw new UsersNotFoundException("Grupo de usuario no encontrado.");
            }

            _user_groupRepository.Delete(user_group);
            await _user_groupRepository.SaveAsync();
        }

        public async Task<UsersResponse> EditUsersByIdAsync(Guid id, UsersRequest objRequest)
        {
            var user_group = await _user_groupRepository.GetByIDAsync(id);

            if (user_group == null)
            {
                throw new UsersNotFoundException("Grupo de usuario no encontrado.");
            }

            user_group.ID = objRequest.ID;
            user_group.user= objRequest.user;
            user_group.password = objRequest.password;
            user_group.email = objRequest.email;
            user_group.firstname = objRequest.firstname;
            user_group.lastname = objRequest.lastname;
            user_group.phone = objRequest.phone;
            user_group.gender = objRequest.gender;
            user_group.token= objRequest.token;
            user_group.tokenExpires = objRequest.tokenExpires;
            user_group.refreshToken = objRequest.refreshToken;
            user_group.changePassword = objRequest.changePassword;
            objRequest.downLogic = objRequest.downLogic;


            _user_groupRepository.Update(user_group);
            await _user_groupRepository.SaveAsync();

            return _mapper.Map<UsersResponse>(user_group);
        }
    }
}
