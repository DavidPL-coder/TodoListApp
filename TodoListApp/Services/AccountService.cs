using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListApp.DAL;
using TodoListApp.DAL.Entities;
using TodoListApp.Models;

namespace TodoListApp.Services
{
    public interface IAccountService
    {
        Task<bool> CheckIfUserWithNameExist(string name);
        Task CreateUserInDatabase(RegisterUserDTO registerUserDTO);
    }

    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasherService _passwordHasherService;

        public AccountService(AppDbContext context, IMapper mapper, IPasswordHasherService passwordHasherService)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<bool> CheckIfUserWithNameExist(string name)
        {
            return await _context.Users.AnyAsync(user => user.Name == name);
        }

        public async Task CreateUserInDatabase(RegisterUserDTO registerUserDTO)
        {
            var user = _mapper.Map<User>(registerUserDTO);
            user.PasswordHash = _passwordHasherService.HashPassword(registerUserDTO.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
