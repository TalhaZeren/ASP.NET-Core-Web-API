﻿using AutoMapper;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {   
        private readonly Lazy<IUserService> _userService;

        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger,IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() => new UserManager(repositoryManager,logger,mapper));
        }
        public IUserService UserService => _userService.Value;
    }
}
