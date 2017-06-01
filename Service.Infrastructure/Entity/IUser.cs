using System;

namespace Service.Entity
{
    public interface IUser:IEntity
    {

        DateTime LastLoginDate { get; set; }

        string Name { get; set; }

        string Email { get; set; }
        string PwdHash { get; set; }

        string Phone { get; set; }
    }
}
