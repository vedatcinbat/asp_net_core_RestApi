namespace HelloWebApi.Models {
    public class Student {
        public int Id {get; set;}
        public string StudentFirstName {get; set;} = String.Empty;
        public string StudentLastName {get; set;} = String.Empty;
        public string StudentGrade {get; set;} = String.Empty;
    }
}