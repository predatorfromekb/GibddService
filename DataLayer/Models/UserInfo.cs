using System;

namespace DataLayer.Models
{
    public class UserInfo
    {
        public DateTime? BirthDate { get; }
        public int? PassportSeries { get; }
        public int? PassportNumber { get; }

        public UserInfo(DateTime? birthDate, int? passportSeries, int? passportNumber)
        {
            BirthDate = birthDate;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
        }
    }
}