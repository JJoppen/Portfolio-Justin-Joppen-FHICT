package com.example.medicijnbewaking.UnitTests;

import com.example.medicijnbewaking.DTO.PatientMedicineDTO;
import com.example.medicijnbewaking.DTO.PatientMedicineDTOConverter;
import com.example.medicijnbewaking.Enums.DurationType;
import com.example.medicijnbewaking.Enums.MedicationType;
import com.example.medicijnbewaking.controller.PatientController;
import com.example.medicijnbewaking.model.Medicine;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.model.PatientMedicine;
import com.example.medicijnbewaking.repository.MedicineRepository;
import com.example.medicijnbewaking.repository.PatientMedicineRepository;
import com.example.medicijnbewaking.repository.PatientRepository;
import com.example.medicijnbewaking.services.MedicineService;
import com.example.medicijnbewaking.services.PatientMedicineService;
import com.example.medicijnbewaking.services.PatientService;
import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.Data;
import org.assertj.core.api.Assertions;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.test.context.junit.jupiter.SpringExtension;
import org.springframework.test.web.servlet.MockMvc;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@ExtendWith(SpringExtension.class)
@WebMvcTest(PatientController.class)
public class PatientMedicineServiceUnitTests {
    @Autowired
    MockMvc mockMvc;

    @Autowired
    ObjectMapper mapper;

    @MockBean(classes = {MedicineService.class})
    MedicineService medicineService;
    @MockBean(classes = {PatientService.class})
    PatientService patientService;
    @MockBean(classes = {PatientRepository.class})
    PatientRepository patientRepository;
    @MockBean(classes = {MedicineRepository.class})
    MedicineRepository medicineRepository;
    @MockBean(classes = {PatientMedicineService.class})
    PatientMedicineService patientMedicineService;
    @MockBean(classes = {PatientMedicineRepository.class})
    PatientMedicineRepository patientMedicineRepository;

    PatientMedicineDTOConverter patientMedicineDTOConverter = new PatientMedicineDTOConverter();



    @Test
    public void saveListOfPatientMedicine()throws Exception{
        Patient patient = new Patient(2L,"test","test",LocalDate.MAX,123,85,"test@test.test","test","man","10",LocalDate.MAX,null);
        Medicine medicine = new Medicine(3L,"TestMedicine","TestATC","TestDesc");
        PatientMedicine patientMedicine = new PatientMedicine(1l,patient,medicine,1,1,1, DurationType.days, MedicationType.implanted);
        PatientMedicineDTO dto = patientMedicineDTOConverter.objectToDto(patientMedicine);
        Mockito.when(patientMedicineRepository.save(patientMedicine)).thenReturn(patientMedicine);
        Mockito.when(patientService.getPatientById(dto.Id)).thenReturn(patient);
        Mockito.when(patientRepository.getPatientById(dto.userId)).thenReturn(patient);
        Mockito.when(medicineRepository.getMedicineById(dto.MedicineId)).thenReturn(medicine);


        var testresult =patientMedicineService.savePatientMedicine(dto);
        Assertions.assertThat(testresult == true);
    }

    @Test
    public void getListofPatientMedicine()throws Exception{
        //Arrange
        Patient patient = new Patient(2L,"test","test",LocalDate.MAX,123,85,"test@test.test","test","man","10",LocalDate.MAX,null);
        // 2L,"test","test", LocalDate.MAX,123,85,"test@test.test","test","man"
        Medicine medicine = new Medicine(3L,"TestMedicine","TestATC","TestDesc");
        PatientMedicine patientMedicine = new PatientMedicine(1l,patient,medicine,1,1,1, DurationType.days, MedicationType.implanted);
        List<PatientMedicine>patientMedicines = new ArrayList<>();
        patientMedicines.add(patientMedicine);
        List<PatientMedicineDTO> dtos = new ArrayList<>();
        PatientMedicineDTO dto = patientMedicineDTOConverter.objectToDto(patientMedicine);
        dtos.add(dto);

        //setup mock
        Mockito.when(patientMedicineRepository.findAllMedicineByPatient_Id(patient.getId())).thenReturn(patientMedicines);
        //Execute
        var testResult = patientMedicineService.getAllMedicineByPatientId(patient.getId());
        //Assert
        Assertions.assertThat(!testResult.isEmpty());
        Assertions.assertThat(testResult.contains(dto));

    }
}
