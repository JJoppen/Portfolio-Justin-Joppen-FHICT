import axios from "axios";
import React, { useState, useRef, useEffect, useContext } from "react";
import { useNavigate, useParams } from "react-router-dom";

const URL = "http://localhost:8080/api/v1/"
export default function ReadPost(postId) {
    let param =useParams();
    const [post, setPost] = useState({});
    const navigate = useNavigate();
    const [id,setId] = useState(postId.postId)
    const [user, setUser] = useState([])
    const [forum,setForum] =useState([])


     useEffect(()=>{
        if(postId.postId === null){
            setPost(param.Id)
        }else{
            setId(postId.postId)

        }
     },[])

     useEffect(()=>{
        axios.get(URL+"post?postId="+id).then((response)=>{
            let userdata = response.data.post_user_id
            let forumdata = response.data.forum_post_id
            let postdata = response.data
            setPost(postdata)
            setUser(userdata)
            setForum(forumdata)

         })

     },[id])

    return (
        <div className="container mt-4 mb-5">
            <div className="d-flex justify-content-center row">
                <div className="col-md-8">
                    <div className="bg-white border mt-2">
                        <div >
                            <div className="feed p-2">
                                {/* Forum and user div */}
                                <div className="d-flex flex-row justify-content-between align-items-center p-2 border-bottom">
                                    {/* Forum Icon div */}
                                    <div>
                                    <div className="d-flex flex-row align-items-center feed-text px-2">
                                        {/* click image handle */}
                                        <a>
                                            {/* forum icon */}
                                            <img className="rounded-circle" style={{ backgroundColor: "#FFCD00", width: 45, height: 45 }} src={forum.forumPicture}></img>
                                        </a>

                                        {/* forum name and posting user and in real site awards and blank space */}
                                        <div className="d-flex flex-column flex-wrap ml-2">
                                            {/* Only forum name and posting user */}
                                            <div >
                                                {/* forum */}
                                                <div>
                                                    <a>{forum.forumName}</a>
                                                    <div></div>
                                                </div>

                                                {/* seperator */}
                                                <span>•</span>
                                                {/* who has posted it */}
                                                <span>Posted by:</span>
                                                {/* contains the posting user */}
                                                <div>
                                                    <div>
                                                        <a style={{ "color": "rgb(120,124,126)" }}>{user.username}</a>
                                                    </div>
                                                </div>
                                            </div>
                                            {/* ending topdiv */}
                                        </div>
                                    </div>
                                    </div>
                                    <div className="feed-icon px-2"><i className="fa fa-ellipsis-v text-black-50"></i></div>
                                </div>
                                {/* Title div */}
                                <div className="d-flex flex-row justify-content-between align-items-center p-2 border-bottom">
                                    <div className="d-flex flex-column flex-wrap ml-2">
                                        {/* Reference post to go to post page */}
                                        <h1 id="post-title" className="font-weight-bold" >{post.postTitle}</h1>
                                    </div>
                                </div>
                                {/* body div */}
                                <div>
                                    <div  className="feed-image p-2 px-3"><img className="img-fluid img-responsive" src={post.postLink}/></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
