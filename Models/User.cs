namespace WebAPI.Models;

public class User {
    //Properties
    public int Id {get; set;}
    public required string Username {get; set;}
    public required string Email {get; set;}
    public required string Fullname {get; set;}
    
    //Constructor Default
}