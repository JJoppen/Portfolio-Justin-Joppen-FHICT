package com.example.medicijnbewaking.services.AlgorithmServices;

import com.example.medicijnbewaking.Enums.DurationType;
import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.model.PatientMedicine;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.Date;
import java.util.List;

@Service
public class AlgorithmBaseService {



    public boolean isTimeDurationGreaterOrEqualToX(PatientMedicine patientMedicine, int time, DurationType type) {
        if(patientMedicine.getTime() >= time && patientMedicine.getTimeType().ordinal() >= type.ordinal()){
            return true;
        }

        return false;
    }

    public boolean isTimeDurationSmallerThanX(PatientMedicine patientMedicine, int time, DurationType type) {

        if(patientMedicine.getTime() >= time && patientMedicine.getTimeType().ordinal() >= type.ordinal()){
            return false;
        }
        return true;
    }
    public boolean isDoseGreaterOrEqualToX(PatientMedicine patientMedicine, double dose){
        if (patientMedicine.getDose() >=dose){
            return true;
        }
        return false;
    }
    public boolean isDoseSmallerThanX(PatientMedicine patientMedicine, double dose){
        if(patientMedicine.getDose()<dose){
            return true;
        }
        return false;
    }

    public boolean isPatientOlderThanX(Patient patient, int age){
        LocalDate localDate = LocalDate.now();
        if(localDate.getYear() - patient.getDateofbirth().getYear() >=age){
            return true;
        }
        return false;
    }

    public boolean doesOtherMedicationContainAtc(List<Medicine> medicineList, List<String> Atc){


        int i = 0;
        while (medicineList.size()<i){
            int j = 0;
            while (Atc.size()<j){
                if(medicineList.get(i).getATC_Code() == Atc.get(j)){
                    return true;
                }
                j++;
            }
            i++;
        }
        return false;
    }

}
