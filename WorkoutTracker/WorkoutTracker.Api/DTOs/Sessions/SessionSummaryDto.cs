namespace WorkoutTracker.Api.DTOs.Sessions;

public class SessionSummaryDto
{
    public int Id { get; set; }
    public DateTime StartedAt { get; set; }
    public int DurationMinutes { get; set; }
    public int TotalSets { get; set; }
}
