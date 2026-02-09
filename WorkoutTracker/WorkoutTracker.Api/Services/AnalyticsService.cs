using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Infrastructure;
using WorkoutTracker.Api.DTOs.Analytics;

namespace WorkoutTracker.Api.Services;

public class AnalyticsService
{
    private readonly WorkoutDbContext _db;

    public AnalyticsService(WorkoutDbContext db)
    {
        _db = db;
    }

    public async Task<List<VolumeBySessionDto>> GetVolumeBySessionAsync()
    {
        return await _db.Sessions
            .Select(s => new VolumeBySessionDto
            {
                SessionId = s.Id,
                StartedAt = s.StartedAt,
                TotalVolume = s.Sets.Sum(set => set.Reps * set.WeightKg)
            })
            .ToListAsync();
    }

    public async Task<List<SetsByExerciseDto>> GetSetsByExerciseAsync()
    {
        return await _db.Sets
            .GroupBy(s => s.Exercise.Name)
            .Select(g => new SetsByExerciseDto
            {
                ExerciseName = g.Key,
                TotalSets = g.Count()
            })
            .ToListAsync();
    }
}

