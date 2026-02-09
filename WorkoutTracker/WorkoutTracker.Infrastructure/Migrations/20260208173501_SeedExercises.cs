using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkoutTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Function", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Bench Press" },
                    { 2, 0, "Incline Dumbbell Press" },
                    { 3, 0, "Overhead Press" },
                    { 4, 0, "Lateral Raise" },
                    { 5, 0, "Tricep Pushdown" },
                    { 6, 1, "Pull Up" },
                    { 7, 1, "Lat Pulldown" },
                    { 8, 1, "Barbell Row" },
                    { 9, 1, "Dumbbell Curl" },
                    { 10, 1, "Face Pull" },
                    { 11, 2, "Barbell Squat" },
                    { 12, 2, "Romanian Deadlift" },
                    { 13, 2, "Leg Extension" },
                    { 14, 2, "Leg Curl" },
                    { 15, 2, "Hip Thrust" }
                });

            migrationBuilder.InsertData(
                table: "Muscles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chest" },
                    { 2, "Front Delt" },
                    { 3, "Side Delt" },
                    { 4, "Rear Delt" },
                    { 5, "Biceps" },
                    { 6, "Triceps" },
                    { 7, "Lats" },
                    { 8, "Quads" },
                    { 9, "Hamstrings" },
                    { 10, "Glutes" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseMuscle",
                columns: new[] { "ExerciseId", "MuscleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 6 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 6 },
                    { 4, 3 },
                    { 5, 6 },
                    { 6, 5 },
                    { 6, 7 },
                    { 7, 7 },
                    { 8, 4 },
                    { 8, 7 },
                    { 9, 5 },
                    { 10, 4 },
                    { 11, 8 },
                    { 11, 10 },
                    { 12, 9 },
                    { 12, 10 },
                    { 13, 8 },
                    { 14, 9 },
                    { 15, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 11, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 11, 10 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 12, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 12, 10 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 13, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 14, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscle",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 15, 10 });

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
