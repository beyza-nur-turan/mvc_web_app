namespace MVC_WEB_APP.Models
{
    public class Candidate
    {
        public String? Email {get;set;}=string.Empty; //boş bir empty oluşturuyor
        public String? FirstName {get;set;}=string.Empty;
        public String? LastName {get;set;}=string.Empty;
        public int? Age {get;set;}
        public String? SelectedCourse {get;set;}=string.Empty;
        public DateTime Apply {get;set;}
        public Candidate(){//her nesne üretildiğinde tarih bilgisinin oluşmasını sağlar
            Apply=DateTime.Now;
        }
    } 
        
} 