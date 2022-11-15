package com.example.medicijnbewaking.ViewModel;

import com.example.medicijnbewaking.model.Patient;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class UserViewModel {
    private long id;

    private String Firstname;

    private String LastName;

    private LocalDate DateOfBirth;

    private int length;

    private int heartrate;

    private String email;

    private String password;

    private String gender;

    public UserViewModel(Patient patient) {
        setId(patient.getId());
        setFirstname(patient.getFirstname());
        setLastName(patient.getLastName());
        setDateOfBirth(patient.getDateofbirth());
        setLength(patient.getLength());
        setHeartrate(patient.getHeartrate());
        setEmail(patient.getEmail());
        setPassword(patient.getPassword());
        setGender(patient.getGender());
    }
}