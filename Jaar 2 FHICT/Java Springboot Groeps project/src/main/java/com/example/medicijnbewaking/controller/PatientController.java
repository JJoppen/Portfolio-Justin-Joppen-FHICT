package com.example.medicijnbewaking.controller;

import com.example.medicijnbewaking.exceptions.ResourceNotFoundException;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.repository.PatientRepository;
import com.example.medicijnbewaking.services.PatientService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@CrossOrigin(origins = "http://localhost:3000/")
@RestController
@RequestMapping("/api/v1/")
public class PatientController {
    @Autowired
    private PatientService patientService;

    // get all patients
    @GetMapping(value = "/Patients")
    public List<Patient> GetAllPatients()
    {
        return patientService.getAllPatients();
    }

    //get single patient
    @GetMapping("/Patient/{id}")
    public Patient GetPatient(@PathVariable long id)
    {
        return patientService.getPatientById(id);
    }

    //save patient
    @PostMapping("/Patient")
    public Patient SavePatient(@RequestBody Patient patient)
    {
        return patientService.savePatient(patient);
    }

    @PostMapping("/Login/{email}")
    public long login(@PathVariable String email){
        return patientService.login(email);
    }

    //Delete patient
    @DeleteMapping("/Patient/{id}")
    public boolean DeletePatient(@PathVariable long id)
    {
        return patientService.deletePatientById(id);
    }
    @PutMapping("/Patient")
    public ResponseEntity<Patient>UpdateUser(@RequestBody Patient patientdetails) throws ResourceNotFoundException{
        return patientService.UpdateUser(patientdetails);
    }



}
