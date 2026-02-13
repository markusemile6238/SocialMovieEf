using Microsoft.EntityFrameworkCore;
using SocialMovieEf.Common;
using SocialMovieEf.Models;

namespace SocialMovieEf.Services;

public class UserServices
{
     private readonly SmContext _context;

     public UserServices(SmContext context)
     {
          _context = context;
     }


     #region GetAllUser

     public async Task<List<User>> GetAllUser()
     {
          return await _context.Users.ToListAsync();
     }
     #endregion

     #region GetUserByEmailAsync

     public async Task<User> GetUserByEmailAsync(string email)
     {
          var result =await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
          if (result == null) throw  new NullReferenceException("User not found");
          return result;
     }

     #endregion
}