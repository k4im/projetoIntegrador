using Microsoft.AspNetCore.Mvc.Rendering;

namespace Estacionamento.Helpers
{
    public class UserHelper
    {
        public static string Admin = "Admin";
        public static string User = "Usuario";
        public static string Gerente = "Gerente";
        public static string Funcionario = "Funcionario";
    
       public static List<SelectListItem> GetRoles()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem {Text = UserHelper.Admin, Value = UserHelper.Admin},
                new SelectListItem {Text = UserHelper.User, Value = UserHelper.User},
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
        
        public static List<SelectListItem> UserRole()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem {Text = UserHelper.User, Value = UserHelper.User}
            };
        }
    
    
        public static List<SelectListItem> RolesParaGerente ()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem{Text = UserHelper.Funcionario, Value = UserHelper.Funcionario},
                new SelectListItem{Text = UserHelper.User, Value = UserHelper.User},

            };
        }
    }
}
