

namespace Sanirasu.Models;

public record User
{
    public long UniqueIdentity { get; set; }
    public string FullName { get; set; }
    public string Gender { get; set; }
    public string DateOfBirth { get; set; }
    public long ContactNumber { get; set; }
}

