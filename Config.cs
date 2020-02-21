using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaBot
{
    public static class Config
    {
        public static readonly string AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN", EnvironmentVariableTarget.User);
        public static readonly string SecretKey = Environment.GetEnvironmentVariable("SECRET_KEY", EnvironmentVariableTarget.User);
        public static readonly string Confirmation = Environment.GetEnvironmentVariable("CONFIRMATION", EnvironmentVariableTarget.User);
        public static readonly long ConfirmationGroupId = long.Parse(Environment.GetEnvironmentVariable("CONFIRMATION_GROUP_ID", EnvironmentVariableTarget.User));
    }
}
