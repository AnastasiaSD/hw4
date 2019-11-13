using System.Linq;
using hw4.Models;
using hw4.SecondOrmLibrary;

namespace hw4.Clients
{
    public class SecondOrmAdapter : IOrmAdapter
    {
        private readonly ISecondOrm _secondOrm;

        public SecondOrmAdapter(ISecondOrm secondOrm)
        {
            this._secondOrm = secondOrm;
        }

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            var user = _secondOrm.Context.Users.First(i => i.Id == userId);
            var userInfo = _secondOrm.Context.UserInfos.First(i => i.Id == user.InfoId);
            return (user, userInfo);
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _secondOrm.Context.Users.Add(user);
            _secondOrm.Context.UserInfos.Add(userInfo);
        }

        public void Remove(int userId)
        {
            _secondOrm.Context.Users.RemoveWhere(user => user.Id == userId);
            _secondOrm.Context.UserInfos.RemoveWhere(userInfo => userInfo.Id == userId);
        }
    }
}