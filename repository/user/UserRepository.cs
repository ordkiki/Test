using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Test.model.dto;
using Test.model.entities;
namespace Test.repository;

public class UserRepository : IUserRepository {

    private readonly AppDbContext _db;

    public UserRepository (AppDbContext db) {
        _db = db;
    }

    public async Task<User?> GetUser (Guid UserId) {
        return await _db.Users.FirstOrDefaultAsync(user => user.Id == UserId);
    }
    public async Task<List<User>?> GetAllUsers (){
        return await _db.Users.ToListAsync();
    }

    public async Task<User> CreateUser (UserDto userDto){
        User newUser = new User {
            Id = Guid.NewGuid(),
            Name = userDto.Name,
        };
        await _db.Users.AddAsync(newUser);
        await _db.SaveChangesAsync();
        return newUser;
        
    }
    public async Task<bool> UpdateUser(Guid UserId , User UpdateUser) {
        try {
                var res = _db.Users.Update(UpdateUser);
                await _db.SaveChangesAsync();
                return true;
        } catch(Exception e){
            return false;
        }
    }
    public async Task<bool> DeleteUser (Guid UserId ){
        User? userToDel = await GetUser(UserId);
        _db.Users.Remove(userToDel);
        await _db.SaveChangesAsync();
        return true;
    }
}