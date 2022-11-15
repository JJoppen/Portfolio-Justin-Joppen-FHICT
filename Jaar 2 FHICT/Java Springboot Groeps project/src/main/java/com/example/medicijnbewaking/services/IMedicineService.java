package com.example.medicijnbewaking.services;

import com.example.medicijnbewaking.model.Medicine;

import java.util.List;
import java.util.Optional;

public interface IMedicineService {
    List<Medicine> getAllMedicine();

    Medicine getMedicineById(long id);

}
