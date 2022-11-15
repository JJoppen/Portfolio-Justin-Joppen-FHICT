package com.example.medicijnbewaking.repository;

import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.model.PatientMedicine;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Set;

public interface PatientMedicineRepository extends JpaRepository<PatientMedicine,Long> {
    List<PatientMedicine> findAllMedicineByPatient_Id(long id);

}
