using System.Collections.Generic;
using hw4.Models;

namespace hw4.SecondOrmLibrary
{
    public interface ISecondOrm
    {
        ISecondOrmContext Context { get; }
    }

    public interface ISecondOrmContext
    {
        HashSet<DbUserEntity> Users { get; }
        HashSet<DbUserInfoEntity> UserInfos { get; }
    }
}