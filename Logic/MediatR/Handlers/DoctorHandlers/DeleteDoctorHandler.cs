﻿using Logic.Data;
using Logic.ErrorHandlers;
using Logic.ErrorHandlers.Errors;
using Logic.MediatR.Commands.DoctorCommands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.MediatR.Handlers.DoctorHandlers;

public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand, Response<bool>>
{
    private readonly IdentityContext _context;

    public DeleteDoctorHandler(IdentityContext context)
    {
        _context = context;
    }

    public async Task<Response<bool>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        var doctor = await _context.Doctors
            .FirstOrDefaultAsync(d => d.Id.Equals(id), cancellationToken);
        
        if(doctor ==null)
            return Response<bool>.Failure(UserErrors.WrongId);

        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}