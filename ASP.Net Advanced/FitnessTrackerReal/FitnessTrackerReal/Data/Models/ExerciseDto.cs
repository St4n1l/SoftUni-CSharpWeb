﻿namespace FitnessTracker.Data.Models
{
    public class ExerciseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int DifficultyLevel { get; set; }
    }
}
