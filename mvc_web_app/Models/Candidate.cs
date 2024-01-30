using System.ComponentModel.DataAnnotations;

namespace MVC_WEB_APP.Models
{
    public class Candidate
    {
        [Required(ErrorMessage ="E-Mail is required ")]
        public String? Email {get;set;}=string.Empty; //boş bir empty oluşturuyor
        [Required(ErrorMessage ="FirstName is required ")]
        public String? FirstName {get;set;}=string.Empty;
        [Required(ErrorMessage ="LastName is required ")]
        public String? LastName {get;set;}=string.Empty;
        public String? FullName=>$"{FirstName} {LastName?.ToUpper()}";
        public int? Age {get;set;}
        public String? SelectedCourse {get;set;}=string.Empty;
        public DateTime ApplyAt {get;set;}
        public Candidate(){//her nesne üretildiğinde tarih bilgisinin oluşmasını sağlar
            ApplyAt=DateTime.Now;
        }
    } 
        
} 