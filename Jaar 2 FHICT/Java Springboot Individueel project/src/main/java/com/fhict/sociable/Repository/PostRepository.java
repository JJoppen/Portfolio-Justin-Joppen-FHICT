package com.fhict.sociable.Repository;

import com.fhict.sociable.Model.Forum;
import com.fhict.sociable.Model.Post;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface PostRepository extends JpaRepository<Post,Long> {
    @Query(value = "SELECT id FROM Post WHERE forum_id =:forumId",nativeQuery = true)
    public List<Long> findPostsByForumId(long forumId);
}
