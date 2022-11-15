package com.example.medicijnbewaking.DTO;

import com.example.medicijnbewaking.Enums.DurationType;
import com.example.medicijnbewaking.Enums.MedicationType;

import javax.persistence.Column;

public class PatientMedicineDTO {

    public long Id;
    public long userId;
    public long MedicineId;
    public int PreviousUses;
    public double Dose;
    public int Time;
    public DurationType TimeType;
    public MedicationType Type;
}
