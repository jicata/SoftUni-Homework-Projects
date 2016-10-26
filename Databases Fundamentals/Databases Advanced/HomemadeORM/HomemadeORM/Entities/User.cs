    namespace HomemadeORM.Entities
{
    using System;
    using System.Text;
    using Attributes;

    [Entity("Users")]
    public class User
    {
        [Id]
        private int id;

        [Column("Username")]
        private string username;

        [Column("Password")]
        private string password;

        [Column("Age")]
        private int age;

        [Column("RegistrationDate")]
        private DateTime registrationDate;


        [Column("IsActive")]
        private bool isActive;


        [Column("LastLoginTime")]
        private DateTime lastLoginTime;


        public User(string username, string password, int age, DateTime registrationDate, bool isActive, DateTime lastLoginTime)
        {
            this.Username = username;
            this.Password = password;
            this.Age = age;
            this.RegistrationDate = registrationDate;
            this.IsActive = isActive;
            this.LastLoginTime = lastLoginTime;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public DateTime RegistrationDate
        {
            get
            {
                return registrationDate;
            }

            set
            {
                registrationDate = value;
            }
        }

        public DateTime LastLoginTime
        {
            get
            {
                return lastLoginTime;
            }

            set
            {
                lastLoginTime = value;
                if ((DateTime.Now - value).Days/365 >= 1)
                {
                    this.IsActive = false;
                }
                else
                {
                    this.IsActive = true;
                }
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Id: {this.id}");
            builder.AppendLine($"Name: {this.Username}");
            builder.AppendLine($"Age: {this.Age}");
            builder.Append($"RegDate: {this.RegistrationDate}");
            return builder.ToString();
        }
    }
}
