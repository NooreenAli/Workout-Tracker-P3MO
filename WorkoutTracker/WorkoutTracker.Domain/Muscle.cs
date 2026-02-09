using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Domain;

public class Muscle
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public ICollection<ExerciseMuscle> ExerciseMuscles { get; set; }
        = new List<ExerciseMuscle>();
}
