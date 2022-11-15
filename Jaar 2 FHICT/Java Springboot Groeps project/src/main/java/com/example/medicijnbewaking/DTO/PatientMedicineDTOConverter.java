package com.example.medicijnbewaking.DTO;

import com.example.medicijnbewaking.model.PatientMedicine;
import com.example.medicijnbewaking.repository.MedicineRepository;
import com.example.medicijnbewaking.repository.PatientMedicineRepository;
import com.example.medicijnbewaking.repository.PatientRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class PatientMedicineDTOConverter {
    @Autowired
    MedicineRepository medicineRepository;
    @Autowired
    PatientRepository patientRepository;

    public PatientMedicine dtoToObject(PatientMedicineDTO patientMedicineDTO){
        PatientMedicine patientMedicine = new PatientMedicine();
        patientMedicine.setMedicine(medicineRepository.getMedicineById(patientMedicineDTO.MedicineId));
        patientMedicine.setPatient(patientRepository.getPatientById(patientMedicineDTO.userId));
        patientMedicine.setId(patientMedicineDTO.Id);
        patientMedicine.setDose(patientMedicineDTO.Dose);
        patientMedicine.setTime(patientMedicineDTO.Time);
        patientMedicine.setTimeType(patientMedicineDTO.TimeType);
        patientMedicine.setPreviousUses(patientMedicineDTO.PreviousUses);
        patientMedicine.setType(patientMedicineDTO.Type);

        return patientMedicine;

    }
    public PatientMedicineDTO objectToDto(PatientMedicine patientMedicine){
        PatientMedicineDTO dto = new PatientMedicineDTO();
        dto.Id = patientMedicine.getId();
        dto.userId=patientMedicine.getPatient().getId();
        dto.MedicineId=patientMedicine.getMedicine().getId();
        dto.Dose=patientMedicine.getDose();
        dto.Type=patientMedicine.getType();
        dto.Time=patientMedicine.getTime();
        dto.PreviousUses=patientMedicine.getPreviousUses();
        dto.TimeType=patientMedicine.getTimeType();
        return dto;
    }
}
