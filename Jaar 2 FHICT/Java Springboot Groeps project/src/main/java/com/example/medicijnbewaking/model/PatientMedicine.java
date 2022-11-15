package com.example.medicijnbewaking.model;

import com.example.medicijnbewaking.Enums.DurationType;
import com.example.medicijnbewaking.Enums.MedicationType;
import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table

public class PatientMedicine {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long Id;

    @ManyToOne
    @JsonManagedReference
    @JoinColumn(name = "patient_id")
    Patient patient;

    @ManyToOne
    @JsonManagedReference
    @JoinColumn(name = "medicine_id")
    Medicine medicine;

    @Column(name = "PreviousUses")
    private int PreviousUses;

    @Column(name = "Dose")
    private double Dose;

    @Column(name = "Time")
    private int Time;
    @Column(name = "TimeType")
    private DurationType TimeType;
    @Column(name = "MedicationType")
    private MedicationType Type;
}
