using CommonLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooNoteContext;
using RepositoryLayer.Interfaces;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.UserClass
{
    public class UserRL : IUserRL
    {
        FundooContext fundoo;
        private readonly IConfiguration configuration;
        public UserRL(FundooContext fundoo, IConfiguration configuration)
        {
            this.fundoo = fundoo;
            this.configuration = configuration;
        }
        public User AddUser(UserPostModel user)
        {
            try
            {
                User user1 = new User();
                user1.UserID = new User().UserID;
                user1.FirstName = user.FirstName;
                user1.LastName = user.LastName;
                user1.Email = user.Email;
                user1.Password = EncryptPassword(user.Password);
                user1.RegisterDate = DateTime.Now;
                user1.Address = user.Address;
                fundoo.Users.Add(user1);
                fundoo.SaveChanges();
                return user1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string LoginUser(string email, string password)
        {
            try
            {
                var result = fundoo.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
                if (result == null)
                {
                    return null;
                }

                return GetJWTToken(email, result.UserID);
                //string password = password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Generate JwT token
        private static string GetJWTToken(string email, int UserID)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("email", email),
                    new Claim("userId",UserID.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        // Encryption of the Password
        public static string EncryptPassword(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                {
                    return null;
                }
                else
                {
                    byte[] b = Encoding.ASCII.GetBytes(password);
                    string encrypted = Convert.ToBase64String(b);
                    return encrypted;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Decryption of the password
        public static string DecryptedPassword(string encryptedPassword)
        {
            byte[] b;
            string decrypted;
            try
            {
                if (string.IsNullOrEmpty(encryptedPassword))
                {
                    return null;
                }
                else
                {
                    b = Convert.FromBase64String(encryptedPassword);
                    decrypted = Encoding.ASCII.GetString(b);
                    return decrypted;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
