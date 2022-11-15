package com.fhict.sociable.Exceptions;


import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;

@RequiredArgsConstructor
public class CustomException extends RuntimeException {
    private static long serialVersionUID=1L;

    private final String message;
    private final HttpStatus httpStatus;

    @Override
    public String getMessage(){
        return message;
    }
    public HttpStatus getHttpStatus(){
        return httpStatus;
    }


}
