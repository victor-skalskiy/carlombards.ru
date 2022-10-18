using System;
using CarLombards.Domain;

namespace CarLombards.CMS;

public class UserListModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Status { get; set; }
    public bool IsConfirmed { get; set; }   
}