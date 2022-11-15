package com.example.medicijnbewaking.exceptions;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.NOT_FOUND)
public class ResourceNotFoundException extends RuntimeException{

    private static final long serialVersionsUID = 1L;

    public ResourceNotFoundException(String Message){
        super(Message);
    }
}
