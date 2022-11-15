package com.fhict.sociable.Model;

import lombok.*;
import org.springframework.security.core.GrantedAuthority;

import javax.persistence.*;


public enum Role implements GrantedAuthority {
    ROLE_ADMIN, ROLE_CLIENT,ROLE_SUPPORT;

    public String getAuthority() {
        return name();
    }

}

