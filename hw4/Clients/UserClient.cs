using System.Linq;
using hw4.FirstOrmLibrary;
using hw4.Models;
using hw4.SecondOrmLibrary;


namespace hw4.Clients
{
    public class UserClient
    {
        public UserClient(IFirstOrm<DbUserEntity> firstOrmWithUsers,
            IFirstOrm<DbUserInfoEntity> firstOrmWithUsersInfo,
            ISecondOrm secondOrm)
        {
            _firstOrmAdapter = new FirstOrmAdapter(firstOrmWithUsers, firstOrmWithUsersInfo);
            _secondOrmAdapter = new SecondOrmAdapter(secondOrm);
        }

        private readonly FirstOrmAdapter _firstOrmAdapter;
        private readonly SecondOrmAdapter _secondOrmAdapter;
        private readonly bool _useFirstOrm = true;

        private IOrmAdapter _GetOrmAdapter()
        {
            if (_useFirstOrm)
            {
                return _firstOrmAdapter;
            }

            return _secondOrmAdapter;
        }

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            return _GetOrmAdapter().Get(userId);
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _GetOrmAdapter().Add(user, userInfo);
        }

        public void Remove(int userId)
        {
            _GetOrmAdapter().Remove(userId);
        }
    }
}