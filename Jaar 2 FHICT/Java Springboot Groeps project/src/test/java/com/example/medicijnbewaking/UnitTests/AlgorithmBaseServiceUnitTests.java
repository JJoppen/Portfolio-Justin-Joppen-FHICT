package com.example.medicijnbewaking.UnitTests;

import com.example.medicijnbewaking.Enums.DurationType;
import com.example.medicijnbewaking.controller.PatientController;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.model.PatientMedicine;
import com.example.medicijnbewaking.services.AlgorithmServices.AlgorithmBaseService;
import com.example.medicijnbewaking.services.PatientService;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.jupiter.api.Assertions;
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

@ExtendWith(SpringExtension.class)
@WebMvcTest(PatientController.class)
public class AlgorithmBaseServiceUnitTests {

    @MockBean(classes = {PatientService.class})
    PatientService patientService;
    @MockBean(classes = {AlgorithmBaseService.class})
    AlgorithmBaseService algorithmBaseService;

    @Test
    public void timeLongerOrEqualPositiveFlowTest(){
        //arrange
        PatientMedicine patientMedicine = new PatientMedicine();
        patientMedicine.setTime(12);
        patientMedicine.setTimeType(DurationType.months);
        int time = 12;
        DurationType type = DurationType.days;

        Mockito.when(algorithmBaseService.isTimeDurationGreaterOrEqualToX(patientMedicine,time,type)).thenCallRealMethod();
        //act
        boolean result = algorithmBaseService.isTimeDurationGreaterOrEqualToX(patientMedicine,time,type);
        //assert
        Assertions.assertTrue(result);
    }

    @Test
    public void  timeLongerOrEqualNegativeFlowTest(){
        //arrange
        PatientMedicine patientMedicine = new PatientMedicine();
        patientMedicine.setTime(12);
        patientMedicine.setTimeType(DurationType.days);
        int time = 12;
        DurationType type = DurationType.months;

        Mockito.when(algorithmBaseService.isTimeDurationGreaterOrEqualToX(patientMedicine,time,type)).thenCallRealMethod();
        //act
        boolean result = algorithmBaseService.isTimeDurationGreaterOrEqualToX(patientMedicine,time,type);
        //assert
        Assertions.assertFalse(result);
    }

    @Test
    public void isTimeSmallerThanPositiveFlowTest(){
        //arrange
        PatientMedicine patientMedicine = new PatientMedicine();
        patientMedicine.setTime(11);
        patientMedicine.setTimeType(DurationType.days);
        int time = 12;
        DurationType type = DurationType.days;

        Mockito.when(algorithmBaseService.isTimeDurationSmallerThanX(patientMedicine,time,type)).thenCallRealMethod();
        //act
        boolean result = algorithmBaseService.isTimeDurationSmallerThanX(patientMedicine,time,type);
        //assert
        Assertions.assertTrue(result);
    }
    @Test
    public void isTimeSmallerThanNegativeFlowTest(){
        //arrange
        PatientMedicine patientMedicine = new PatientMedicine();
        patientMedicine.setTime(13);
        patientMedicine.setTimeType(DurationType.days);
        int time = 12;
        DurationType type = DurationType.days;

        Mockito.when(algorithmBaseService.isTimeDurationSmallerThanX(patientMedicine,time,type)).thenCallRealMethod();

        //act
        boolean result = algorithmBaseService.isTimeDurationSmallerThanX(patientMedicine,time,type);
        //assert
        Assertions.assertFalse(result);
    }

    @Test
    public void isDoseGreaterOrEqualPositiveFlowTest(){
        //arrange
        PatientMedicine patientMedicine = new PatientMedicine();
        patientMedicine.setDose(10);
        int dose = 10;
        Mockito.when(algorithmBaseService.isDoseGreaterOrEqualToX(patientMedicine,dose)).thenCallRealMethod();
        //act
        boolean result = algorithmBaseService.isDoseGreaterOrEqualToX(patientMedicine,dose);
        //assert
        Assertions.assertTrue(result);
    }

    @Test
    public void isDoseGreaterOrEqualNegativeFlowTest(){
        //arrange
        PatientMedicine patientMedicine = new PatientMedicine();
        patientMedicine.setDose(10);
        int dose = 11;
        Mockito.when(algorithmBaseService.isDoseGreaterOrEqualToX(patientMedicine,dose)).thenCallRealMethod();
        //act
        boolean result = algorithmBaseService.isDoseGreaterOrEqualToX(patientMedicine,dose);
        //assert
        Assertions.assertFalse(result);
    }

    @Test
    public void isDoseSmallerThanPositiveFlowTest(){
        //arrange
        PatientMedicine patientMedicine = new PatientMedicine();
        patientMedicine.setDose(10);
        int dose = 11;
        Mockito.when(algorithmBaseService.isDoseSmallerThanX(patientMedicine,dose)).thenCallRealMethod();
        //act
        boolean result = algorithmBaseService.isDoseSmallerThanX(patientMedicine,dose);
        //assert
        Assertions.assertTrue(result);
    }
    @Test
    public void isDoseSmallerThanNegativeFlowTest(){
        //arrange
        PatientMedicine patientMedicine = new PatientMedicine();
        patientMedicine.setDose(10);
        int dose = 9;
        Mockito.when(algorithmBaseService.isDoseSmallerThanX(patientMedicine,dose)).thenCallRealMethod();
        //act
        boolean result = algorithmBaseService.isDoseSmallerThanX(patientMedicine,dose);
        //assert
        Assertions.assertFalse(result);
    }

    @Test
    public void isPatientOlderThanPositiveFlow(){
        //arrange
        Patient patient = new Patient();
        patient.setDateofbirth(LocalDate.MIN);
        Mockito.when(algorithmBaseService.isPatientOlderThanX(patient, 10)).thenCallRealMethod();

        //act
        boolean result = algorithmBaseService.isPatientOlderThanX(patient,10);
        //assert
        Assertions.assertTrue(result);
    }

    @Test
    public void isPatientOlderThanNegativeFlow(){
        //arrange
        Patient patient = new Patient();
        patient.setDateofbirth(LocalDate.MAX);
        Mockito.when(algorithmBaseService.isPatientOlderThanX(patient, 10)).thenCallRealMethod();

        //act
        boolean result = algorithmBaseService.isPatientOlderThanX(patient,10);
        //assert
        Assertions.assertFalse(result);
    }


}
