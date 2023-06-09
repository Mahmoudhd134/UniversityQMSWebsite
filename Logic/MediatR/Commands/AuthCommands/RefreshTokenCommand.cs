﻿using Logic.Dtos.AuthDto;
using Logic.ErrorHandlers;
using MediatR;

namespace Logic.MediatR.Commands.AuthCommands;

public record RefreshTokenCommand
    (string UserId, string RefreshToken, string UserAgent) : IRequest<Response<RefreshTokenDto>>;