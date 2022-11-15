package com.fhict.sociable.Model;

import com.fasterxml.jackson.annotation.JsonManagedReference;
import lombok.*;
import org.springframework.lang.Nullable;

import javax.persistence.*;
import javax.validation.constraints.Null;

import java.util.List;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table
public class    Post {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    @Column(name = "post_title")
    private String postTitle;

    @Column(name = "post_link")
    private String postLink;

    @Nullable
    @Column(name = "Likes")
    private Integer likes;

    @Nullable
    @Column(name = "Dislikes")
    private Integer dislikes;

    @OneToMany(mappedBy = "post_comments_id")
    @JsonManagedReference
    private List<Comment> comments;

    @ManyToOne(optional = true)
    @JoinColumn(name = "forum_id")
    @JsonManagedReference
    private Forum forum_post_id;

    @ManyToOne(optional = true)
    @JoinColumn(name = "user_id")
    @JsonManagedReference
    private User post_user_id;
}
