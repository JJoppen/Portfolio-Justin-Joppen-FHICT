package com.fhict.sociable.DTO;

import com.fhict.sociable.Model.Forum;
import com.fhict.sociable.Model.Post;
import com.fhict.sociable.Model.User;
import com.fhict.sociable.Repository.ForumRepository;
import com.fhict.sociable.Repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
public class PostDTOConverter {
    @Autowired
    UserRepository userRepository;

    @Autowired
    ForumRepository forumRepository;

    public Post DtoToObject(PostDTO dto){

        Post post = new Post();
        post.setId(dto.getId());
        post.setPostLink(dto.getPostLink());
        post.setPostTitle(dto.getTitle());
        post.setLikes(dto.getLikes());
        post.setDislikes(dto.getDislikes());
        post.setPost_user_id(userRepository.getUserByUserId(dto.getUserId()));
        post.setForum_post_id(forumRepository.getForumById(dto.getForumId()));

        return post;
    }
}
