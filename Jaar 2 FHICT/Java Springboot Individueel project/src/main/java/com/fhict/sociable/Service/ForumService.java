package com.fhict.sociable.Service;

import com.fhict.sociable.Exceptions.ResourceNotFoundException;
import com.fhict.sociable.Model.Forum;
import com.fhict.sociable.Repository.ForumRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ForumService {
    @Autowired
    ForumRepository forumRepository;

    public List<Forum> getAllForums(){
        return forumRepository.findAll();
    }

    public List<Forum> getForumByName(String ForumName){
        return forumRepository.findForumByForumNameContaining(ForumName);
    }

    public Optional<Forum> getForumById(Long id){
        return forumRepository.findById(id);
    }

    public Forum saveForum(Forum forum){
        return forumRepository.save(forum);
    }

    public ResponseEntity<Forum> updateForum(Forum forumDetails)throws ResourceNotFoundException {
        Forum forum = forumRepository.findById(forumDetails.getId()).orElseThrow(() -> new ResourceNotFoundException("No forum found for this ID:"+forumDetails.getId()));
        forum.setForumName(forumDetails.getForumName());
        forum.setFollowerAmount(forumDetails.getFollowerAmount());

        final Forum updatedForum = forumRepository.save(forum);
        return ResponseEntity.ok(updatedForum);
    }

    public boolean deleteForum(long forumID)throws ResourceNotFoundException{
        Forum forum =forumRepository.findById(forumID).orElseThrow(()-> new ResourceNotFoundException("No forum found for this ID:"+forumID));

        forumRepository.deleteById(forumID);
        return true;
    }
}
