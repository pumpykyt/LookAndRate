using LookAndRate.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LookAndRate.Domain.Interfaces
{
    public interface IJWTTokenService
    {
        string CreateToken(User user);
    }
}
