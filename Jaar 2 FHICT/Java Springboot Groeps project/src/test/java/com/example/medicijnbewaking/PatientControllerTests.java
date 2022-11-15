package com.example.medicijnbewaking;

import com.example.medicijnbewaking.controller.PatientController;
import com.example.medicijnbewaking.model.Patient;
import com.example.medicijnbewaking.services.PatientService;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.test.context.junit.jupiter.SpringExtension;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockHttpServletRequestBuilder;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;

import java.time.LocalDate;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@ExtendWith(SpringExtension.class)
@WebMvcTest(PatientController.class)
public class PatientControllerTests {
    @Autowired
    MockMvc mockMvc;

    @Autowired
    ObjectMapper mapper;

    @MockBean(classes = {PatientService.class})
    PatientService patientService;

    @Test
    public void savePatientTest() throws Exception{

        Patient patient = new Patient();


        Mockito.when(patientService.savePatient(patient)).thenReturn(patient);

        MockHttpServletRequestBuilder mockRequest = MockMvcRequestBuilders.post("/api/v1/Patient")
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.APPLICATION_JSON)
                .content(this.mapper.writeValueAsString(patient));

        mockMvc.perform(mockRequest)
                .andExpect(status().isOk());
    }
}
