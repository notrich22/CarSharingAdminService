namespace CarSharingAdminService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DrivingExperienceInYears { get; set; }
        public override string ToString() { return $"{this.Id}) Name: {this.UserName}; {this.DateOfBirth.ToShortDateString()}; DE: {this.DrivingExperienceInYears}"; }

    }
}
