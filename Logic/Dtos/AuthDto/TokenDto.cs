﻿namespace Logic.Dtos.AuthDto;

public class TokenDto
{
    public IEnumerable<string> Roles { get; set; }
    public string Token { get; set; }
}