using QualitApps_Test.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitApps_Test.Services.Users
{
    public interface IUserRepository
    {
        public List<BaseUser> GetAllUsers();
        public BaseUser GetUserByUserId(Guid UserId);
        public BaseUser CreateUser(BaseUser user);
        public Task<BaseUser> UpdateUser(BaseUser user);
        public int RemoveUser(Guid UserId);
    }
}
