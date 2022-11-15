package com.example.medicijnbewaking.services;

import com.example.medicijnbewaking.ViewModel.UserViewModel;
import com.example.medicijnbewaking.exceptions.ResourceNotFoundException;
import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.model.PatientMedicine;
import com.example.medicijnbewaking.repository.PatientMedicineRepository;
import com.example.medicijnbewaking.repository.PatientRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.List;
import java.util.Set;


@Service
public class PatientService implements IPatientService{
    @Autowired
    private PatientRepository patientRepository;

    @Autowired
    private PatientMedicineRepository patientMedicineRepository;

    @Override
    public Patient getPatientByIdWithoutMeds(long id) {

        return patientRepository.getPatientById(id);
    }



    public List<Patient> getAllPatients(){
        return patientRepository.findAll();
    }

    public Patient getPatientById(long id){
        return patientRepository.getPatientById(id);
    }

    public Patient savePatient(Patient patient){
        return patientRepository.save(patient);
    }

    public boolean deletePatientById(long id){
        patientRepository.deleteById(id);
        return true;
    }

    public ResponseEntity<Patient> UpdateUser(Patient patientdetails) throws ResourceNotFoundException{

        Patient patient =patientRepository.findById(patientdetails.getId()).orElseThrow(() -> new ResourceNotFoundException("No patient found by this account:"+ patientdetails.getId()));

        patient.setPassword(patientdetails.getPassword());
        patient.setLength(patientdetails.getLength());
        patient.setHeartrate(patientdetails.getHeartrate());
        patient.setGender(patientdetails.getGender());
        patient.setFirstname(patientdetails.getFirstname());
        patient.setLastName(patientdetails.getLastName());
        patient.setClcr(patientdetails.getClcr());
        patient.setLastclcrtest(patientdetails.getLastclcrtest());

        final Patient updatedPatient = patientRepository.save(patient);
        return ResponseEntity.ok(updatedPatient);
    }


    public long login(String email) {
        try{
            return patientRepository.findPatientByEmailEquals(email).getId();

        }catch (Exception exception){
            return HttpStatus.NOT_FOUND.value();

        }
    }
}
