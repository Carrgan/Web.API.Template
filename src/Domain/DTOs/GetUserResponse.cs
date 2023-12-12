namespace Domain.DTOs;

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class GetUserResponse
    {
    
        public User? User { get; set; }
    }


