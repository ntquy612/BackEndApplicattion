using BackEndApplicattion.Data;
using BackEndApplicattion.DTOs;
using BackEndApplicattion.Exceptions;
using BackEndApplicattion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApplicattion.Services
{
    public class UserService
    {
        private readonly DBContext _dbContext;

        public UserService(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<bool>> Register(RegisterUserDTO dto)
        {
            var existUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName);
            var IsAdmin = false;

            if (existUser != null)
            {
                return false;
            }

            if(dto.UserName.Contains("admin"))
            {
                IsAdmin = true;
            }

            var user = new User(dto.UserName, dto.Email, dto.UserName, dto.Password, dto.Address, IsAdmin, false, false);
            await _dbContext.Users.AddAsync(user);  
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ActionResult<InfoUser>> Login(LoginDTO dto)
        {
            var existUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName);
            if(existUser is null)
            {
                throw new UserNotFoundException(dto.UserName);
            }

            if(existUser.IsDelete)
            {
                throw new Exception("This User has been blocked");
            }

            if(existUser.Password != dto.Password)
            {
                throw new Exception("Password is wrong");
            }

            return new InfoUser(
                        existUser.Id,
                        existUser.Name,
                        existUser.Email,
                        existUser.UserName,
                        existUser.Address,
                        existUser.IsAdmin,
                        true
                    );
        }

        public async Task<ActionResult<bool>> ChangePassword(ChangePasswordDTO dto)
        {
            if(!dto.IsAuthentication)
            {
                throw new Exception("You must Login before Change Password");
            }
            var existUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName);

            if (existUser is null)
            {
                throw new UserNotFoundException(dto.UserName);
            }

            if(existUser.Password != dto.Password)
            {
                throw new Exception("Your password is wrong!");
            }

            existUser.Password = dto.NewPassword;
            _dbContext.Users.Update(existUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers(int page, int pageSize)
        {
            var users = await _dbContext.Users
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return users;
        }

        public async Task<ActionResult<InfoUser>> EditUser(InfoUser info)
        {
            var existUser = await _dbContext.Users.FindAsync(info.Id);

            existUser.Name = info.Name;
            existUser.Email = info.Email;
            existUser.Address = info.Address;

            _dbContext.Users.Update(existUser);
            await _dbContext.SaveChangesAsync();    

            return info;
        }

        public async Task<ActionResult<bool>> DeleteUser(Guid id)
        {
            var existUser = await _dbContext.Users.FindAsync(id);

            existUser.IsDelete = true;

            _dbContext.Users.Update(existUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
