namespace Domain.DTOs
{
    public class FuncionarioRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }
        public int ProfileId { get; set; }
    }
}
