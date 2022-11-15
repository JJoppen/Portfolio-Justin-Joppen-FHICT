package com.fhict.sociable.UnitTests;

import com.fhict.sociable.Controller.UserController;
import com.fhict.sociable.Repository.UserRepository;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.boot.test.context.SpringBootTest;

@ExtendWith(MockitoExtension.class)
@SpringBootTest
public class UserUnitTests {

    UserController userController;

    @Mock UserRepository userRepository;


}
