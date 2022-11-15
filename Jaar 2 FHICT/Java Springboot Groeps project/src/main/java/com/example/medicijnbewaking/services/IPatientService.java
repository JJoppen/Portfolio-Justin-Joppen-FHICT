package com.example.medicijnbewaking.services;

import com.example.medicijnbewaking.ViewModel.UserViewModel;
import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.model.PatientMedicine;
import org.springframework.http.ResponseEntity;

import java.util.List;
import java.util.Set;

public interface IPatientService {
    Patient getPatientByIdWithoutMeds(long id);

    List<Patient> getAllPatients();

    Patient savePatient(Patient patient);

    boolean deletePatientById(long id);

    ResponseEntity<Patient> UpdateUser(Patient patientdetails);

    long login(String username);

}
