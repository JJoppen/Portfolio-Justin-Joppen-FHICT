package com.example.medicijnbewaking;

import static org.assertj.core.api.Assertions.*;
import com.example.medicijnbewaking.controller.PatientController;
import com.example.medicijnbewaking.model.Patient;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.time.LocalDate;
import java.util.List;

@SpringBootTest
class MedicijnBewakingApplicationTests {

    @Autowired
    private PatientController patientController;

    @Test
    void contextLoads() {
        assertThat(patientController).isNotNull();
    }
}
