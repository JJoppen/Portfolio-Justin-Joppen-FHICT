using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.DTO;
using InterfaceLaag.IDal;

namespace LogicaLaag.Management
{
    public class Management
    {
        public int id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; } 
        public int PriorityLevel { get; private set; }

        public Management(int id, string Email, string Password, int PriorityLevel)
        {
            this.id = id;
            this.Email = Email;
            this.Password = Password;
            this.PriorityLevel = PriorityLevel;
        }

        public Management(ManagementDTO managementDTO)
        {
            this.id = managementDTO.id;
            this.Email = managementDTO.Email;
            this.Password = managementDTO.Password;
            this.PriorityLevel = managementDTO.PriorityLevel;
        }

    }
}
