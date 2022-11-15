package com.example.medicijnbewaking.controller;

import com.example.medicijnbewaking.DTO.PatientMedicineDTO;
import com.example.medicijnbewaking.DTO.PatientMedicineDTOConverter;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.model.PatientMedicine;
import com.example.medicijnbewaking.repository.PatientRepository;
import com.example.medicijnbewaking.services.AlgorithmServices.AdviceAlgorithm;
import com.example.medicijnbewaking.services.MedicineService;
import com.example.medicijnbewaking.services.PatientMedicineService;
import com.example.medicijnbewaking.services.PatientService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;

@CrossOrigin(origins = "http://localhost:3000/")
@RestController
@RequestMapping("/api/v1/")
public class PatientMedicineController {

    @Autowired
    private PatientMedicineService patientMedicineService;
    @Autowired
    private AdviceAlgorithm adviceAlgorithm;
    @Autowired
    PatientMedicineDTOConverter patientMedicineDTOConverter;
    //get all medicine by patient id
    @GetMapping(value = "/PatientMedicine/{id}")
    public Set<PatientMedicineDTO> getAllMedicineByPatientId(@PathVariable long id) {
        return patientMedicineService.getAllMedicineByPatientId(id);
    }

    @PostMapping(value = "/PatientMedicine/")
    public boolean savePatientMedicineList(@RequestBody PatientMedicineDTO patientMedicine){

        return patientMedicineService.savePatientMedicine(patientMedicine);
    }
    @DeleteMapping(value = "PatientMedicine/{id}")
    public boolean deletePatientMedicine(@PathVariable long id){
        return patientMedicineService.deletePatientMedicine(id);
    }

    @GetMapping(value = "/PatientMedicine/Advice/{id}")
    public List<String> getPatientAdvice(@PathVariable long id){
       return patientMedicineService.getAdvices(id);
    }

}
