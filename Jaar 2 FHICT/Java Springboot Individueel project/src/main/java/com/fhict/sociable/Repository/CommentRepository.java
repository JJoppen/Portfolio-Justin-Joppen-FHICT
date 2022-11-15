package com.fhict.sociable.Repository;

import com.fhict.sociable.Model.Comment;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface CommentRepository extends JpaRepository<Comment,Long> {

    @Query(value = "SELECT * FROM Comment WHERE post_id =:postID",nativeQuery = true)
    public List<Comment> findCommentsByPostId(long postID);
}
