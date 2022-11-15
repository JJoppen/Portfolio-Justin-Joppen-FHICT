package com.fhict.sociable.Security;

import com.fhict.sociable.Repository.UserRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class MyUserDetails implements UserDetailsService {

    private final UserRepository userRepository;

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        final com.fhict.sociable.Model.User user = userRepository.findByUsername(username);
        if(user == null){
            throw new UsernameNotFoundException("User "+username +" Not found");
        }
        return org.springframework.security.core.userdetails.User//
                .withUsername(username)//
                .password(user.getPassword())//
                .authorities( user.getRoles())//
                .accountExpired(false)//
                .credentialsExpired(false)
                .disabled(false)//
                .build();
    }
}
