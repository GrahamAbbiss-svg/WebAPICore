using BO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestMVC.Services;

namespace TestMVC.DapperCalls
{
    public class DapperDatabaseCalls
    {
        private readonly IDapper _dapper;
        public DapperDatabaseCalls(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<List<Employees>> GetEmployees()
        {
            int streamID = 2;
            return await Task.FromResult(_dapper.GetAll<Employees>($"select EmployeePID,FirstName,LastName from [CIMS].[Employees] where streamid={streamID}", null, commandType: CommandType.Text));
        }

        public async Task<Employees> GetEmployee()
        {

            return await Task.FromResult(_dapper.Get<Employees>($"select EmployeePID,FirstName,LastName from [CIMS].[Employees]", null, commandType: CommandType.Text));
        }


        public async Task<UserLogin> GetUser(string UserId, string password)
        {
            var dbparams = new DynamicParameters();

            dbparams.Add("@UserId", UserId, DbType.String);
            dbparams.Add("@Password", password, DbType.String);
            return await Task.FromResult(_dapper.Get<UserLogin>("[dbo].[GetUsers]", dbparams, commandType: CommandType.StoredProcedure));
        }
        public async void AddEmployee()
        {
            var dbparams = new DynamicParameters();

            dbparams.Add("@employeePID", 8745211, DbType.Int32);
            dbparams.Add("@firstname", "Dappy1", DbType.String);
            dbparams.Add("@lastname", "Dapper1", DbType.String);
            dbparams.Add("@gradeid", 2, DbType.Int32);
            dbparams.Add("@streamid", 2, DbType.Int32);
            dbparams.Add("@areaid", 2, DbType.Int32);
            dbparams.Add("@teamid", 3, DbType.Int32);
            dbparams.Add("@liveStatus", 0, DbType.Int32);

            var result = await Task.FromResult(_dapper.Insert<int>("[CIMS].[usp_AddUpdateEmployee]", dbparams, commandType: CommandType.StoredProcedure));

        }
    }
}

