package com.fhict.sociable.DTO;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import org.springframework.stereotype.Service;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Service
public class PostDTO {
    private long id;
    private String title;
    private String postLink;

    private Integer likes;
    private Integer dislikes;
    private long userId;
    private long forumId;
}
