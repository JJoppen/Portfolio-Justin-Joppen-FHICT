package com.example.medicijnbewaking.model;

import com.fasterxml.jackson.annotation.*;
import lombok.*;

import javax.persistence.*;
import java.time.LocalDate;
import java.util.Date;
import java.util.HashSet;
import java.util.Set;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Builder
@Entity
@Table

public class Patient {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    @Column(name = "First_Name")
    private String firstname;

    @Column(name = "Last_Name")
    private String lastName;

    @Column(name = "Date_Of_Birth")
    private LocalDate dateofbirth;

    @Column(name = "Length")
    private int length;

    @Column(name = "Heartrate")
    private int heartrate;

    @Column(name = "Email")
    private String email;

    @Column(name = "Password")
    private String password;

    @Column(name = "Gender")
    private String gender;

    @Column(name="Clcr")
    private String clcr;

    @Column(name = "Lastclcrtest")
    private LocalDate lastclcrtest;

    @OneToMany(mappedBy = "patient")
    @JsonIgnore
    Set<PatientMedicine> patientMedicines;

}
