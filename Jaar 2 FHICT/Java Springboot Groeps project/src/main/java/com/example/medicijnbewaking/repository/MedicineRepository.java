package com.example.medicijnbewaking.repository;

import com.example.medicijnbewaking.model.Medicine;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Set;

public interface MedicineRepository extends JpaRepository<Medicine,Long> {

    Medicine getMedicineById(long id);
}
