using System;
using Raven.Database;
using Raven.Http;
using Raven.Http.Security.OAuth;
using Raven.Abstractions.Extensions;

namespace Raven.Bundles.Authentication
{
	public class AuthenticateClient : IAuthenticateClient
	{
		public bool Authenticate(IResourceStore currentStore, string username, string password, out string[] allowedDatabases)
		{
			allowedDatabases = new string[0];

			var jsonDocument = ((DocumentDatabase)currentStore).Get("Raven/Users/"+username, null);
			if (jsonDocument == null)
			{
				return false;
			}

			var user = jsonDocument.DataAsJson.JsonDeserialization<AuthenticationUser>();

			var validatePassword = user.ValidatePassword(password);
			if (validatePassword)
				allowedDatabases = user.AllowedDatabases;

			return validatePassword;
		}

	}
}