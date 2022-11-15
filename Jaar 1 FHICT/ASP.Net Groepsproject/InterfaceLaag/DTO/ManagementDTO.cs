using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.DTO
{
    public class ManagementDTO
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PriorityLevel { get; set; }
        public ManagementDTO(int id, string email, string password, int prioritylevel)
        {
            this.id = id;
            this.Email = email;
            this.Password = password;
            this.PriorityLevel = prioritylevel;
        }

        public ManagementDTO()
        {

        }
    }
}
