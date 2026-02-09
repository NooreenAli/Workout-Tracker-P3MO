namespace WorkoutTracker.Domain;

public class ExerciseMuscle
{
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }

    public int MuscleId { get; set; }
    public Muscle Muscle { get; set; }
}
