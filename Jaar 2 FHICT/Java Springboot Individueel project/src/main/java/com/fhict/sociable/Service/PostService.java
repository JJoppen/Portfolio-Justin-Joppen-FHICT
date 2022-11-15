package com.fhict.sociable.Service;

import com.fhict.sociable.DTO.PostDTO;
import com.fhict.sociable.DTO.PostDTOConverter;
import com.fhict.sociable.Exceptions.ResourceNotFoundException;
import com.fhict.sociable.Model.Forum;
import com.fhict.sociable.Model.Post;
import com.fhict.sociable.Repository.PostRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class PostService {

    @Autowired
    PostRepository postRepository;

    @Autowired
    PostDTOConverter converter;
    public List<Post> getAllPosts(){

        return postRepository.findAll();
    }
    public List<Long> getPostByForum(long forumId){
        return postRepository.findPostsByForumId(forumId);
    };

    public Optional<Post> getPost(long postId){
        return postRepository.findById(postId);
    }

    public Post savePost(PostDTO post){
        return postRepository.save(converter.DtoToObject(post));
    }

    public ResponseEntity<Post> updatePost(Post postdetails)throws ResourceNotFoundException{
        Post post = postRepository.findById(postdetails.getId()).orElseThrow(() -> new ResourceNotFoundException("Post not found for this id :: " + postdetails.getId()));

        post.setPostTitle(postdetails.getPostTitle());
        post.setDislikes(post.getDislikes());
        post.setLikes(post.getLikes());
        post.setPostLink(post.getPostLink());

        final Post Updatedpost =postRepository.save(post);

        return ResponseEntity.ok(Updatedpost);
    }

    public boolean deletePost(long PostID)throws ResourceNotFoundException{
        Post post = postRepository.findById(PostID).orElseThrow(() -> new ResourceNotFoundException("Post not found for this ID :: "+ PostID));

        postRepository.delete(post);
        return true;
    }
}
