package com.fhict.sociable.Model;


import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.*;

import javax.persistence.*;

@Setter
@Getter
@AllArgsConstructor
@NoArgsConstructor

@Entity
@Table
public class Comment {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    @Column(name = "comment")
    private String comment;
    @Column(name = "likes" )
    private int likes;
    @Column(name = "dislikes")
    private int dislikes;


    @ManyToOne(optional = true)
    @JoinColumn(name = "post_id",nullable = false)
    @JsonIgnore
    private Post post_comments_id;

    @ManyToOne(optional = true)
    @JoinColumn(name = "user_id",nullable = false)
    private User comments_user_id;
}
