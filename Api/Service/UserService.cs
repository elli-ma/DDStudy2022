﻿using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Api.Service
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly DAL.DataContext _context;
        public UserService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        } 
     
     public async Task createUser(CreateUserModel model)
        {
        var dbUser = _mapper.Map<DAL.Entities.User>(model);
    await _context.Users.AddAsync(dbUser);
    await _context.SaveChangesAsync();
        }
   
          public async Task<List<UserModel>> GetUser()
        {
            return await _context.Users.AsNoTracking().ProjectTo<UserModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

    }
}

