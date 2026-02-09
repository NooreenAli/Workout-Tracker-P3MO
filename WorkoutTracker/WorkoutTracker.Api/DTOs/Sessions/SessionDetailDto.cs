namespace WorkoutTracker.Api.DTOs.Sessions;

public class SessionDetailDto
{
    public int Id { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }
    public int DurationMinutes { get; set; }
    public List<WorkoutSetDto> Sets { get; set; } = new();
}

