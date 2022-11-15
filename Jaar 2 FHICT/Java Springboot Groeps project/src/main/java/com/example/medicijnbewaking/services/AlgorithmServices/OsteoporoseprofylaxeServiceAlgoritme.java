package com.example.medicijnbewaking.services.AlgorithmServices;

import com.example.medicijnbewaking.Enums.DurationType;
import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.PatientMedicine;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class OsteoporoseprofylaxeServiceAlgoritme {

    @Autowired
    AlgorithmBaseService algorithmBaseService;

    @Autowired
    AtcProvider atcProvider;

    private double greaterOrEqualsDose = 0;
    private double lowerOrEqualDose = 0;

    private String higherRiskWithout = "U heeft mogelijk een verhoogd risico op osteoporose zonder gebruik van osteoporoseprofylaxe," +
            "neem contact op met uw huisarts voor mogelijk gebruik van een bifosfonaat";

    private String higherRiskWith = "U heeft mogelijk een verhoogd risico op osteoporose, de actuele profylaxe is geen eerste keuze." +
            "neem contact op met uw huisarts voor mogelijke vervanging door een bifosfonaat.";
    private String preMenopauzeAndUnder70 = "U heeft een mogelijkheid op osteoporose, neem contact op met uw huisarts voor consult bifosfonaat";

    public String medicineAlgorithm(PatientMedicine patientMedicine, List<Medicine> medicineList){

        medicineSettings(patientMedicine);

        if(isDurationLongerThan10Days(patientMedicine)){

            if(algorithmBaseService.isDoseGreaterOrEqualToX(patientMedicine,greaterOrEqualsDose)){
                return bifosfonateAndCalciumRegulator(medicineList,patientMedicine);
            }else {
                if(algorithmBaseService.isDoseSmallerThanX(patientMedicine,greaterOrEqualsDose) &&
                        algorithmBaseService.isDoseGreaterOrEqualToX(patientMedicine,lowerOrEqualDose)){
                    if(algorithmBaseService.isPatientOlderThanX(patientMedicine.getPatient(),70)){
                        return bifosfonateAndCalciumRegulator(medicineList,patientMedicine);
                    }
                }else {
                    if(patientMedicine.getPatient().getGender()=="female"&&
                            algorithmBaseService.isPatientOlderThanX(patientMedicine.getPatient(),48)){
                        return bifosfonateAndCalciumRegulator(medicineList,patientMedicine);
                    }
                    else {
                        return preMenopauzeAndUnder70+ " voor de volgende medicatie:"+patientMedicine.getMedicine().getMedicineName();
                    }
                }
            }
        }else {
            return null;
        }
        return null;
    }

    private void medicineSettings(PatientMedicine patientMedicine){

        if(patientMedicine.getMedicine().getMedicineName() == "betamethason") {
            greaterOrEqualsDose = 1.95;
            lowerOrEqualDose = 0.975;
        }else if(patientMedicine.getMedicine().getMedicineName()=="cortison"){
            greaterOrEqualsDose =75;
            lowerOrEqualDose = 37.5;
        }else if(patientMedicine.getMedicine().getMedicineName()=="dexamethason"){
            greaterOrEqualsDose =2.25;
            lowerOrEqualDose = 1.125;
        }else if (patientMedicine.getMedicine().getMedicineName()=="hydrocortison"){
            greaterOrEqualsDose =60;
            lowerOrEqualDose = 30;
        }else if(patientMedicine.getMedicine().getMedicineName() =="methylprednisolon" ||
        patientMedicine.getMedicine().getMedicineName() =="triamcinolon"){
            greaterOrEqualsDose =12;
            lowerOrEqualDose = 6;
        }else if(patientMedicine.getMedicine().getMedicineName().contains("prednis")){
            greaterOrEqualsDose =12;
            lowerOrEqualDose = 7.5;
        }
    }

    private String bifosfonateAndCalciumRegulator(List<Medicine> medicineList,PatientMedicine patientMedicine){
        if(!algorithmBaseService.doesOtherMedicationContainAtc(medicineList,atcProvider.getBifosfonaten())){
            if(algorithmBaseService.doesOtherMedicationContainAtc(medicineList,atcProvider.getOtherCalciumRegulators())){
                return higherRiskWithout+" voor de volgende medicatie:"+patientMedicine.getMedicine().getMedicineName();
            }else {
                return higherRiskWith+" voor de volgende medicatie:"+patientMedicine.getMedicine().getMedicineName();
            }
        }else {
            return null;
        }
    }



    private boolean isDurationLongerThan10Days(PatientMedicine patientMedicine){
        if(patientMedicine.getTimeType() != DurationType.days){
            return true;
        }
        else if(patientMedicine.getTime() >=10){
            return true;
        }
        return false;
    }

}
