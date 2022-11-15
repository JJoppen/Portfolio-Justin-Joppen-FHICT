import axios from "axios"
import React, { useRef, useState, useEffect } from "react"
import { useNavigate } from "react-router-dom";

export default function SearchForum() {
    let navigate = useNavigate();
    const [searchterm, setSearchterm] = useState('');
    const [results, setResults] = useState([]);
    const [success,setSuccess] = useState(false)
    const [errMsg, setErrMsg] = useState('');
    const errRef = useRef();


    const FORUM_URL = "http://localhost:8080/api/v1/forum"

    useEffect(() => {
        if(searchterm === ""){

        }else{
            const getData = async ()=>{
                const response = await axios.get(FORUM_URL + "?ForumName=" + searchterm)
                const resultData = response?.data
                setResults(resultData);
                console.table(response)

            }
            getData()

            setSuccess(true)
        }

    }, [searchterm])


    const getResults = async () => {
        try {
            const response = await axios.get(FORUM_URL + "?ForumName=" + searchterm)
            const resultData = response?.data
            setResults(resultData);
            setSuccess(true)
        } catch (err) {
            if (!err?.response) {
                setErrMsg("No server response");
                console.log(err);
            } else if (err.response?.status === 400) {
                setErrMsg("Missing something")
                console.log(err);

            } else if (err.response?.status === 401) {
                setErrMsg('Unauthorized');
                console.log(err);

            } else {
                setErrMsg('Login failed');
                console.log(err);

            }
            errRef.current.focus();
        }
    }




    return (
        <div>
            <div className="input-group">
                <input type="text"
                    className="form-control rounded"
                    placeholder="Search"
                    onChange={(e) => setSearchterm(e.target.value)} />
                {/* <button type="button" onClick={() => getResults()} id="dropDownButton" className="btn btn-outline-primary">search</button> */}
            </div>
            {
                success?(
                <ul className="dropdown-menu" aria-labelledby="dropDownButton">
                    {
                        results.map(
                            result =>
                                <li key={result.forumname}><a className="dropdown-item" onClick={navigate("/" + result.forumId)}>{result.forumname}</a></li>
                        )
                    }
                </ul>
                ) : (
                    <a>
                        No content
                    </a>
                )
            }
        </div>
    )
}
