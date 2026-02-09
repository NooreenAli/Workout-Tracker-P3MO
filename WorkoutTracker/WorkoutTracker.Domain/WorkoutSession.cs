namespace WorkoutTracker.Domain;

public class WorkoutSession
{
    public int Id { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime EndedAt { get; set; }

    public int DurationMinutes =>
        (int)(EndedAt - StartedAt).TotalMinutes;

    public ICollection<WorkoutSet> Sets { get; set; }
        = new List<WorkoutSet>();
}

