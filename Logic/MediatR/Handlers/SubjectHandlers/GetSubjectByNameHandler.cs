﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Logic.Data;
using Logic.Dtos.SubjectDto;
using Logic.ErrorHandlers;
using Logic.ErrorHandlers.Errors;
using Logic.MediatR.Queries.SubjectQueries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.MediatR.Handlers.SubjectHandlers;

public class GetSubjectByNameHandler : IRequestHandler<GetSubjectByNameQuery, Response<SubjectDto>>
{
    private readonly IdentityContext _context;
    private readonly IMapper _mapper;

    public GetSubjectByNameHandler(IdentityContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<SubjectDto>> Handle(GetSubjectByNameQuery request, CancellationToken cancellationToken)
    {
        var (name, roles, id) = request;
        var subjectDto = await _context.Subjects
            .Include(s => s.DoctorSubject)
            .ThenInclude(x => x.Doctor)
            .Include(s => s.SubjectMaterials)
            .AsSplitQuery()
            .ProjectTo<SubjectDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(
                s => (s.Department.ToUpper() + s.Code.ToString()).Equals(name.ToUpper()), cancellationToken);

        if (subjectDto == null)
            return Response<SubjectDto>.Failure(SubjectErrors.WrongName);

        if (roles.Contains("Admin") == false && roles.Contains("Doctor"))
            if (await _context.DoctorSubjects.AnyAsync(x => x.SubjectId == subjectDto.Id && x.DoctorId.Equals(id),
                    cancellationToken) == false)
                return Response<SubjectDto>.Failure(SubjectErrors.UnAuthorizedGet);

        return subjectDto;
    }
}