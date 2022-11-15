package com.example.medicijnbewaking.services;

import com.example.medicijnbewaking.DTO.PatientMedicineDTO;
import com.example.medicijnbewaking.model.PatientMedicine;

import java.util.List;
import java.util.Set;

public interface IPatientMedicineService {
    Set<PatientMedicineDTO> getAllMedicineByPatientId(long id);

    boolean savePatientMedicine(PatientMedicineDTO patientMedicineDTO);

    boolean deletePatientMedicine(long id);
    List<String> getAdvices(long id);
}
