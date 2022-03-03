

using System.Data;
using Dapper;
using Sanirasu.Models;

namespace Sanirasu.Repositories;
public interface IUserRepository
{
    Task<User> Create(User item);
    Task Update(long uniqueIdentity,User item);
    Task Delete(long uniqueIdentity);
    Task<User> GetUserById(long uniqueIdentity);
    Task<List<User>> GetUserList();
}
public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IConfiguration configuration) : base(configuration)
    {

    }

    public async Task<User> Create(User item)
    {
        using IDbConnection connection = NewConnection;
        string query = $"INSERT INTO public.user_data VALUES ({item.UniqueIdentity},'{item.FullName}','{item.Gender}','{item.DateOfBirth}',{item.ContactNumber});";
        await connection.ExecuteAsync(query, commandType:CommandType.Text);
        return null;
    }

    public async Task Delete(long uniqueIdentity)
    {
        using IDbConnection connection = NewConnection;
        string selectById = $"DELETE FROM public.user_data WHERE uniqueidentity = {uniqueIdentity}; ";
        var newuser = await connection. QueryAsync<User>(selectById, commandType:CommandType.Text);
        
    }

    public async Task<User> GetUserById(long uniqueIdentity)
    {
        User result = new User();
           using IDbConnection connection = NewConnection;
           string selectById = $"SELECT * FROM public.user_data WHERE uniqueidentity = {uniqueIdentity}; ";
           var newuser = await connection. QueryAsync<User>(selectById, commandType:CommandType.Text);
            foreach(User user in newuser){
               result = user;
            }
          return result;
    }

    public async Task<List<User>> GetUserList()
    {
           List<User> listOfUsers = new List<User>();
           using IDbConnection connection = NewConnection;
           string selectById = $"SELECT * FROM public.user_data; ";
           var newuser = await connection. QueryAsync<User>(selectById, commandType:CommandType.Text);
            foreach(User user in newuser){
               listOfUsers.Add(user);
            }
          return listOfUsers;
            
    }

    public async Task Update(long uniqueIdentity,User item)
    {
        using IDbConnection connection = NewConnection;
        connection.Open();
            string query = $"UPDATE public.user_data SET uniqueidentity={item.UniqueIdentity},fullname='{item.FullName}', gender='{item.Gender}', dateofbirth='{item.DateOfBirth}', contactnumber={item.ContactNumber} WHERE uniqueidentity={uniqueIdentity};";
            await connection.ExecuteAsync(query, commandType:CommandType.Text);
        
    }
}

