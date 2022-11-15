package com.example.medicijnbewaking.services.AlgorithmServices;

import com.example.medicijnbewaking.model.BasisRegel;
import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.model.PatientMedicine;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class AdviceAlgorithm {

    @Autowired
    NierServiceAlgoritme nierServiceAlgoritme;
    @Autowired
    OsteoporoseprofylaxeServiceAlgoritme osteoporoseprofylaxeServiceAlgoritme;
    @Autowired
    AntimycoticaAlgorithm antimycoticaAlgorithm;

    public List<String> getAdvice(Patient patient, List<PatientMedicine> patientMedicines){
        List<String> advices = new ArrayList<>();
        if(patientMedicines.isEmpty()){
            return null;
        }
        int i =0;
        while (patientMedicines.size()>i){
            PatientMedicine patientMedicine = patientMedicines.get(i);
            String advice = null;
            if(patientMedicine.getMedicine().getBasisRegel() == BasisRegel.nierfunctie){
                advice = nierServiceAlgoritme.testNierMedicaties(patientMedicine.getMedicine(),patient);
            }else if(patientMedicine.getMedicine().getBasisRegel() == BasisRegel.osteoporose){
                List<Medicine> medicineList = new ArrayList<>();
                int j=0;
                while (patientMedicines.size()>j){
                    medicineList.add(patientMedicines.get(j).getMedicine());
                    j++;
                }
                advice = osteoporoseprofylaxeServiceAlgoritme.medicineAlgorithm(patientMedicine,medicineList);
            }else if(patientMedicine.getMedicine().getBasisRegel()==BasisRegel.antimycotica){
                List<Medicine> medicineList = new ArrayList<>();
                int j=0;
                while (patientMedicines.size()>j){
                    medicineList.add(patientMedicines.get(j).getMedicine());
                    j++;
                }
                advice = antimycoticaAlgorithm.medicineAlgorithm(medicineList,patientMedicine);
            }

            if(advice != null){
                advices.add(advice);
            }
            i++;
        }
        return advices;
    }
}
