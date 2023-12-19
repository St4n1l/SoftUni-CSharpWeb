namespace Contacts.Data
{
    public class Common
    {
        public class ApplicationUser
        {
            public const int UsernameMaxLength = 20;
            public const int UsernameMinLength = 5;

            public const int PasswordMaxLength = 20;
            public const int PasswordMinLength = 5;

            public const int EmailMaxLength = 60;
            public const int EmailMinLength = 10;
        }

        public class Contact
        {
            public const int FirstNameMaxLength = 50;
            public const int FirstNameMinLength = 2;


            public const int LastNameMaxLength = 50;
            public const int LastNameMinLength = 5;

            public const int EmailMaxLength = 60;
            public const int EmailMinLength = 10;
        }
    }
}
