import axios from "axios"
import React, { useState, useEffect } from "react"
import {  useParams,useNavigate } from "react-router-dom"
import MultiplePosts from "../postFunctions/multiplePosts";
import Forum from './Forum'

const URL = "http://localhost:8080/api/v1/"

export default function ForumWithPosts() {
    let param = useParams();
    const [posts, setPosts] = useState([]);
    const [forum,setForum] = useState([]);
    let navigate = useNavigate();

    const [forumId, setForumId] = useState(param.ID);




    
    useEffect(()=>{
        const getApi = async () =>{
            let forumdata = await axios.get(URL+"forumId?id="+forumId);
            console.log(forumdata.data)
            setForum(forumdata?.data)

        }
        getApi().catch(console.error)
        
    },[])
    useEffect(()=>{
        axios.get(URL + "post/search?forumId="+forumId).then((response)=>{
            let postdata = response.data;
            console.log(forumId+ "forumId")
            setPosts(postdata)
            console.log(posts+ "posts")
            console.table(forum)
            console.log(forum.id)
        })

    },[forum])


    return (
        
        <div>
            <div className="container mt-4 mb-5">
                <div className="d-flex justify-content-center">
                    <div className="col-md-8">
                        <div className="bg-white border mt-2">
                            <Forum forumdata={forum} />
                            <button onClick={()=>navigate("/createPost/:"+forumId)}>
                                Create post
                            </button>
                        </div>
                    </div>
                </div>
                <MultiplePosts postIdsOnSearch={posts} />
            </div>
        </div>
    )
}