namespace CBTech.Domain.Services.Interfaces;

public interface IClock
{
    DateTime UtcNow { get; }
}
