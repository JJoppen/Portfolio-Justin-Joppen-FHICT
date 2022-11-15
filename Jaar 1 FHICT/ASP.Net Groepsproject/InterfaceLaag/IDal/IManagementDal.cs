using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.DTO;

namespace InterfaceLaag.IDal
{
    public interface IManagementDal
    {
        public List<ManagementDTO> SelecteerAccountList();
        bool AccountWijzigen(ManagementDTO managementDTO);
        void VerwijderAccount(ManagementDTO managementDTO);
    }
}
