using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaBot
{
    public static class Config
    {
        public static readonly string AccessToken = GetEnvVariable("ACCESS_TOKEN");
        public static readonly string SecretKey = GetEnvVariable("SECRET_KEY");
        public static readonly string Confirmation = GetEnvVariable("CONFIRMATION");
        public static readonly long ConfirmationGroupId = long.Parse(GetEnvVariable("CONFIRMATION_GROUP_ID"));
        
        public static string GetEnvVariable(string envName)
        {
            return Environment.GetEnvironmentVariable(envName, EnvironmentVariableTarget.User) ?? 
                   Environment.GetEnvironmentVariable(envName, EnvironmentVariableTarget.Process) ??
                   Environment.GetEnvironmentVariable(envName, EnvironmentVariableTarget.Machine);
        }
    }
    
}
