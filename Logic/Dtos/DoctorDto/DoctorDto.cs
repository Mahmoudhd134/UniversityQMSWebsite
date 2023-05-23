﻿using Logic.Dtos.SubjectDto;

namespace Logic.Dtos.DoctorDto;

public class DoctorDto
{
    public string Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalNumber { get; set; }
    public bool IsOwner { get; set; }
    public IList<SubjectForPageDto> Subjects { get; set; }
    public bool IsComplete { get; set; }
    public string ProfilePhoto { get; set; }
}