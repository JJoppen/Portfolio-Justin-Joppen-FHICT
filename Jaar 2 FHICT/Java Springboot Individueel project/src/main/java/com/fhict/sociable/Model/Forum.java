package com.fhict.sociable.Model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.*;

import javax.persistence.*;
import java.util.List;


@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table
public class Forum {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    @Column(name = "Forum_Name")
    private String forumName;

    @Column(name = "Follower_Amount")
    private int followerAmount;

    @Column(name = "Forum_Picture")
    private String forumPicture;

    @OneToMany(mappedBy = "forum_post_id")
    @JsonIgnore
    private List<Post> posts;
}
