import axios from "axios"
import { useEffect, useState } from "react"




const url = "http://localhost:8080/api/v1/"
export default function Forum(forumdata) {
    const [forum,setForum] = useState([])

    useEffect(()=>{
        setForum(forumdata.forumdata)
        console.log(forum)


    },[forumdata.forumdata])




    return (
        <div>
            <div className="d-flex flex-row bd-highlight mb-3">
                {/* forum logo div */}
                <div>
                    <a>
                        {/* forum icon */}
                        <img className="rounded-circle" style={{ backgroundColor: "#FFCD00", width: 45, height: 45 }} src={forum.forumPicture}></img>
                    </a>

                </div>
                {/* hier komt forum naam */}

                <div className="d-flex flex-column flex-wrap ml-2">
                    <a>r/{forum.forumName}</a>
                </div>
            </div>
        </div>
    )
}