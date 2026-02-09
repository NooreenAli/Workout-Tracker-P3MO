using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Infrastructure;
using WorkoutTracker.Api.DTOs.Exercises;

namespace WorkoutTracker.Api.Services;

public class ExerciseService
{
    private readonly WorkoutDbContext _db;

    public ExerciseService(WorkoutDbContext db)
    {
        _db = db;
    }

    public async Task<List<ExerciseDto>> GetAllAsync()
    {
        return await _db.Exercises
            .Include(e => e.ExerciseMuscles)
                .ThenInclude(em => em.Muscle)
            .Select(e => new ExerciseDto
            {
                Id = e.Id,
                Name = e.Name,
                Function = e.Function.ToString(),
                Muscles = e.ExerciseMuscles
                    .Select(em => em.Muscle.Name)
                    .ToList()
            })
            .ToListAsync();
    }
}
