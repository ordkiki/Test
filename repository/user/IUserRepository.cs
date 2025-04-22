
using Microsoft.AspNetCore.SignalR;
using Test.model.dto;
using Test.model.entities;

namespace Test.repository;

public interface IUserRepository {

    public Task<User> CreateUser (UserDto userDto);
    public Task<User> GetUser (Guid UserId) ;
    public Task<List<User>> GetAllUsers ();
    public Task<bool> UpdateUser(Guid UserId , User UpdateUser) ;
    public Task<bool> DeleteUser (Guid UserId );

}