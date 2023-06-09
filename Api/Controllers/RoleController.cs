﻿using Logic.Dtos.RoleDto;
using Logic.MediatR.Commands.RoleCommands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize(Roles = "Admin")]
public class RoleController : BaseController
{
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddRoleDto addRoleDto) =>
        Return(await Mediator.Send(new AddRoleCommand(addRoleDto)));
}