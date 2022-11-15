import axios from "axios";
import React, { useState, useEffect } from "react";
import { useParams,useNavigate } from "react-router-dom";


const url = "http://localhost:8080/api/v1/"


export default function CreatePost() {
let param = useParams();
let navigate = useNavigate();
const [title,setTitle]=useState('');
const [picture,setPicture]=useState('')
const [forum,setForum]=useState('')

useEffect(()=>{
    setForum(param.ID)

},[param.ID])




const handleSubmit = async (e)=>{
    e.preventDefault();

    console.log("submit")
    let post={title: title, postLink:picture, forumId: forum,userId:1}

    try{
        const result = axios.post(url + "post",post)
        console.log(result + " result")
        navigate("/forumwithPost/:"+forum)

    }catch(err){

    }

}


    return (
        <div>
            <form onSubmit={handleSubmit}> 
                <label htmlFor="title">
                    title:
                </label>
                <input
                    type='text'
                    id="title"
                    required
                    onChange={(e)=>setTitle(e.target.value)}
                />
                <label htmlFor="picture">
                    Input picture link:
                </label>
                <input
                type='text'
                id='link'
                required
                onChange={(e)=>setPicture(e.target.value)}
                />
                <button onClick={handleSubmit}>
                    submit.
                </button>
            </form>
        </div>
    )

}