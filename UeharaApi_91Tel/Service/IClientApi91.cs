using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UeharaApi_91Tel.Models;

namespace UeharaApi_91Tel.Service
{
	public interface IClientApi91
	{
        Task<List<LogResponse>> GetLogs(string token, string datetime);
        Task<Response91Model> Authentication(string grant_type, string username, string password);
	}
}
