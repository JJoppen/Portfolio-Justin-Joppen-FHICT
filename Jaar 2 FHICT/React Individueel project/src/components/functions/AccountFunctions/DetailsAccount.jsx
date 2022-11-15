import React, {useEffect, useState} from "react";
import UserService from "../../../services/UserService";
import { useParams, useNavigate } from "react-router-dom";

export default function AccountDetails(){
    const [Account, setAccount] = useState([]);
    const navigate = useNavigate();
    let param = useParams();

    useEffect(()=>{
        console.log("Effect running")
        UserService.getUserById(param.ID).then((response)=>{
            setAccount(response.data);
        })
    })

    return(
        <div className="container">
            <div className="row">
                <div className="card col-md-6 offset-md-3 offset-md-3">
                    <div className="card-body">
                        
                    </div>
                </div>
            </div>
        </div>
    )
}