namespace WorkoutTracker.Api.DTOs.Exercises;

public class ExerciseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Function { get; set; }
    public List<string> Muscles { get; set; } = new();
}
