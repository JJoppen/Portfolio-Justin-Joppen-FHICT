package com.example.medicijnbewaking.repository;

import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.Patient;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PatientRepository extends JpaRepository<Patient,Long> {

     Patient getPatientById(long id);

     Patient findPatientByEmailEquals(String email);
}
