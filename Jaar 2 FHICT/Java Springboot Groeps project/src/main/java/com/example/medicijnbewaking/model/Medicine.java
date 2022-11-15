package com.example.medicijnbewaking.model;

import com.example.medicijnbewaking.Enums.DurationType;
import com.example.medicijnbewaking.Enums.MedicationType;
import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import java.util.List;
import java.util.Set;

@Getter
@Setter
@Entity
@Table
@NoArgsConstructor
@AllArgsConstructor
public class Medicine {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    @Column(name="MedicineName")
    private String MedicineName;

    @Column(name = "ATC_Code")
    private String ATC_Code;

    @Column(name = "Description")
    private String description;

    @Column(name = "Beslisregels")
    private BasisRegel basisRegel;

    @OneToMany(mappedBy = "medicine")
    @JsonIgnore
    Set<PatientMedicine> patientMedicines;

    public Medicine(long id, String medicineName, String atc, String description) {
        setId(id);
        setMedicineName(medicineName);
        setATC_Code(atc);
        setDescription(description);
    }
}
