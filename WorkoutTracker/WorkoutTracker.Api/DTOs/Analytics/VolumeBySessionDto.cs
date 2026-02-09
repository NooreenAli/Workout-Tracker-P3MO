namespace WorkoutTracker.Api.DTOs.Analytics;

public class VolumeBySessionDto
{
    public int SessionId { get; set; }
    public DateTime StartedAt { get; set; }
    public decimal TotalVolume { get; set; }
}

