namespace WorkoutTracker.Domain;

public class WorkoutSet
{
    public int Id { get; set; }

    public int WorkoutSessionId { get; set; }
    public WorkoutSession WorkoutSession { get; set; }

    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }

    public int Reps { get; set; }

    public decimal WeightKg { get; set; }
}

