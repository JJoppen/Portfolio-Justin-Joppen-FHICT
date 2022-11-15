package com.fhict.sociable.Model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.*;
import org.hibernate.annotations.Cascade;

import java.util.*;
import javax.persistence.*;
import java.io.Serializable;


@AllArgsConstructor
@NoArgsConstructor
@Data
@Entity
@Table(name="app_user")
public class User implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long userId;

    @Column(name = "User_Name",nullable = false,unique = true)
    private String username;

    @Column(name = "Password")
    private String password;

    @Column(name = "Email",nullable = false,unique = true)
    private String email;

    @ElementCollection(fetch = FetchType.EAGER)
    List<Role> roles = new ArrayList<>();

    @OneToMany(mappedBy = "post_user_id")
    @JsonIgnore
    private List<Post> posts;

    @OneToMany(mappedBy = "comments_user_id")
    @JsonIgnore
    private List<Comment> comments;

}
