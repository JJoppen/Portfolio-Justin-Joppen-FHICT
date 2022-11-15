package com.fhict.sociable.Service;

import com.fhict.sociable.Exceptions.CustomException;
import com.fhict.sociable.Model.Role;
import com.fhict.sociable.Model.User;
import com.fhict.sociable.Repository.UserRepository;
import com.fhict.sociable.Security.JwtTokenProvider;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.AuthenticationException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import javax.servlet.http.HttpServletRequest;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
@RequiredArgsConstructor
public class UserService {

    private final UserRepository userRepository;
    private final PasswordEncoder passwordEncoder;
    private final JwtTokenProvider jwtTokenProvider;
    private final AuthenticationManager authenticationManager;

    public String signin(String username, String password){
        try {
            authenticationManager.authenticate(new UsernamePasswordAuthenticationToken(username,password));
            List<Role> userRolesBeforeChange = userRepository.findByUsername(username).getRoles();

            return jwtTokenProvider.createToken(username,userRolesBeforeChange);
        }catch (AuthenticationException e){
            throw new CustomException("Invalid Username/Password supplied "+ e.getMessage(), HttpStatus.UNPROCESSABLE_ENTITY);
        }
    }
    public String signup(User user){
        if(!userRepository.existsByUsername(user.getUsername()) && !userRepository.existsByEmail(user.getEmail())){
            user.setPassword(passwordEncoder.encode(user.getPassword()));
            userRepository.save(user);
            return jwtTokenProvider.createToken(user.getUsername(),(List<Role>) user.getRoles());
        }else {
            throw new CustomException("Username or email is already in use",HttpStatus.UNPROCESSABLE_ENTITY);
        }
    }
    public void delete(String username){
        userRepository.deleteByUsername(username);
    }

    public User search(String username){
        User user = userRepository.findByUsername(username);
        if(user == null){
            throw new CustomException("The user does not exist", HttpStatus.NOT_FOUND);
        }
        return user;
    }
    public User whoami(HttpServletRequest req){
        return userRepository.findByUsername(jwtTokenProvider.getUsername(jwtTokenProvider.resolveToken(req)));
    }
    public String refresh(String username){
        return jwtTokenProvider.createToken(username,(List<Role>) userRepository.findByUsername(username).getRoles());
    }

}
