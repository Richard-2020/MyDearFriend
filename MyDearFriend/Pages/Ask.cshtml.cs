using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyDearFriend.Pages
{
    public class AskModel : PageModel
    {

        public bool hasData = false;
        public string message = "";

        public void OnGet()
        {

        }

        public void OnPost() 
        { 
            hasData = true;
            message = Request.Form["message"];
        }
    }
}
