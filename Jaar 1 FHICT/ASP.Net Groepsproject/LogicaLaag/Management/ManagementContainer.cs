using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.IDal;
using InterfaceLaag.DTO;

namespace LogicaLaag.Management
{
    public class ManagementContainer
    {
        private IManagementDal imanagementDal;

        public ManagementContainer(IManagementDal managementDal)
        {
            imanagementDal = managementDal;
        }

        public List<Management> SelecteerAccounts()
        {
            List<ManagementDTO> managementDTOs;
            managementDTOs = imanagementDal.SelecteerAccountList();
            List<Management> managements = new List<Management>();
            foreach(ManagementDTO managementDTO in managementDTOs)
            {
                Management management = OmzettenNaarManagement(managementDTO);
                managements.Add(management);
            }
            return managements;
        }

        public Management OmzettenNaarManagement(ManagementDTO managementdto)
        {
            Management management = new Management(managementdto);
            return management;
        }

        public bool AccountWijzigen(Management management)
        {
            ManagementDTO managementDTO = new ManagementDTO(management.id,management.Email,management.Password, management.PriorityLevel);
            return imanagementDal.AccountWijzigen(managementDTO);
        }

        public void VerwijderAccount(Management management)
        {
            ManagementDTO managementDTO = new ManagementDTO(management.id, management.Email, management.Password, management.PriorityLevel);
            imanagementDal.VerwijderAccount(managementDTO);
        }
    }
}
