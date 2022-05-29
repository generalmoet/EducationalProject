using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.Interfaces;
using Core.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Users.Queries;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserListVm>
{
    private readonly IUserDbContext _context;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserListVm> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users
            .ProjectTo<UserListDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        if (users == null) throw new Exception("No users");

        return new UserListVm { Users = users };
    }
}
