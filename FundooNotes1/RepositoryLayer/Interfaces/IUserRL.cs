﻿using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        public User AddUser(UserPostModel user);
        public string LoginUser(string email, string password);
    }
}
