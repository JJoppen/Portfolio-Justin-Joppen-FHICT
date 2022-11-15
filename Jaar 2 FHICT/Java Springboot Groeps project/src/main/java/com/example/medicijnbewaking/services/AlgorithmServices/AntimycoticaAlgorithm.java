package com.example.medicijnbewaking.services.AlgorithmServices;

import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.PatientMedicine;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AntimycoticaAlgorithm {

    @Autowired
    AlgorithmBaseService algorithmBaseService;

    @Autowired
    AtcProvider atcProvider;
    public String medicineAlgorithm(List<Medicine> medicineList, PatientMedicine patientMedicine){

        if(algorithmBaseService.doesOtherMedicationContainAtc(medicineList,atcProvider.getCorticosteroïd())){
            return "Bij uw inhalator is het mogelijk nodig om een antimycoticum voorgescheven te krijgen, bespreek dit met uw huisarts";
        }else {
            return null;
        }
    }




}
