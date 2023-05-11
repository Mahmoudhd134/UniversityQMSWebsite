﻿namespace Logic.Dtos.MessageDto;

public class MessageDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public string SenderId { get; set; }
    public string SenderUsername { get; set; }
    public string ReceiverId { get; set; }
    public string ReceiverUsername { get; set; }
}