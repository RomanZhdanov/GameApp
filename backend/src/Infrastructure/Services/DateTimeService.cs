using GameApp.Application.Common.Interfaces;

namespace GameApp.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
