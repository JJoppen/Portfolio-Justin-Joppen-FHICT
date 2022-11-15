package com.example.medicijnbewaking.services.AlgorithmServices;

import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.services.AlgorithmServices.AlgorithmBaseService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDate;


@Service
public class NierServiceAlgoritme {
    @Autowired
    AlgorithmBaseService algorithmBaseService;

    private String ClcrOver10Onder30;
    private String ClcrTestLangerdan13geleden = "Overleg met uw huisarts of uw nierfunctie gecontroleerd moet worden.";
    private String ClcrOnder10;
    private String PatientOver70= "Overleg met uw huisarts of uw nierfunctie gecontroleerd moet worden";

    public String testNierMedicaties(Medicine medicine, Patient patient){
        checkMedicineType(medicine);

        return medicineAlgorithm(patient);
    }

    private String medicineAlgorithm(Patient patient){
        if (patient.getClcr() != null){
            if(mostRecentClcrOver13(patient)){
                return ClcrTestLangerdan13geleden;
            }
            else if (isClcrOverX(patient,10)){
                if(isClcrOverX(patient,30)){
                    return null;
                }
                return ClcrOver10Onder30;
            }
            return ClcrOnder10;
        }
        else if(algorithmBaseService.isPatientOlderThanX(patient,70)){
            return PatientOver70;
        }
        return null;
    }

    private void checkMedicineType(Medicine medicine){
        if(medicine.getMedicineName() == "nitrofurantoïne" ){
            ClcrOver10Onder30 = "Bij verminderde nierfunctie kan de medicatie cumuleren, overleg met huisarts voor vervanging ander antibacterium.";
            ClcrOnder10 = "Overleg met huisarts, mogelijkheden op ernstige schade";
        }
        else if(medicine.getMedicineName()=="norfloxacine"){
            ClcrOnder10 = "Mogelijkheden extra bijwerkingen, overleg met arts";
            ClcrOver10Onder30 = "Overleg met huisarts, aanradingen zijn: Geef normale keerdosis met interval van 24 uur";
        }
        else if(medicine.getMedicineName()=="cotrimoxazol"){
            ClcrOver10Onder30 = "Overleg met uw huisarts of uw dosis verminderd moet worden of de inname tijd verdubbelt";
            ClcrOnder10 = "Mogelijkheden extra bijwerkingen, overleg met arts";
        }
    }
    private boolean mostRecentClcrOver13(Patient patient){

        int totalMonthsAtTest = ((patient.getLastclcrtest().getYear() *12) + patient.getLastclcrtest().getMonth().getValue());
        int totalMonthsNow = ((LocalDate.now().getYear() *12)+ LocalDate.now().getMonth().getValue());
        if(totalMonthsNow - totalMonthsAtTest >=13){
            return true;
        }
        return false;
    }
    private boolean isClcrOverX(Patient patient, int clcr){
        if(Integer.parseInt(patient.getClcr()) >clcr){
            return true;
        }
        return false;
    }

}
