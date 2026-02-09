using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Api.DTOs.Sessions;

public class WorkoutSetDto
{
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; }

    [Range(1, int.MaxValue)]
    public int Reps { get; set; }

    [Range(0, 9999.99)]
    public decimal WeightKg { get; set; }
}
