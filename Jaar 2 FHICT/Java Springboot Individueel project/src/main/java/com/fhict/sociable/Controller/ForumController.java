package com.fhict.sociable.Controller;

import com.fhict.sociable.Exceptions.ResourceNotFoundException;
import com.fhict.sociable.Model.Forum;
import com.fhict.sociable.Repository.ForumRepository;
import com.fhict.sociable.Service.ForumService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import javax.validation.Valid;


import java.util.List;
import java.util.Optional;

@CrossOrigin(origins = "http://localhost:3000")
@RestController
@RequestMapping("/api/v1/")
public class ForumController {
    @Autowired
    ForumRepository forumRepository;

    @Autowired
    ForumService forumService;

    @GetMapping("/forums")
    public List<Forum> getAllForums(){
        return forumService.getAllForums();
    }

    @GetMapping("/forum")
    public List<Forum> getForumByName(@RequestParam String ForumName){
       return forumService.getForumByName(ForumName);
    }
    @GetMapping("/forumId")
    public Optional<Forum> getForumById(@RequestParam Long id){
        return forumService.getForumById(id);
    }

    @PostMapping("/forum")
    public Forum saveForum(@RequestBody Forum forum){
        return saveForum(forum);
    }

    @PutMapping("/forum")
    public ResponseEntity<Forum> updateForum(@Valid @RequestBody Forum forumDetails) throws ResourceNotFoundException{
        return forumService.updateForum(forumDetails);
    }
    @DeleteMapping("/forum")
    public boolean deleteForum(@RequestParam long forumID)throws ResourceNotFoundException{
        return forumService.deleteForum(forumID);
    }
}
