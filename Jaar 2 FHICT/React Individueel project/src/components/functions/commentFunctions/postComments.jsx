import axios from "axios";
import React, { useState, useEffect } from "react"
import CreateComment from "./CreateComment";

const PostComment = (postId) => {
    const [comments, setComments] = useState([])

    useEffect(async () => {
        
        let result = await axios.get("http://localhost:8080/api/v1/comments?postID="+postId.postId)

        setComments(result.data)
    }, []);

    return (
        <div className="d-flex justify-content-center row">
            <div>
                {
                    comments.map(
                        comment =>
                            <div key={comment.commentId}>
                                <h4>username: {comment.comments_user_id.username}</h4>
                                <p>{comment.comment}</p>
                            </div>
                    )
                }
            </div>
            <div className="w-50">
                <CreateComment postId={postId}/>
            </div>
        </div>
    )

}
export default PostComment