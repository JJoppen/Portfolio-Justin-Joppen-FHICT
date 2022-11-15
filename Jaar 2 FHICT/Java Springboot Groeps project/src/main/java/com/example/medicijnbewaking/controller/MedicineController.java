package com.example.medicijnbewaking.controller;

import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.model.PatientMedicine;
import com.example.medicijnbewaking.services.MedicineService;
import com.example.medicijnbewaking.services.PatientService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Set;

@CrossOrigin(origins = "http://localhost:3000/")
@RestController
@RequestMapping("/api/v1/")
public class MedicineController {
    @Autowired
    private MedicineService medicineService;


    // get all medicine
    @GetMapping(value = "/Medicines")
    public List<Medicine> getAllMedicines()
    {
        return medicineService.getAllMedicine();
    }
    @GetMapping(value = "/Medicine/{id}")
    public Medicine getMedicineById(@PathVariable long id){
        return medicineService.getMedicineById(id);
    }


}
