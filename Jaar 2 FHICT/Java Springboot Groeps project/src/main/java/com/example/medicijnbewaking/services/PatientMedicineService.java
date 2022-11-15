package com.example.medicijnbewaking.services;

import com.example.medicijnbewaking.DTO.PatientMedicineDTO;
import com.example.medicijnbewaking.DTO.PatientMedicineDTOConverter;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.model.PatientMedicine;
import com.example.medicijnbewaking.repository.PatientMedicineRepository;
import com.example.medicijnbewaking.services.AlgorithmServices.AdviceAlgorithm;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

@Service
public class PatientMedicineService implements IPatientMedicineService{

    @Autowired
    PatientMedicineRepository patientMedicineRepository;

    @Autowired
    MedicineService medicineService;
    @Autowired
    PatientService patientService;
    @Autowired
    PatientMedicineDTOConverter patientMedicineDTOConverter;
    @Autowired
    AdviceAlgorithm adviceAlgorithm;

    @Override
    public Set<PatientMedicineDTO> getAllMedicineByPatientId(long id) {
       List<PatientMedicine> patientMedicine = patientMedicineRepository.findAllMedicineByPatient_Id(id);
        Set<PatientMedicineDTO> patientMedicineDTOS = new HashSet<>();
        int i =0;
        while(i<patientMedicine.size()){
            patientMedicineDTOS.add(patientMedicineDTOConverter.objectToDto(patientMedicine.get(i)));
            i++;
        }
        return patientMedicineDTOS;
    }

    @Override
    public boolean savePatientMedicine(PatientMedicineDTO patientMedicineDTO) {

        try {

                PatientMedicine patientMedicine = patientMedicineDTOConverter.dtoToObject(patientMedicineDTO);
                patientMedicineRepository.save(patientMedicine);

        }catch (Exception ex){

            return false;
        }
        return true;
    }

    @Override
    public boolean deletePatientMedicine(long id) {
        patientMedicineRepository.deleteById(id);
        return true;
    }

    @Override
    public List<String> getAdvices(long id) {

        List<PatientMedicine> patientMedicines = patientMedicineRepository.findAllMedicineByPatient_Id(id);

        Patient patient = patientMedicines.get(0).getPatient();
        return adviceAlgorithm.getAdvice(patient,patientMedicines);
    }


}
