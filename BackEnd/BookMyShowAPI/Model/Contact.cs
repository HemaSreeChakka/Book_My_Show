using System.ComponentModel.DataAnnotations;

namespace BookMyShowAPI.Model
{
    public class Contact
    {


         [Key]
          public int UserId { get; set; }



          public string UserName { get; set; } = string.Empty;


          public string UserEmail { get; set; } = string.Empty;

          public string UserMobile { get; set; } = string.Empty;

          public string Password { get; set; } = string.Empty;

          public string ConfirmPassword { get; set; } = string.Empty;

          

       
    }
}
