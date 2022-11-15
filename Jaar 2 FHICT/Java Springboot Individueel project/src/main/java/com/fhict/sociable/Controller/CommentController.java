package com.fhict.sociable.Controller;

import com.fhict.sociable.Exceptions.ResourceNotFoundException;
import com.fhict.sociable.Model.Comment;
import com.fhict.sociable.Repository.CommentRepository;
import javax.validation.Valid;

import com.fhict.sociable.Service.CommentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@CrossOrigin(origins = "http://localhost:3000/")
@RestController
@RequestMapping("/api/v1/")
public class CommentController {


    @Autowired
    CommentService commentService;
    @GetMapping("/comments")
    public List<Comment> GetAllComments(@RequestParam long postID){
        return commentService.getAllComments(postID);
    }

    @PostMapping("/comment")
    public Comment SaveComment(@RequestBody Comment comment){
        return commentService.saveComment(comment);
    }

    @PutMapping("/comment")
    public ResponseEntity<Comment>UpdateComment(@Valid @RequestBody Comment commentDetails) throws ResourceNotFoundException {
        return commentService.updateComment(commentDetails);
    }
    @DeleteMapping("/comment")
    public boolean DeleteComment(@Valid @RequestBody Comment commentDetails)throws ResourceNotFoundException {
        return commentService.deleteComment(commentDetails);
    }
}
