package com.fhict.sociable.Controller;

import com.fhict.sociable.Exceptions.ResourceNotFoundException;
import com.fhict.sociable.Model.User;
import com.fhict.sociable.Repository.UserRepository;
import javax.validation.Valid;

import com.fhict.sociable.Service.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@CrossOrigin(origins = "http://localhost:3000")
@RestController
@RequestMapping("/api/v1/" )
@RequiredArgsConstructor
public class UserController {

    private final UserRepository userRepository;
    private final UserService userService;




    @GetMapping("/users")
    @PreAuthorize("hasRole('ROLE_SUPPORT')")
    public List<User> GetAllUsers(){
        return userRepository.findAll();
    }
    @GetMapping("/user")
    public Optional<User> GetUserByID(@RequestParam long userID){
     return userRepository.findById(userID);
    }

    @PostMapping("/user")
    public User SaveUser(@RequestBody User user){
        if(user.getUsername().isEmpty() || user.getEmail().isEmpty() || user.getPassword().isEmpty())
        {
            return user;
        }
        return userRepository.save(user);
    }

    @PostMapping("/users/signin")
    public String login(
            @RequestParam String username,
            @RequestParam String password
    ){
        return userService.signin(username,password);
    }
    @PostMapping("/users/signup")
    public String signup(@RequestBody User user){
        return userService.signup(user);
    }

    @PutMapping("/user")
    public ResponseEntity<User> UpdateUser(@Valid @RequestBody User userDetails) throws ResourceNotFoundException{
        User user =userRepository.findById(userDetails.getUserId()).orElseThrow(() -> new ResourceNotFoundException("User not found for this ID:" +userDetails.getUserId()));

        user.setUsername(userDetails.getUsername());
        user.setPassword(userDetails.getPassword());
        user.setEmail(userDetails.getEmail());
        final User updatedUser = userRepository.save(user);
        return ResponseEntity.ok(updatedUser);
    }
    @DeleteMapping("/user")
    public boolean DeleteUser(@RequestParam long UserID)throws ResourceNotFoundException{
        User user = userRepository.findById(UserID).orElseThrow(()-> new ResourceNotFoundException("No user find by this ID:"+UserID));
        userRepository.deleteById(UserID);

        return true;
    }

}
