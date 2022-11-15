package com.example.medicijnbewaking.controller;

import com.example.medicijnbewaking.ViewModel.UserViewModel;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.services.PatientService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@CrossOrigin(origins = "http://localhost:3000/")
@RestController
@RequestMapping("/api/v1/")
public class PatientWithoutMedsController {
    @Autowired
    private PatientService patientService;

    @GetMapping(value = "PatientWithoutMeds/{id}")
    public Patient getPatientByIdWithoutMeds(@PathVariable long id) {
        return patientService.getPatientByIdWithoutMeds(id);
    }
}
