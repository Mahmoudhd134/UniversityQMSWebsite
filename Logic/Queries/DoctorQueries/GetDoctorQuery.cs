﻿using Logic.Dtos.DoctorDto;
using Logic.ErrorHandlers;
using MediatR;

namespace Logic.Queries.DoctorQueries;

public record GetDoctorQuery(string Id):IRequest<Response<DoctorDto>>;