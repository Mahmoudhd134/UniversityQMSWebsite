﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Logic.Data;
using Logic.Dtos.MessageDto;
using Logic.ErrorHandlers;
using Logic.ErrorHandlers.Errors;
using Logic.MediatR.Queries;
using Logic.MediatR.Queries.MessgeQueries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.MediatR.Handlers.MessageHandler;

public class GetMessageByIdHandler : IRequestHandler<GetMessageByIdQuery, Response<MessageDto>>
{
    private readonly IdentityContext _context;
    private readonly IMapper _mapper;

    public GetMessageByIdHandler(IdentityContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<MessageDto>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
    {
        var (id, userId) = request;
        var message = await _context.Messages
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        if (message.SenderId.Equals(userId) == false && message.ReceiverId.Equals(userId) == false)
            return Response<MessageDto>.Failure(MessageErrors.UnAuthorizeGet);

        var idToName = _context.Users
            .Where(u => u.Id.Equals(message.ReceiverId) || u.Id.Equals(message.SenderId))
            .Select(s => new { s.Id, s.UserName })
            .Take(2)
            .ToList();


        var messageDto = _mapper.Map<MessageDto>(message);

        messageDto.SenderUsername = idToName.FirstOrDefault(i => i.Id.Equals(message.SenderId))?.UserName;
        messageDto.ReceiverUsername = idToName.FirstOrDefault(i => i.Id.Equals(message.ReceiverId))?.UserName;

        if (message.Read || message.SenderId.Equals(userId))
            return messageDto;

        message.Read = true;
        _context.Messages.Update(message);
        await _context.SaveChangesAsync(cancellationToken);
        return messageDto;
    }
}