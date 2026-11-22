using CBTech.Domain.Services.Interfaces;

namespace CBTech.Infrastructure.Services;

public class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
