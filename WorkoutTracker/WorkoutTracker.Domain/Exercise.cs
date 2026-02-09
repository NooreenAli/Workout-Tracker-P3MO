using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Domain;

public class Exercise
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public ExerciseFunction Function { get; set; }

    public ICollection<ExerciseMuscle> ExerciseMuscles { get; set; }
        = new List<ExerciseMuscle>();
}
