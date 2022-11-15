import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import PostComment from "../commentFunctions/postComments"
import ReadPost from "./posts"

const PostWithComment=()=>{
let param = useParams();
const [postId,setPostId] = useState(param.ID)

    return(
        <div className="d-flex justify-content-center row">
            {console.log(postId+" in postwcomment")}
            <ReadPost postId={postId}/>
            <PostComment postId={postId}/>
        </div>
    )

}

export default PostWithComment