﻿using AutoMapper;
using Core.Application.Interfaces;
using Core.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Users.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserVm>
{
    private readonly IUserDbContext _context;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IUserDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);

        if (user == null) throw new Exception("User not found");

        return _mapper.Map<UserVm>(user);
    }
}
