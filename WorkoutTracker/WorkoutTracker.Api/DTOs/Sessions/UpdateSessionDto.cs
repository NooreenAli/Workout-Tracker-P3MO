namespace WorkoutTracker.Api.DTOs.Sessions;

public class UpdateSessionDto
{
    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }

    public List<CreateWorkoutSetDto> Sets { get; set; } = new();
}

