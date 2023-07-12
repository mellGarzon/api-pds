using System;
using PDS.Domain.Entities;

namespace PDS.Domain.Interfaces.ServiceInterfaces
{
	public interface ITokenService
	{
        string CreateToken(long userId, string role);
        long GetUserId();
        string GetUserRole();

    }
}

