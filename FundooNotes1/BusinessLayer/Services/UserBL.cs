using BusinessLayer.Interfaces;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public User AddUser(UserPostModel user)
        {
            try
            {
                return this.userRL.AddUser(user);
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
                return userRL.LoginUser(email, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
