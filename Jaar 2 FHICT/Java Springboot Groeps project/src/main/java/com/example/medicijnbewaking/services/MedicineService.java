package com.example.medicijnbewaking.services;

import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.repository.MedicineRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class MedicineService implements IMedicineService{
    @Autowired
    private MedicineRepository medicineRepository;



    @Override
    public List<Medicine> getAllMedicine() {
        return medicineRepository.findAll();
    }

    @Override
    public Medicine getMedicineById(long id) {
        return medicineRepository.getMedicineById(id);
    }


}
