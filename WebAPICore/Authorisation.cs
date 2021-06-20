using Civica.Core.EPortal.Web.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Civica.Core.EPortal.Web
{
    public static class Authorisation
    {
        public static UserCookie BuildUserCookie(UserVm user, string CookieName)
        {
            var cookie = new UserCookie();

            cookie.Name = CookieName ;
            cookie.Value = JsonConvert.SerializeObject(user);
            cookie.Options = new CookieOptions();
            cookie.Options.Expires = DateTime.Now.AddDays(1);
            cookie.Options.HttpOnly = true;
            cookie.Options.Secure = true;
            cookie.Options.SameSite = SameSiteMode.Strict;

            return cookie;
        }

        public static string EncryptPassword(string Password)
        {
            byte[] key = Encoding.UTF8.GetBytes("abcmumbojumboxyz");   //Must be a supported size, e.g. 128 bits (16 bytes)
            byte[] nonce = Encoding.UTF8.GetBytes("abcnoncewxyz");     //Must be 96 bits (12 bytes)
            byte[] plainText = Encoding.UTF8.GetBytes(Password);
            byte[] cipherText = new byte[plainText.Length];            //Must be the same length as the plain text
            byte[] tag = new byte[16];                                 //Must be a supported size, e.g. 128 bits (16 bytes)

            AesGcm aes = new AesGcm(key);
            aes.Encrypt(nonce, plainText, cipherText, tag);

            // Encrypted password needs to be base64 encoded so that it can be passed as part of a URI
            return Convert.ToBase64String(cipherText);
        }
    }
}
