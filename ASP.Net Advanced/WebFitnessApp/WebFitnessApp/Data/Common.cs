using System.ComponentModel.DataAnnotations;

namespace WebFitnessApp.Data
{
    public class Common
    {

        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Workout
        {
            public const int NameMinLength = 10;
            public const int NameMaxLength = 50;

            public const int AddressMinLength = 30;
            public const int AddressMaxLength = 150;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;

            public const int ImageUrlMaxLength = 2048;

            public const int IntensityMinLevel = 1;
            public const int IntensityMaxLevel = 10;


            public const int DurationMinValue = 5;
            public const int DurationMaxValue = 600;
        }

        public static class Instructor
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class User
        {
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;

            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 15;
        }

        public static class Exercise
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;

            public const int DifficultyLevelMinLevel = 1;
            public const int DifficultyLevelMaxLevel = 10;
        }
    }
}

