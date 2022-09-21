using Microsoft.AspNetCore.Mvc.Rendering;

namespace Estacionamento.Helpers
{
    public class UserHelper
    {
        public static string Admin = "Admin";
        public static string Gerente = "Gerente";
        public static string Funcionario = "Funcionario";
    
       public static List<SelectListItem> GetRoles()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem {Text = UserHelper.Gerente, Value = UserHelper.Gerente},
                new SelectListItem {Text = UserHelper.Funcionario, Value = UserHelper.Funcionario}
            };
        }

        public static List<SelectListItem> AdminRole()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem {Text = UserHelper.Admin, Value = UserHelper.Admin},
            };
        }
    }
}
