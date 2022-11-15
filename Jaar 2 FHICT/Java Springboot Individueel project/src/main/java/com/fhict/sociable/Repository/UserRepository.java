package com.fhict.sociable.Repository;

import com.fhict.sociable.Model.User;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserRepository extends JpaRepository<User,Long> {
    User findByUsername(String userName);
    boolean existsByUsername(String userName);
    boolean existsByEmail(String Email);
    void deleteByUsername(String userName);
    User getUserByUserId(long id);
}
