import React, { useEffect, useState } from 'react';
import UserService from "../../../services/UserService";
import { useNavigate } from "react-router-dom";


export default function ReadUser(){

    const [GETData, setGETData] = useState([]);
    const navigate = useNavigate();

    useEffect(()=>{
        UserService.getUsers().then((response)=>{
            setGETData(response.data);
        })
    }, [])

    return(
        <div>
            <h2 className="text-center">User List</h2>
            
            <div className="row">
                <table className="table table-striped table bordered">
                    <thead>
                        <tr>
                            <th>Username</th>
                            <th>Email</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                            {
                                GETData.map(
                                    user =>
                                    <tr key = {user.userId}>
                                        <td>{user.userName}</td>
                                        <td>{user.email}</td>
                                        <td>
                                            <button className="btn btn-success" onClick={()=>navigate("/EditAccount/"+user.userId)}>Edit</button>
                                        </td>
                                    </tr>
                                )
                            }
                    </tbody>
                </table>
            </div>
        </div>
    )

}