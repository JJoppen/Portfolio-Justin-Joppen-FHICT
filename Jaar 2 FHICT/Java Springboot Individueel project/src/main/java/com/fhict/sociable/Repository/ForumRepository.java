package com.fhict.sociable.Repository;

import com.fhict.sociable.Model.Forum;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;


public interface ForumRepository extends JpaRepository<Forum,Long> {
    public List<Forum> findForumByForumNameContaining(String forumName);
    Forum getForumById(long Id);
}
