using Entities.Models;
using Entities.Models.Context;
using Entities.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Base;
using Services.Exceptions;

namespace Services;

public class UserService : DailyQuestionService
{
    public UserService(DailyQuestionContext context) : base(context)
    {
    }
    
    public async Task<UserModel?> GetUserByEmail(string email)
    {
        UserModel? user = await _context.UserModel.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }
    
    public async Task<UserModel> AddNewUser(SignUpDTO user)
    {
        UserModel? foundUser = await GetUserByEmail(user.Email);
        if (foundUser != null)
        {
            throw new EmailAlreadyInUseException("This email address already in taken!");
        }

        var userToAdd = new UserModel
        {
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password
        };

        IPasswordHasher<UserModel> hasher = new PasswordHasher<UserModel>();
        var hashedPassword = hasher.HashPassword(userToAdd, userToAdd.Password);
        userToAdd.Password = hashedPassword;

        _context.UserModel.Add(userToAdd);
        await _context.SaveChangesAsync();
        return userToAdd;
    }
}