import React,{ useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {Form} from 'semantic-ui-react'
import HashingService from "../../../services/HashingService";
import UserService from "../../../services/UserService";

export default function UpdateUser(){
    let param =useParams();
    const [Username, setUsername] = useState('');
    const [Password, setPassword] = useState('');
    const [Email, setEmail] = useState('')
    const [UserID, setUserID] = useState(param.ID);
    const navigation = useNavigate();

    const putUser = () =>{
        setUserID(param.ID);
        let User ={userName: Username, email: Email, password: Password, userId: UserID};
        console.log(User)
        UserService.putUsers(User)
        navigation('/')
    }

    const changePasswordHandler = (value)=>{
        const hashedpassword = HashingService.createHash(value)
        setPassword(hashedpassword);
    }
    return(
        <div className="container">
            <div className="row">
                <div className="card col-md-6 offset-md-3 offset-md-3">
                    <div className="card-body">
                        <Form>
                            <Form.Field className="form-group">
                                <label>Username</label>
                                <input placeholder="Username" onChange={(e) => setUsername(e.target.value)}className="form-control"/>
                            </Form.Field>
                            <Form.Field className="form-group">
                                <label>Email</label>
                                <input placeholder="Email" onChange={(e) => setEmail(e.target.value)}className="form-control"/>
                            </Form.Field>
                            <Form.Field className="form-group">
                                <label>Password</label>
                                <input type="password" placeholder="password" onChange={(e) => changePasswordHandler(e.target.value)}className="form-control"/>
                            </Form.Field>
                            <button className="btn btn-success" style={{marginTop: "10px"}} onClick={putUser} type='submit'>Update</button>
                            <button className="btn btn-danger" style={{marginLeft: "10px", marginTop: "10px"}} onClick={()=> navigation('/')}>Cancel</button>
                        </Form>
                    </div>
                </div>
            </div>
        </div>
    )
}