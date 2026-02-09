namespace WorkoutTracker.Api.DTOs.Sessions;

public class CreateSessionDto
{
    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }

    public List<CreateWorkoutSetDto> Sets { get; set; } = new();
}

public class CreateWorkoutSetDto
{
    public int ExerciseId { get; set; }
    public int Reps { get; set; }
    public decimal WeightKg { get; set; }
}

