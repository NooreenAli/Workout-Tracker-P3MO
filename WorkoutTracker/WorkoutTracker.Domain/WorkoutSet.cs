using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Domain;

public class WorkoutSet
{
    public int Id { get; set; }

    public int WorkoutSessionId { get; set; }
    public WorkoutSession WorkoutSession { get; set; }

    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }

    [Range(1, 1000)]
    public int Reps { get; set; }

    [Range(0, 2000)]
    public decimal WeightKg { get; set; }
}

