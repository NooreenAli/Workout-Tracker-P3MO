using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Infrastructure;
using WorkoutTracker.Domain;
using WorkoutTracker.Api.DTOs.Sessions;

namespace WorkoutTracker.Api.Services;

public class SessionService
{
    private readonly WorkoutDbContext _db;

    public SessionService(WorkoutDbContext db)
    {
        _db = db;
    }

    public async Task<List<SessionSummaryDto>> GetAllAsync()
    {
        return await _db.Sessions
            .Select(s => new SessionSummaryDto
            {
                Id = s.Id,
                StartedAt = s.StartedAt,
                DurationMinutes = s.DurationMinutes,
                TotalSets = s.Sets.Count
            })
            .ToListAsync();
    }

    public async Task<SessionDetailDto?> GetByIdAsync(int id)
    {
        return await _db.Sessions
            .Where(s => s.Id == id)
            .Select(s => new SessionDetailDto
            {
                Id = s.Id,
                StartedAt = s.StartedAt,
                EndedAt = s.EndedAt,
                DurationMinutes = s.DurationMinutes,
                Sets = s.Sets.Select(set => new WorkoutSetDto
                {
                    ExerciseId = set.ExerciseId,
                    ExerciseName = set.Exercise.Name,
                    Reps = set.Reps,
                    WeightKg = set.WeightKg
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateAsync(CreateSessionDto dto)
    {
        var session = new WorkoutSession
        {
            StartedAt = dto.StartedAt,
            EndedAt = dto.EndedAt,
            Sets = dto.Sets.Select(s => new WorkoutSet
            {
                ExerciseId = s.ExerciseId,
                Reps = s.Reps,
                WeightKg = s.WeightKg
            }).ToList()
        };

        _db.Sessions.Add(session);
        await _db.SaveChangesAsync();

        return session.Id;
    }

    public async Task<bool> UpdateAsync(int id, UpdateSessionDto dto)
    {
        var session = await _db.Sessions
            .Include(s => s.Sets)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (session == null)
            return false;

        session.StartedAt = dto.StartedAt;
        session.EndedAt = dto.EndedAt;

        _db.Sets.RemoveRange(session.Sets);

        session.Sets = dto.Sets.Select(s => new WorkoutSet
        {
            ExerciseId = s.ExerciseId,
            Reps = s.Reps,
            WeightKg = s.WeightKg
        }).ToList();

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var session = await _db.Sessions.FindAsync(id);

        if (session == null)
            return false;

        _db.Sessions.Remove(session);
        await _db.SaveChangesAsync();

        return true;
    }
}

