using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain;

namespace WorkoutTracker.Infrastructure;

public class WorkoutDbContext : DbContext
{
    public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options)
        : base(options)
    {
    }

    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<Muscle> Muscles => Set<Muscle>();
    public DbSet<WorkoutSession> Sessions => Set<WorkoutSession>();
    public DbSet<WorkoutSet> Sets => Set<WorkoutSet>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseMuscle>()
            .HasKey(em => new { em.ExerciseId, em.MuscleId });

        modelBuilder.Entity<WorkoutSet>()
            .Property(ws => ws.WeightKg)
            .HasPrecision(6, 2);

        // Muscles
        modelBuilder.Entity<Muscle>().HasData(
            new Muscle { Id = 1, Name = "Chest" },
            new Muscle { Id = 2, Name = "Front Delt" },
            new Muscle { Id = 3, Name = "Side Delt" },
            new Muscle { Id = 4, Name = "Rear Delt" },
            new Muscle { Id = 5, Name = "Biceps" },
            new Muscle { Id = 6, Name = "Triceps" },
            new Muscle { Id = 7, Name = "Lats" },
            new Muscle { Id = 8, Name = "Quads" },
            new Muscle { Id = 9, Name = "Hamstrings" },
            new Muscle { Id = 10, Name = "Glutes" }
        );

        // Exercises
        modelBuilder.Entity<Exercise>().HasData(
            new Exercise { Id = 1, Name = "Bench Press", Function = ExerciseFunction.Push },
            new Exercise { Id = 2, Name = "Incline Dumbbell Press", Function = ExerciseFunction.Push },
            new Exercise { Id = 3, Name = "Overhead Press", Function = ExerciseFunction.Push },
            new Exercise { Id = 4, Name = "Lateral Raise", Function = ExerciseFunction.Push },
            new Exercise { Id = 5, Name = "Tricep Pushdown", Function = ExerciseFunction.Push },

            new Exercise { Id = 6, Name = "Pull Up", Function = ExerciseFunction.Pull },
            new Exercise { Id = 7, Name = "Lat Pulldown", Function = ExerciseFunction.Pull },
            new Exercise { Id = 8, Name = "Barbell Row", Function = ExerciseFunction.Pull },
            new Exercise { Id = 9, Name = "Dumbbell Curl", Function = ExerciseFunction.Pull },
            new Exercise { Id = 10, Name = "Face Pull", Function = ExerciseFunction.Pull },

            new Exercise { Id = 11, Name = "Barbell Squat", Function = ExerciseFunction.Legs },
            new Exercise { Id = 12, Name = "Romanian Deadlift", Function = ExerciseFunction.Legs },
            new Exercise { Id = 13, Name = "Leg Extension", Function = ExerciseFunction.Legs },
            new Exercise { Id = 14, Name = "Leg Curl", Function = ExerciseFunction.Legs },
            new Exercise { Id = 15, Name = "Hip Thrust", Function = ExerciseFunction.Legs }
        );

        // Exercise-Muscle relationships
        modelBuilder.Entity<ExerciseMuscle>().HasData(

            // Bench Press
            new ExerciseMuscle { ExerciseId = 1, MuscleId = 1 },
            new ExerciseMuscle { ExerciseId = 1, MuscleId = 2 },
            new ExerciseMuscle { ExerciseId = 1, MuscleId = 6 },

            // Incline Dumbbell Press
            new ExerciseMuscle { ExerciseId = 2, MuscleId = 1 },
            new ExerciseMuscle { ExerciseId = 2, MuscleId = 2 },

            // Overhead Press
            new ExerciseMuscle { ExerciseId = 3, MuscleId = 2 },
            new ExerciseMuscle { ExerciseId = 3, MuscleId = 6 },

            // Lateral Raise
            new ExerciseMuscle { ExerciseId = 4, MuscleId = 3 },

            // Tricep Pushdown
            new ExerciseMuscle { ExerciseId = 5, MuscleId = 6 },

            // Pull Up
            new ExerciseMuscle { ExerciseId = 6, MuscleId = 7 },
            new ExerciseMuscle { ExerciseId = 6, MuscleId = 5 },

            // Lat Pulldown
            new ExerciseMuscle { ExerciseId = 7, MuscleId = 7 },

            // Barbell Row
            new ExerciseMuscle { ExerciseId = 8, MuscleId = 7 },
            new ExerciseMuscle { ExerciseId = 8, MuscleId = 4 },

            // Dumbbell Curl
            new ExerciseMuscle { ExerciseId = 9, MuscleId = 5 },

            // Face Pull
            new ExerciseMuscle { ExerciseId = 10, MuscleId = 4 },

            // Barbell Squat
            new ExerciseMuscle { ExerciseId = 11, MuscleId = 8 },
            new ExerciseMuscle { ExerciseId = 11, MuscleId = 10 },

            // Romanian Deadlift
            new ExerciseMuscle { ExerciseId = 12, MuscleId = 9 },
            new ExerciseMuscle { ExerciseId = 12, MuscleId = 10 },

            // Leg Extension
            new ExerciseMuscle { ExerciseId = 13, MuscleId = 8 },

            // Leg Curl
            new ExerciseMuscle { ExerciseId = 14, MuscleId = 9 },

            // Hip Thrust
            new ExerciseMuscle { ExerciseId = 15, MuscleId = 10 }
        );
    }

}