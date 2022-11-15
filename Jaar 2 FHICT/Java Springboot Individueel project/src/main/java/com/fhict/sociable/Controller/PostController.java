package com.fhict.sociable.Controller;

import com.fhict.sociable.DTO.PostDTO;
import com.fhict.sociable.Exceptions.ResourceNotFoundException;
import com.fhict.sociable.Model.Forum;
import com.fhict.sociable.Model.Post;
import com.fhict.sociable.Repository.PostRepository;
import javax.validation.Valid;

import com.fhict.sociable.Service.PostService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;
import org.springframework.http.ResponseEntity;

import java.awt.*;
import java.util.List;
import java.util.Optional;

@CrossOrigin(origins = "http://localhost:3000/")
@RestController
@RequestMapping("/api/v1/")
public class PostController {
    @Autowired
    PostRepository postRepository;

    @Autowired
    PostService postService;

    @GetMapping("/posts")
    public List<Post> GetAllPosts(){

        return postService.getAllPosts();
    }

    @GetMapping(value = "/post/search")
    public List<Long> getPostByForum(@RequestParam long forumId){
        return postService.getPostByForum(forumId);
    }

    @GetMapping("/post")
    public Optional<Post> getPost(@RequestParam long postId){
        return postService.getPost(postId);
    }

    @PostMapping(value = "/post")
    public Post SavePost(@RequestBody PostDTO post){
        return postService.savePost(post);
    }

    @PutMapping("/post")
    public ResponseEntity<Post> UpdatePost(@Valid @RequestBody Post postdetails) throws ResourceNotFoundException {
        return postService.updatePost(postdetails);
    }

    @DeleteMapping("/post")
    public boolean DeletePost(@RequestParam long PostID)throws ResourceNotFoundException{
        return  postService.deletePost(PostID);
    }
}
