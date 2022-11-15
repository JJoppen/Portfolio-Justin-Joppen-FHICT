using InterfaceLaag.DTO;
using InterfaceLaag.IDal;
using InterfaceLaag.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_tests_.ManagementTestOnderdelen
{
    public class ManagementStub : IManagementDal
    {
        public bool RetVal { get; set; }
        public ManagementDTO LastAccount = new ManagementDTO();

        public bool AccountWijzigen(ManagementDTO managementDTO)
        {
            LastAccount.Email = managementDTO.Email;
            LastAccount.Password = managementDTO.Password;
            LastAccount.PriorityLevel = managementDTO.PriorityLevel;
            LastAccount.id = managementDTO.id;
            return RetVal;
        }

        public List<ManagementDTO> SelecteerAccountList()
        { 
            List<ManagementDTO> managementDTOs = new List<ManagementDTO>();
            ManagementDTO managementDTO = new ManagementDTO();
            managementDTO.Email = "Test";
            managementDTO.id = 1;
            managementDTO.Password = "1234";
            managementDTO.PriorityLevel = 4;
            managementDTOs.Add(managementDTO);

            return managementDTOs;
        }

        public void VerwijderAccount(ManagementDTO managementDTO)
        {
            LastAccount.id = managementDTO.id;
            LastAccount.Email = managementDTO.Email;
            LastAccount.Password = managementDTO.Password;
            LastAccount.PriorityLevel = managementDTO.PriorityLevel;
        }
    }
}
