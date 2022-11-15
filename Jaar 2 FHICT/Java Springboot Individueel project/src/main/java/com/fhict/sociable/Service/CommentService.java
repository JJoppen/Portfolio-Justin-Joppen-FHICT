package com.fhict.sociable.Service;

import com.fhict.sociable.Exceptions.ResourceNotFoundException;
import com.fhict.sociable.Model.Comment;
import com.fhict.sociable.Repository.CommentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;
@Service
public class CommentService {

    @Autowired
    CommentRepository commentRepository;

    public List<Comment> getAllComments(long postId){
        return commentRepository.findCommentsByPostId(postId);
    }
    public Comment saveComment(Comment comment){
        return commentRepository.save(comment);
    }

    public ResponseEntity<Comment> updateComment(Comment commentDetails)throws ResourceNotFoundException{
        Comment comment = commentRepository.findById(commentDetails.getId()).orElseThrow(()-> new ResourceNotFoundException("No comment found by id:"+commentDetails.getId()));

        comment.setComment(commentDetails.getComment());
        comment.setDislikes(comment.getDislikes());
        comment.setLikes(commentDetails.getLikes());

        final Comment UpdatedComment =commentRepository.save(comment);
        return ResponseEntity.ok(UpdatedComment);
    }
    public boolean deleteComment(Comment commentDetails) throws ResourceNotFoundException{
        Comment comment = commentRepository.findById(commentDetails.getId()).orElseThrow(() -> new ResourceNotFoundException("No comment found by id:" + commentDetails.getId()));

        commentRepository.deleteById(comment.getId());
        return true;
    }
}
