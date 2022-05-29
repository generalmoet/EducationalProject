using AutoMapper;
using Core.Application.Interfaces;
using Core.Domain.Models;
using MediatR;

namespace Core.Application.Users.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
{
    private readonly IUserDbContext _context;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IUserDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == request.Id);

        if (user == null) throw new Exception("User not found");

        return _mapper.Map<UserViewModel>(user);
    }
}
